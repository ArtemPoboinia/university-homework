using System;
using System.Collections.Generic;

namespace CardFool
{
    public class MPlayer1
    {
        private string Name = "Poboinia A A";
        private Dictionary<Suits, SortedSet<SCard>> hand = new Dictionary<Suits, SortedSet<SCard>>();
        private SCard trump;

        private int opponCards = 6;
        private HashSet<SCard> cardsInTable = new HashSet<SCard>();
        private HashSet<SCard> knownOpponentCards = new HashSet<SCard>();
        private HashSet<SCard> destroyedCards = new HashSet<SCard>();
        private List<SCardPair> savedTable = new List<SCardPair>();

        private bool isDefending = false;
        private int attackLimitForOpponent = 6;
        private int tableCards = 24;
        private bool endGame = false;
        private int initialCardsReceived = 0;

        // Конструктор, сбрасывает состояние.
        public MPlayer1() { Reset(); }

        // Возвращает имя игрока.
        public string GetName() => Name;

        // Возвращает количество карт в руке.
        public int GetCount() => hand.Count;

        // Устанавливает козырную масть.
        public void SetTrump(SCard NewTrump)
        {
            trump = NewTrump;
        }

        // Сбрасывает все данные для новой партии.
        public void Reset()
        {
            hand = new Dictionary<Suits, SortedSet<SCard>>();
            opponCards = 6;
            cardsInTable = LocalGetDeck().ToHashSet();
            knownOpponentCards = new HashSet<SCard>();
            savedTable = new List<SCardPair>();
            destroyedCards = new HashSet<SCard>();
            isDefending = false;
            attackLimitForOpponent = 6;
            tableCards = 24;
            endGame = false;
            initialCardsReceived = 0;
        }

        // Создаёт полную колоду из 36 карт.
        private List<SCard> LocalGetDeck()
        {
            var deck = new List<SCard>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
                for (int rank = 6; rank <= 14; rank++)
                    deck.Add(new SCard(suit, rank));
            return deck;
        }

        // Извлекает все карты из списка пар (включая битые).
        private List<SCard> LocalCardPairsToCards(IEnumerable<SCardPair> pairs)
        {
            List<SCard> cards = new List<SCard>();
            foreach (var pair in pairs)
            {
                cards.Add(pair.Down);
                if (pair.Beaten) cards.Add(pair.Up);
            }
            return cards;
        }

        // Добавляет карту в руку и обновляет учёт карт.
        public void AddToHand(SCard card)
        {
            cardsInTable.Remove(card);
            knownOpponentCards.Remove(card);

            if (initialCardsReceived < 6) initialCardsReceived++;
            else if (tableCards > 0) tableCards--;

            RefreshEndGame();

            if (!hand.ContainsKey(card.Suit))
                hand[card.Suit] = new SortedSet<SCard>(Comparer<SCard>.Create((a, b) => a.Rank.CompareTo(b.Rank)));

            hand[card.Suit].Add(card);
        }

        // Проверяет, не наступил ли эндшпиль, и вычисляет точный состав руки противника.
        private void RefreshEndGame(IEnumerable<SCardPair> currentTable = null)
        {
            if (endGame)
            {
                LearnAllRemainingOpponentCards(currentTable);
                return;
            }

            if (tableCards <= 0)
            {
                endGame = true;
                tableCards = 0;
                LearnAllRemainingOpponentCards(currentTable);
            }
        }

        // Вычисляет точный набор карт противника при пустом прикупе.
        private void LearnAllRemainingOpponentCards(IEnumerable<SCardPair> currentTable = null)
        {
            HashSet<SCard> tableCardsNow = currentTable == null ? new HashSet<SCard>() : CardsFromTable(currentTable);
            var opponent = LocalGetDeck().ToHashSet();

            opponent.ExceptWith(tableCardsNow);
            opponent.ExceptWith(destroyedCards);
            foreach (var c in hand.SelectMany(kv => kv.Value)) opponent.Remove(c);

            knownOpponentCards = opponent;
            opponCards = opponent.Count;
            attackLimitForOpponent = Math.Min(attackLimitForOpponent, Math.Min(6, opponCards));
        }

