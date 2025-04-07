using Raylib_cs;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.PlayArea
{
    public class Board
    {
        public PlayerBoard player;
        public List<PlayerBoard> players = new List<PlayerBoard>();

        private int buttonX = 600;
        private int buttonY = 400;

        public bool buttonIsHovered = false;
        public void Update()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            if (x > buttonX - References.CastButton.Width / 2 && x < buttonX + References.CastButton.Width / 2)
            {
                if (y > buttonY - References.CastButton.Height / 2 && y < buttonY + References.CastButton.Height / 2)
                {
                    buttonIsHovered = true;
                }
                else
                {
                    buttonIsHovered = false;
                }
            }
            else
            {
                buttonIsHovered = false;
            }

            foreach (PlayerBoard player in players)
            {
                player.Update();
            }
        }

        public void EarlyRender()
        {
            foreach (PlayerBoard player in players)
            {
                player.EarlyRender();
            }
        }

        public void Render()
        {
            var screen = Coordinates.WorldToScreen(buttonX, buttonY);
            float scale = 1f;

            float width = References.CastButton.Width * scale;
            float height = References.CastButton.Height * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);
            if (buttonIsHovered)
            {
                Raylib.DrawTexture(References.HoverButton, x, y, Color.White);
            }
            else
            {
                Raylib.DrawTexture(References.CastButton, x, y, Color.White);
            }
            foreach (PlayerBoard player in players)
            {
                player.Render();
            }
        }
    }
}