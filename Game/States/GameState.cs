using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.GameLoop;

namespace tarot_card_battler.Game.States
{
    public class GameState : State
    {
        public StateMachine gameLoop;
        public Board board;
        public GameState() {
            board = new Board()
            {
                players = new List<PlayerBoard>()
                {
                    new PlayerBoard() { deck = CardList.GetAllCards() },
                    new PlayerBoard() { deck = CardList.GetAllCards() }
                }
            };

            gameLoop = new StateMachine(new SetupState(board));
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
            board.Render();

            // References.world.Render(References.renderCoordA, References.renderCoordB, References.renderTransform);
            Raylib.EndDrawing();
        }
    }
}
