namespace tarot_card_battler.Game.Cards
{
    public static class Opponents
    {
        public static Opponent GetOpponentForLevel(int level)
        {
            Opponent opponent = new Opponent();
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

                opponent.cards.Add(CardList.GetCard(choice));
            }
            return opponent;
        }
    }
}
