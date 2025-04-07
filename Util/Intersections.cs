using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Util
{
    public static class Intersections
    {
        public static Card GetHoveredCard(List<Card> cards, double x, double y){
            foreach (Card card in cards)
            {
                if (card.IsInBounds(x, y))
                {
                    return card;
                }
            }
            return null;
        }
    }
}
