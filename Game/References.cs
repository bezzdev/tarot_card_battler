using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Core;

namespace tarot_card_battler.Game
{
    public static class References
    {
        public static int window_width = 1200;
        public static int window_height = 800;

        public static RenderTransform renderTransform;

        public static World world = new World();
        public static Player player = new Player() {  size = 1};
        public static Controller controller = new Controller(player);
        public static float delta;
    }
}
