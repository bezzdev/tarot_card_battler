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
    }
}