        // Собирает все карты, лежащие на столе.
        private static HashSet<SCard> CardsFromTable(IEnumerable<SCardPair> table)
        {
            HashSet<SCard> result = new HashSet<SCard>();
            foreach (var pair in table)
            {
                result.Add(pair.Down);
                if (pair.Beaten) result.Add(pair.Up);
            }
            return result;
        }

        // Выбирает карты для начала атаки.
        public List<SCard> LayCards()
        {
            if (isDefending)
            {
                destroyedCards.UnionWith(LocalCardPairsToCards(savedTable.Where(x => x.Beaten)));
                cardsInTable.RemoveWhere(x => savedTable.Any(y => y.Down.Equals(x)));
                knownOpponentCards.RemoveWhere(x => savedTable.Any(y => y.Down.Equals(x) && y.Beaten));
                knownOpponentCards.UnionWith(savedTable.Where(y => !y.Beaten).Select(x => x.Down));
            }
            else
            {
                cardsInTable.RemoveWhere(x => savedTable.Any(y => y.Up.Equals(x)));
                knownOpponentCards.UnionWith(LocalCardPairsToCards(savedTable));
            }

            isDefending = false;
            UpdateOpponentCardCount();
            attackLimitForOpponent = opponCards;
            RefreshEndGame();

            int maxStartCards = Math.Min(6, attackLimitForOpponent);
            if (maxStartCards <= 0) return new List<SCard>();

            var allMyCards = hand.SelectMany(kv => kv.Value).ToList();
            if (allMyCards.Count == 0) return new List<SCard>();

            SCard bestFirstCard = allMyCards.First();

            if (endGame)
            {
                var unbeatables = allMyCards.Where(my => !knownOpponentCards.Any(enemy => SCard.CanBeat(my, enemy, trump.Suit))).ToList();
                if (unbeatables.Any())
                {
                    bestFirstCard = unbeatables.OrderBy(c => c.Suit == trump.Suit ? 1 : 0).ThenBy(c => c.Rank).First();
                }
                else
                {
                    bestFirstCard = allMyCards
                        .OrderBy(c => EndGameAttackScore(c))
                        .ThenBy(c => c.Suit == trump.Suit ? 1 : 0)
                        .ThenBy(c => c.Rank)
                        .First();
                }
            }
            else
            {
                var rankGroups = allMyCards.Where(c => c.Suit != trump.Suit).GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).ToList();

                if (rankGroups.Any() && rankGroups.First().Count() > 1)
                {
                    bestFirstCard = rankGroups.First().First();
                }
                else
                {
                    bestFirstCard = allMyCards.OrderBy(c => c.Suit == trump.Suit ? 100 : c.Rank).First();
                }
            }

            int rankToLay = bestFirstCard.Rank;
            var cardsToPlay = allMyCards
                .Where(c => c.Rank == rankToLay)
                .OrderBy(c => c.Suit == trump.Suit ? 1 : 0)
                .Take(maxStartCards)
                .ToList();

            foreach (var card in cardsToPlay) RemoveFromHand(card);
            return cardsToPlay;
        }

