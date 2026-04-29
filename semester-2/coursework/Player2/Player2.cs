using System.Collections.Generic;
using System.Linq;
using System;

namespace CardFool
{
    // Убедитесь, что MPlayer2 выглядит идентично, только с другим именем класса
    public class MPlayer2
    {
        private string Name = "Bot_1";
        private List<SCard> hand = new List<SCard>();
        private Suits trumpSuit;

        public string GetName() => Name;
        public int GetCount() => hand.Count;

        public void SetTrump(SCard NewTrump) => trumpSuit = NewTrump.Suit;

        public void AddToHand(SCard card)
        {
            hand.Add(card);
            SortHand();
        }

        private void SortHand()
        {
            hand = hand.OrderBy(c => c.Suit == trumpSuit)
                       .ThenBy(c => c.Rank)
                       .ToList();
        }

        // Логика атаки
        public List<SCard> LayCards()
        {
            var toLay = new List<SCard>();
            // Если рука пуста, мы не можем атаковать, но по правилам AddCards 
            // должен был дать нам карты. Если их нет - это конец игры.
            if (hand.Count > 0)
            {
                var card = hand[0];
                toLay.Add(card);
                hand.RemoveAt(0);
            }
            return toLay;
        }

        // Логика защиты
        public bool Defend(List<SCardPair> table)
        {
            // Важно: table - это список структур. 
            // Чтобы изменения сохранились, нужно менять элементы по индексу.
            for (int i = 0; i < table.Count; i++)
            {
                if (!table[i].Beaten)
                {
                    SCard target = table[i].Down;
                    // Ищем карту, которая побьет
                    int foundIndex = hand.FindIndex(c => SCard.CanBeat(target, c, trumpSuit));

                    if (foundIndex != -1)
                    {
                        SCard cover = hand[foundIndex];
                        SCardPair updatedPair = table[i];
                        updatedPair.SetUp(cover, trumpSuit);
                        table[i] = updatedPair; // Перезаписываем структуру в списке
                        hand.RemoveAt(foundIndex);
                    }
                    else
                    {
                        return false; // Нечем бить - забираем
                    }
                }
            }
            return true;
        }

        public bool AddCards(List<SCardPair> table, bool OpponentDefenced)
        {
            // Для минимальной версии: никогда не подкидываем дополнительные карты
            return false;
        }

        public void OnEndRound(List<SCardPair> table, bool IsDefenceSuccesful)
        {
            // Здесь можно очищать память или логировать, для игры не критично
        }
    }
}