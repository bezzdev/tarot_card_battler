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

            //double xPercent = (x - (-(worldWidth / 2))) / worldWidth;
            //int pixelX = (int)(xPercent * References.window_width);

            //double yPercent = (y - (-(worldHeight / 2))) / worldHeight;
            //int pixelY = References.window_height - (int)(yPercent * References.window_height);
            //return (pixelX, pixelY);
        }


    }
}
