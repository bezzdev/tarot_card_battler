using tarot_card_battler.Core;
using tarot_card_battler.Game.Effects;
using tarot_card_battler.Game.Stats;

namespace tarot_card_battler.Game.PlayArea
{
    public class PlayerBoard
    {
        public string debugName;
        public PlayerBoard opponent;

        public Deck deck = new Deck();
        public Hand hand = new Hand();
        public Field field;
        public Candle candle = new Candle();
        public Discards discards = new Discards();
        public List<Effect> pendingEffects = new List<Effect>();
        public PlayerStats playerStats = new PlayerStats();

        public PlayerBoard(string name)
        {
            debugName = name;
            field = new Field(this);
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
            candle.Render(this);
            deck.Render();
            hand.Render();
            playerStats.Render();

            //discards.Render();
        }
    }
}