        // Пытается подкинуть карты на стол.
        public bool AddCards(List<SCardPair> table, bool OpponentDefenced)
        {
            int remainingOpponentCards = EstimateOpponentCardCount(table);
            attackLimitForOpponent = Math.Min(attackLimitForOpponent, table.Count + remainingOpponentCards);
            opponCards = remainingOpponentCards;
            RefreshEndGame(table);

            int canThrowMax = Math.Min(6, attackLimitForOpponent) - table.Count;
            if (canThrowMax <= 0) return false;

            var tableRanks = new HashSet<int>();
            foreach (var pair in table)
            {
                tableRanks.Add(pair.Down.Rank);
                if (pair.Beaten) tableRanks.Add(pair.Up.Rank);
            }

            var allMyCards = hand.SelectMany(kv => kv.Value).ToList();

            var candidates = allMyCards
                .Where(c => tableRanks.Contains(c.Rank))
                .OrderBy(c => EndGameAttackScore(c))
                .ThenBy(c => c.Suit == trump.Suit ? 1 : 0)
                .ThenBy(c => c.Rank)
                .ToList();

            if (OpponentDefenced && !endGame)
            {
                candidates.RemoveAll(c => knownOpponentCards.Any(enemy => SCard.CanBeat(c, enemy, trump.Suit) && enemy.Suit != trump.Suit && enemy.Rank < 11));
            }

            var cardsToThrow = candidates.Take(canThrowMax).ToList();

            foreach (var card in cardsToThrow)
            {
                table.Add(new SCardPair(card));
                RemoveFromHand(card);
            }

            savedTable = table.ToList();
            return cardsToThrow.Count > 0;
        }

        // Определяет, может ли игрок отбиться, и выполняет защиту.
        public bool Defend(List<SCardPair> table)
        {
            if (!isDefending)
            {
                destroyedCards.UnionWith(LocalCardPairsToCards(savedTable.Where(x => x.Beaten)));
                knownOpponentCards.RemoveWhere(x => savedTable.Any(y => y.Up.Equals(x)));
                cardsInTable.RemoveWhere(x => savedTable.Any(y => y.Up.Equals(x)));
            }

            isDefending = true;
            RefreshEndGame(table);

            List<int> unbeatenIndexes = table.Select((pair, index) => new { pair, index }).Where(x => !x.pair.Beaten).Select(x => x.index).ToList();
            if (unbeatenIndexes.Count == 0) return true;

            var allHandCards = hand.SelectMany(kv => kv.Value).ToList();
            var rankCountsBefore = allHandCards.GroupBy(c => c.Rank).ToDictionary(g => g.Key, g => g.Count());

            List<SCard> bestDefence = null;
            int bestCost = int.MaxValue;

            void Search(int pos, HashSet<SCard> used, List<SCard> chosen, int costSoFar)
            {
                if (costSoFar >= bestCost) return;

                if (pos >= unbeatenIndexes.Count)
                {
                    int futureBonus = FutureHandScoreAfterDefence(used, allHandCards);
                    int totalCost = costSoFar - futureBonus;
                    if (totalCost < bestCost)
                    {
                        bestCost = totalCost;
                        bestDefence = chosen.ToList();
                    }
                    return;
                }

                int tableIndex = unbeatenIndexes[pos];
                SCard attack = table[tableIndex].Down;

                var validCovers = allHandCards
                    .Where(c => !used.Contains(c) && SCard.CanBeat(attack, c, trump.Suit))
                    .OrderBy(c => DefenceCardCost(attack, c, rankCountsBefore))
                    .ToList();

                if (validCovers.Count > 4) validCovers = validCovers.Take(4).ToList();

                foreach (var card in validCovers)
                {
                    used.Add(card);
                    chosen.Add(card);
                    Search(pos + 1, used, chosen, costSoFar + DefenceCardCost(attack, card, rankCountsBefore));
                    chosen.RemoveAt(chosen.Count - 1);
                    used.Remove(card);
                }
            }

            Search(0, new HashSet<SCard>(), new List<SCard>(), 0);

            if (bestDefence == null) return false;

            for (int i = 0; i < unbeatenIndexes.Count; i++)
            {
                int tableIndex = unbeatenIndexes[i];
                SCard card = bestDefence[i];

                var pair = table[tableIndex];
                pair.SetUp(card, trump.Suit);
                table[tableIndex] = pair;
                RemoveFromHand(card);
            }

            savedTable = table.ToList();
            return true;
        }

