using Raylib_cs;
using System.Reflection.Emit;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.Opponent
{
    public static class Opponents
    {
        public static OpponentData GetOpponentForLevel(int level)
        {
            OpponentData opponent = new OpponentData();
            Texture2D cardBack = GetCardBack(Random.Shared.Next(0, 4));

            opponent.name = level.ToString();
            opponent.level = level;
            opponent.health = 20;

            int maxCards = 22;

            int additionalCardsPerLevel = 2;
            int cardPoolSize = 8;

            int cardPoolStart = 0;
            cardPoolStart = level * additionalCardsPerLevel;
            int cardPoolEnd = cardPoolStart + cardPoolSize;

            if (cardPoolEnd > maxCards)
            {
                int overshoot = cardPoolEnd - maxCards;
                cardPoolEnd = maxCards;

                cardPoolStart += overshoot;
                if (cardPoolStart > maxCards)
                {
                    cardPoolStart = maxCards;
                }
            }

            int cardCount = Math.Max(3, cardPoolSize);
            for (int i = 0; i < cardCount; i++)
            {
                int offset = i % (cardPoolEnd - cardPoolStart);
                int choice = cardPoolStart + offset;

                Card card = CardList.GetCard(choice);
                card.cardBack = cardBack;
                opponent.cards.Add(card);
            }
            return opponent;
        }

        public static Texture2D GetCardBack(int level)
        {
            int n = (level + 1) % 4;
            if (n == 0)
            {
                return References.Back_Plain;
            }
            else if (n == 1)
            {
                return References.Back_Text;
            }
            else if (n == 2)
            {
                return References.Back_Marbled;
            }
            else if (n == 3)
            {
                return References.Back_Eye_Sigil;
            }
            return References.Back_Plain;
        }
    }
}
