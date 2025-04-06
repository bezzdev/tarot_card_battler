using Raylib_cs;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.States
{
    public class HowToPlayState : State {
        public override void Update(){}

        public override void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("How To Play", (References.window_width / 2) - 300, 100, 80, Color.White);

            Raylib.EndDrawing();
        }
    }
}