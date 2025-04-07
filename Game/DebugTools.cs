using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_card_battler.Game
{
    public static class DebugTools
    {
        public static void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Minus))
            {
                References.gameSpeed = MathF.Max(0.1f, References.gameSpeed / 2f);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Equal))
            {
                References.gameSpeed = References.gameSpeed + 1f;
            }
        }
    }
}
