using Raylib_cs;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.Loop
{
    public class GameState : State
    {
        public override void Update()
        {
            
        }
        public override void Render()
        {
            // render
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Game", (References.window_width / 2) - 300, 200, 80, Color.White);

            // References.world.Render(References.renderCoordA, References.renderCoordB, References.renderTransform);
            Raylib.EndDrawing();
        }
    }
}
