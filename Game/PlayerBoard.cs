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
            deck.Update();
            hand.Update();
            field.Update();
        }
        public void Render()
        {
            deck.Render();
            hand.Render();
            field.Render();
        }
    }
}