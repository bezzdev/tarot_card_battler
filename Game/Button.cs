using Raylib_cs;
using tarot_card_battler.Core;

namespace tarot_card_battler.Game {
    public class Button {
        public Texture2D hoverTexture;
        public Texture2D baseTexture; 

        public bool buttonIsHovered;
        
        public Coord position;

        public void Update(){}

        public void Render(){
            float width = baseTexture.Width;
            float height = baseTexture.Height;

            int x = (int)position.x - (int)(width / 2);
            int y = (int)position.y - (int)(height / 2);

            if (buttonIsHovered){
                Raylib.DrawTextureEx(hoverTexture, new System.Numerics.Vector2(x, y), 0f, 1f, Color.White);
            } else {
                Raylib.DrawTextureEx(baseTexture, new System.Numerics.Vector2(x, y), 0f, 1f, Color.White);
            }
        }

        public virtual bool IsInBounds(double x, double y)
        {
            int halfWidth = baseTexture.Width / 2;
            int halfHeight = baseTexture.Height / 2;
            if (x > position.x - halfWidth && x < position.x + halfWidth && y > position.y - halfHeight && y < position.y + halfHeight){
                    return true;
            }
            return false; 
        }
    }
}