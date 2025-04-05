using Raylib_cs;
using tarot_card_battler.Core;

namespace tarot_card_battler.Game.Cards
{

    public class Card
    {
        public Texture2D cardArt;
        public string name;
        public string number;

        public Effect pastEffect;
        public Coord pos;

        public Card(string name, Texture2D cardArt)
        {
            this.name = name;
            this.cardArt = cardArt;
            pos = new Coord(6, 4);
        }

        public void Render()
        {
            Raylib.DrawTexture(cardArt, (int)(pos.x / References.window_width), (int)(pos.y / References.window_height), Color.White);
        }
        public virtual void TriggerPastEffect()
        {
            pastEffect.triggerEffect();
        }

        public virtual void TriggerPresentEffect()
        {
            pastEffect.triggerEffect();
        }

        public virtual void TriggerFutureEffect()
        {
            pastEffect.triggerEffect();
        }
    }
}