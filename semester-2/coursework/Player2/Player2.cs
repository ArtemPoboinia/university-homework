using System;
using System.Collections.Generic;

namespace CardFool
{
    public class MPlayer1
    {
        private string _name = "Custom_V2";
        private Dictionary<Suits, List<SCard>> _hand = new Dictionary<Suits, List<SCard>>();
        private SCard _trump;

        private List<SCard> _seen = new List<SCard>();
        private List<SCard> _oppCards = new List<SCard>();
        private int _deckCount = 24;

        // Инициализация игрока
        public MPlayer1() => Reset();

        // Возвращает имя бота для движка
        public string GetName() => _name;

        // Считаем общее кол-во карт в руке по всем мастям
        public int GetCount()
        {
            int total = 0;
            foreach (var s in _hand.Values) total += s.Count;
            return total;
        }

        // Обнуление состояния перед новой партией
        public void Reset()
        {
            _hand.Clear();
            _seen.Clear();
            _oppCards.Clear();
            _deckCount = 24;
        }

        // Установка козыря и запоминание его в "вышедшие"
        public void SetTrump(SCard t)
        {
            _trump = t;
            _seen.Add(t);
        }

        // Добор карты: сортируем руку и обновляем память о колоде
        public void AddToHand(SCard c)
        {
            _seen.Add(c);
            _oppCards.RemoveAll(x => x.Suit == c.Suit && x.Rank == c.Rank);

            if (!_hand.ContainsKey(c.Suit)) _hand[c.Suit] = new List<SCard>();
            _hand[c.Suit].Add(c);
            _hand[c.Suit].Sort((a, b) => a.Rank.CompareTo(b.Rank));

            if (_deckCount > 0) _deckCount--;
        }

        // Логика первого хода: выбираем самую "дешевую" карту или пару
        public List<SCard> LayCards()
        {
            SCard best = null;
            double minWeight = double.MaxValue;

            foreach (var suit in _hand.Values)
            {
                foreach (var c in suit)
                {
                    double w = GetWeight(c);
                    if (w < minWeight)
                    {
                        minWeight = w;
                        best = c;
                    }
                }
            }

            if (best == null) return new List<SCard>();

            var toPlay = new List<SCard>();
            foreach (var s in _hand.Values)
            {
                for (int i = s.Count - 1; i >= 0; i--)
                {
                    if (s[i].Rank == best.Rank)
                    {
                        toPlay.Add(s[i]);
                        s.RemoveAt(i);
                    }
                }
            }
            return toPlay;
        }

        // Логика защиты: ищем минимальные карты для отбоя или решаем взять
        public bool Defend(List<SCardPair> table)
        {
            var myAll = new List<SCard>();
            foreach (var s in _hand.Values) myAll.AddRange(s);

            var solutions = new Dictionary<int, SCard>();
            double totalCost = 0;

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].Beaten) continue;

                SCard target = table[i].Down;
                SCard bestCover = null;
                double bestCoverWeight = double.MaxValue;

                foreach (var my in myAll)
                {
                    if (solutions.ContainsValue(my)) continue;

                    if (SCard.CanBeat(target, my, _trump.Suit))
                    {
                        double w = GetWeight(my);
                        if (w < bestCoverWeight)
                        {
                            bestCoverWeight = w;
                            bestCover = my;
                        }
                    }
                }

                if (bestCover == null) return false;

                solutions[i] = bestCover;
                totalCost += bestCoverWeight;
            }

            // Если защита слишком дорогая по весам, выгоднее набрать карт
            if (_deckCount > 5 && totalCost > 50)
            {
                if (GetCount() < 10) return false;
            }

            foreach (var kvp in solutions)
            {
                var p = table[kvp.Key];
                p.SetUp(kvp.Value, _trump.Suit);


                table[kvp.Key] = p;
                RemoveFromHand(kvp.Value);
            }
            return true;
        }

        // Подкидывание карт: только если они не слишком ценные
        public bool AddCards(List<SCardPair> table, bool done)
        {
            if (done && _deckCount > 0) return false;

            var onTable = new HashSet<int>();
            foreach (var p in table)
            {
                onTable.Add(p.Down.Rank);
                if (p.Beaten) onTable.Add(p.Up.Rank);
            }

            foreach (var suit in _hand.Values)
            {
                for (int i = 0; i < suit.Count; i++)
                {
                    if (onTable.Contains(suit[i].Rank) && GetWeight(suit[i]) < 20)
                    {
                        table.Add(new SCardPair(suit[i]));
                        var c = suit[i];
                        suit.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        // Анализ конца раунда: запоминаем, что ушло в бито, а что взял враг
        public void OnEndRound(List<SCardPair> table, bool win)
        {
            foreach (var p in table)
            {
                _seen.Add(p.Down);
                if (p.Beaten) _seen.Add(p.Up);
                else _oppCards.Add(p.Down);
            }
        }

        // Расчет веса карты: учитывает ранг, козырь и наличие пар в руке
        private double GetWeight(SCard c)
        {
            double w = c.Rank;
            if (c.Suit == _trump.Suit) w += 15;

            if (_deckCount == 0 && c.Suit == _trump.Suit) w *= 2;

            int count = 0;
            foreach (var s in _hand.Values)
                foreach (var card in s) if (card.Rank == c.Rank) count++;

            if (count > 1) w += 5;

            return w;
        }

        // Служебный метод для чистки руки после хода
        private void RemoveFromHand(SCard c)
        {
            if (_hand.ContainsKey(c.Suit))
            {
                _hand[c.Suit].RemoveAll(x => x.Rank == c.Rank && x.Suit == c.Suit);
            }
        }
    }
}