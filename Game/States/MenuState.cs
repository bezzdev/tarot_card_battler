﻿using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;

namespace tarot_card_battler.Game.States
{
    public class MenuState : State
    {
        public override void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.Space))
            {
                stateMachine.SetState(new GameState());
            }
        }

        public override void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Tarot Battler", (References.window_width / 2) - 300, 100, 80, Color.White);
            Raylib.DrawText("Press Space", (References.window_width / 2) - 100, 200, 40, Color.Gray);

            Raylib.EndDrawing();
        }
    }
}
