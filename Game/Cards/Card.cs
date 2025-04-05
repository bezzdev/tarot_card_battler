using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Cards
{

    public class Card
    {
        public Texture2D cardArt;
        public string name;
        public string number;

        public Effect pastEffect;
        public Coord position;
        public Mover mover;

        public Card(string name, Texture2D cardArt)
        {
            this.name = name;
            this.cardArt = cardArt;
            position = new Coord(-400, 0); // off screen
            this.mover = new Mover(position);
        }

        public void Update()
        {
            mover.Update();
        }

        public void Render()
        {
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            float rotation = 0f;
            float scale = 1f;
            
            float width = cardArt.Width * scale;
            float height = cardArt.Height * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height/ 2);

            Raylib.DrawTextureEx(cardArt, new System.Numerics.Vector2(x, y), rotation, scale, Color.White);
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