        // Обрабатывает завершение раунда, обновляя учёт карт.
        public void OnEndRound(List<SCardPair> table, bool IsDefenceSuccesful)
        {
            savedTable = table.ToList();

            if (IsDefenceSuccesful)
            {
                destroyedCards.UnionWith(LocalCardPairsToCards(table));
                knownOpponentCards.RemoveWhere(x => table.Any(y => y.Down.Equals(x) || (y.Beaten && y.Up.Equals(x))));
                cardsInTable.RemoveWhere(x => table.Any(y => y.Down.Equals(x) || (y.Beaten && y.Up.Equals(x))));
            }
            else
            {
                knownOpponentCards.UnionWith(LocalCardPairsToCards(table));
                cardsInTable.RemoveWhere(x => table.Any(y => y.Down.Equals(x) || (y.Beaten && y.Up.Equals(x))));
            }

            if (tableCards > 0)
            {
                int beforeCap = Math.Min(6, knownOpponentCards.Count + cardsInTable.Count);
                int opponentNeed = Math.Max(0, 6 - beforeCap);
                tableCards = Math.Max(0, tableCards - opponentNeed);
            }

            UpdateOpponentCardCount();
            attackLimitForOpponent = opponCards;
            RefreshEndGame();
        }

        // Удаляет карту из руки.
        private void RemoveFromHand(SCard card)
        {
            if (hand.ContainsKey(card.Suit))
            {
                hand[card.Suit].Remove(card);
                if (hand[card.Suit].Count == 0) hand.Remove(card.Suit);
            }
        }

        // Оценивает количество карт в руке противника.
        private int EstimateOpponentCardCount(IEnumerable<SCardPair> currentTable = null)
        {
            var tableCardsNow = currentTable == null ? new HashSet<SCard>() : CardsFromTable(currentTable);
            int remainingOut = LocalGetDeck().Count - GetCount() - destroyedCards.Count - tableCardsNow.Count;

            if (endGame || tableCards <= 0) return Math.Max(0, remainingOut);

            HashSet<SCard> possible = new HashSet<SCard>(cardsInTable);
            possible.UnionWith(knownOpponentCards);
            possible.ExceptWith(tableCardsNow);

            int estimate = Math.Min(possible.Count, remainingOut);
            return Math.Max(0, Math.Min(6, estimate));
        }

        // Обновляет оценку количества карт противника.
        private void UpdateOpponentCardCount() => opponCards = EstimateOpponentCardCount();

        // Оценочная функция для выбора карт атаки в эндшпиле.
        private int EndGameAttackScore(SCard card)
        {
            var answer = knownOpponentCards
                .Where(enemy => SCard.CanBeat(card, enemy, trump.Suit))
                .OrderBy(enemy => enemy.Suit == trump.Suit ? 1 : 0)
                .ThenBy(enemy => enemy.Rank)
                .Cast<SCard?>()
                .FirstOrDefault();

            int answerRank = answer?.Rank ?? 100;
            int unbeatableBonus = answerRank == 100 ? -2000 : 0;
            int trumpPenalty = card.Suit == trump.Suit ? 200 : 0;
            return unbeatableBonus + trumpPenalty - answerRank + card.Rank;
        }

        // Вычисляет стоимость использования карты для защиты.
        private int DefenceCardCost(SCard attack, SCard defence, Dictionary<int, int> rankCountsBefore)
        {
            int cost = defence.Rank;
            if (defence.Suit == trump.Suit && attack.Suit != trump.Suit) cost += 5000;
            else if (defence.Suit == trump.Suit) cost += 1000;

            if (defence.Suit != trump.Suit && defence.Rank <= 10) cost += 15 - defence.Rank;
            if (rankCountsBefore.TryGetValue(defence.Rank, out int count) && count == 1) cost += 10;

            return cost;
        }

        // Оценивает перспективность оставшейся руки после защиты.
        private int FutureHandScoreAfterDefence(HashSet<SCard> used, List<SCard> allHandCards)
        {
            var remaining = allHandCards.Where(c => !used.Contains(c)).ToList();
            int score = 0;

            foreach (var group in remaining.GroupBy(c => c.Rank))
            {
                score += group.Count() * group.Count() * 30;
                score += Math.Max(0, 15 - group.Key);
            }
            score += remaining.Count(c => c.Suit == trump.Suit) * 80;
            return score;
        }
    }
}