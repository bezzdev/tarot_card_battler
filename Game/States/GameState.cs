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
            PlayerBoard player = new PlayerBoard();
            player.deck.position.x = 1000;
            player.deck.position.y = 240;

            player.hand.position.x = 600;
            player.hand.position.y = 130;

            PlayerBoard opponent = new PlayerBoard();
            opponent.deck.position.x = 200;
            opponent.deck.position.y = 560;

            opponent.hand.position.x = 600;
            opponent.hand.position.y = 670;

            board = new Board()
            {
                players = new List<PlayerBoard>()
                {
                    player,
                    opponent
                }
            };

            gameLoop = new StateMachine(new SetupState(board));
        }

        public override void Update()
        {
            gameLoop.Update();
            board.Update();
        }
        public override void Render()
        {
            // render
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Game", (References.window_width / 2) - 100, 350, 80, Color.White);
            board.Render();

            Raylib.EndDrawing();
        }
    }
}
