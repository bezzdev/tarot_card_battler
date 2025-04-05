using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Game;

namespace tarot_card_battler.Util
{
    public static class Coordinates
    {
        public static int worldWidth = 1200;
        public static int worldHeight = 800;
        
        public static (int x, int y) WorldToScreen(float x, float y)
        {
            int xScale = References.window_width / worldWidth;
            int yScale = References.window_height / worldHeight;

            return ((int)(xScale * x), References.window_height - (int)(yScale * y));
        }

        public static (int x, int y) ScreenToWorld(float x, float y)
        {
            int xScale = References.window_width / worldWidth;
            int yScale = References.window_height / worldHeight;

            return ((int)(xScale * x), References.window_height - (int)(yScale * y));
        }
    }
}
