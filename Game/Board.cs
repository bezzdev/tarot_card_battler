using Raylib_cs;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game
{
    public class Board
    {
        public PlayerBoard player;
        public List<PlayerBoard> players = new List<PlayerBoard>();

        
        public void Update()
        {
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
            var screen = Coordinates.WorldToScreen((int)600, (int)470);
            float scale = 1f;
            
            float width = References.CastButton.Width * scale;
            float height = References.CastButton.Height * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height/ 2);
            Raylib.DrawTexture(References.CastButton, x, y, Color.White);
            foreach (PlayerBoard player in players)
            {
                player.Render();
            }
        }
    }
}