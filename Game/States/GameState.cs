using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.GameLoop;

namespace tarot_card_battler.Game.States
{
    public class GameState : State
    {
        public StateMachine gameLoop;
        public GameState() {
            gameLoop = new StateMachine(new SetupState());
        }

        public override void Update()
        {
            gameLoop.Update();
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
