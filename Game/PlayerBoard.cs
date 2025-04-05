using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public class PlayerBoard
    {
        public Deck deck = new Deck();
        public Hand hand = new Hand();
        public Field field = new Field();

        public List<Effect> pendingEffects = new List<Effect>();
        public int health;

        public PlayerBoard()
        {
        }
        public void Update()
        {
            field.Update();
            deck.Update();
            hand.Update();
        }
        public void Render()
        {
            field.Render();
            deck.Render();
            hand.Render();
        }
    }
}