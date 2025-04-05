using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;
using tarot_card_battler.Util;

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

            var screen = Coordinates.WorldToScreen(References.window_width / 2, References.window_height);
            int x = screen.x - (int)(300 / 2);
            int y = screen.y - (int)(200 / 2);

            Raylib.DrawRectangle(x, y, (int)300, (int)200, Color.White);
            Raylib.DrawText("past", x + 40, y, 24, Color.Black);

            Raylib.EndDrawing();
        }
    }
}
