using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Cards
{

    public class Card
    {
        public Texture2D cardArt;
        public string name;
        public int number;

        public Effect pastEffect;
        public Effect presentEffect;
        public Effect futureEffect;

        // state
        public bool faceup;
        public Coord position;
        public Mover mover;

        public Card(string name, int number, Texture2D cardArt)
        {
            this.name = name;
            this.number = number;
            this.cardArt = cardArt;
            position = new Coord(-400, 0); // off screen
            this.mover = new Mover(position);

            pastEffect = new DamageEffect(1);
            presentEffect = new DamageEffect(2);
            futureEffect = new DamageEffect(3);
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

            
            if (faceup)
            {
                Raylib.DrawTextureEx(cardArt, new System.Numerics.Vector2(x, y), rotation, scale, Color.White);
            } else
            {
                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.White);
                Raylib.DrawRectangle(x + 8, y + 8, (int)width - 16, (int)height - 16, Color.Black);
            }
        }
        public virtual void TriggerPastEffect(PlayerBoard player, PlayerBoard opponent)
        {
            pastEffect.triggerEffect(player, opponent);
        }

        public virtual void TriggerPresentEffect(PlayerBoard player, PlayerBoard opponent)
        {
            presentEffect.triggerEffect(player, opponent);
        }

        public virtual void TriggerFutureEffect(PlayerBoard player, PlayerBoard opponent)
        {
            futureEffect.triggerEffect(player, opponent);
        }
        public virtual bool Interact(double x, double y)
        {
            if((x > position.x - 65 && x < position.x + 65)) {
                if(y > position.y - 110 && y < position.y + 110){
                    return true;
                }
            }
            return false; 
        }
    }
}