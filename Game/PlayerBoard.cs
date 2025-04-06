using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public class PlayerBoard(string name)
    {
        public string debugName = name;
        public Deck deck = new Deck();
        public Hand hand = new Hand();
        public Field field = new Field();
        public Candle candle = new Candle();
        public Discards discards = new Discards();
        public List<Effect> pendingEffects = new List<Effect>();
        public int health = 20;
        public int shield = 0;
        public int level = 0;

        public void TakeDamage(int damage)
        {
            int remainder = shield - damage;
            shield -= shield;
            if(shield < 0){
                shield = 0;
            }
            if(shield <= 0){
                health += remainder;
            }
            if (health < 0)
            {
                health = 0;
            }
        }

        public void Heal(int heal){
            health += heal;
            if(health > 20){
                health = 20;
            }
        }

        public void Shield(int shield){
            this.shield += shield;
        }

        public void Update()
        {
            field.Update();
            deck.Update();
            hand.Update();
            discards.Update();
        }

        public void EarlyRender()
        {
            field.Render();
        }


        public void Render()
        {
            // field.Render();
            deck.Render();
            hand.Render();
            discards.Render();
            candle.Render(this);
        }
    }
}