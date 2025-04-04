﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game
{
    public class Candle
    {
        public Coord position = new Coord(0, 0);

        public void Render(PlayerBoard playerBoard)
        {
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            int x = screen.x; // - (int)(width / 2);
            int y = screen.y; // - (int)(height / 2);

            Raylib.DrawText(playerBoard.health.ToString(), x, y, 24, Color.Orange);
        }
    }
}
