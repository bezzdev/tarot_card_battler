using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public class PlayerBoard
    {
        public Deck deck = new Deck();
        public Hand hand = new Hand();
        public Field field = new Field();
        public Candle candle = new Candle();

        public List<Effect> pendingEffects = new List<Effect>();
        public int health = 20;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
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
            candle.Render(this);
        }
    }
}