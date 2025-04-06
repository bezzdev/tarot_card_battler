using Raylib_cs;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.States
{
    public class CreditState : State {
        public override void Update(){}

        public override void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Credits", (References.window_width / 2) - 300, 100, 80, Color.White);
            Raylib.DrawText("Master Chief", (References.window_width / 2) - 300, 200, 40, Color.White);

            Raylib.EndDrawing();
        }
    }
}