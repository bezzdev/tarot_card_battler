using tarot_card_battler.Core;

namespace tarot_card_battler.Game.Cards
{
    public class Deck
    {
        public Coord position = new Coord(0, 0);
        public List<Card> cards = new List<Card>();

        public double cardSpacing = 4;
        public float cardSpeed = 600f;

        public void Update()
        {
            foreach (Card card in cards)
            {
                card.Update();
            }
        }

        public void SetCardPositions(bool instant = false)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].mover.SetPosition(position.x, position.y + (i * cardSpacing), instant ? float.MaxValue : cardSpeed);
            }
        }

        public void Render()
        {
            foreach (Card card in cards) { card.Render(); }
        }
    }
}
