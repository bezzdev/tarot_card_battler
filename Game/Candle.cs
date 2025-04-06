using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.PlayArea;
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

            Raylib.DrawTexture(References.CandleBase, x, y, Color.White);
            
            for (int i = 0; i < playerBoard.health; i++){
                Raylib.DrawTexture(References.CandleSegment, x, y - (9 * i), Color.White);
            }

            Raylib.DrawTexture(References.CandleTop, x, y - (9 * playerBoard.health), Color.White);

            if(playerBoard.shield != 0){
                Raylib.DrawText(playerBoard.shield.ToString(), x + 100, y, 48, Color.Gray);
            }
        }
    }
}
