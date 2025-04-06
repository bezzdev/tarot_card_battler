using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.Opponent
{
    public class OpponentData
    {
        public string name;
        public int level;
        public int health;
        public List<Card> cards = new List<Card>();
    }
}
