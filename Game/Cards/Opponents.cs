namespace tarot_card_battler.Game.Cards
{
    public static class Opponents
    {
        public static Opponent GetOpponentForLevel(int level)
        {
            Opponent opponent = new Opponent();
            opponent.name = level.ToString();
            opponent.level = level;

            int maxCards = 22;

            int additionalCardsPerLevel = 2;
            int cardPoolSize = 5;

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

            int cardCount = 10;
            for (int i = 0; i < cardCount; i++)
            {
                int offset = i % (cardPoolEnd - cardPoolStart);
                int choice = cardPoolStart + offset;

                opponent.cards.Add(CardList.GetAllCards()[choice]);
            }
            return opponent;
        }
    }
}
