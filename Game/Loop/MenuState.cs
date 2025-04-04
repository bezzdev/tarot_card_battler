using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.Loop
{
    public class MenuState : State
    {
        public override void Update()
        {
            // update
            References.controller.Update(References.delta);
            References.world.Update(References.delta);
        }

        public override void Render()
        {
            // render
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            int textX = (References.window_width / 2) - 300;
            int textY = 100;
            int fontSize = 80;

            Raylib.DrawText("Tarot Battler", textX, textY, fontSize, Color.White);

            // References.world.Render(References.renderCoordA, References.renderCoordB, References.renderTransform);
            Raylib.EndDrawing();
        }
    }
}
