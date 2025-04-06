using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.Stats;

namespace tarot_card_battler.Game.PlayArea
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

        public PlayerStats playerStats = new PlayerStats();
        
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
            //discards.Render();
            candle.Render(this);
        }
    }
}