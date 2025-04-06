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
            if(buttonIsHovered){
                Raylib.DrawTexture(hoverTexture, (int )position.x, (int) position.y, Color.White);
            } else {
                Raylib.DrawTexture(baseTexture, (int )position.x, (int) position.y, Color.White);
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