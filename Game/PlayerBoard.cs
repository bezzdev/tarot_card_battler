using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public class PlayerBoard
    {
        public List<Card> deck = new List<Card>();
        public List<Card> hand = new List<Card>();
        public List<Card> field = new List<Card>();

        public List<Effect> pendingEffects = new List<Effect>();
        public int health;

        public void Render()
        {
            foreach (Card card in deck) { card.Render(); }
            foreach (Card card in hand) { card.Render(); }
            foreach (Card card in field) { card.Render(); }

        }
    }
}