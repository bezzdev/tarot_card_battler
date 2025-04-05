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
            player.deck.position.x = 1060;
            player.deck.position.y = 140;

            player.hand.position.x = 600;
            player.hand.position.y = 80;

            player.field.position.x = 600;
            player.field.position.y = 350;

            PlayerBoard opponent = new PlayerBoard();
            opponent.deck.position.x = 140;
            opponent.deck.position.y = 580;

            opponent.hand.position.x = 600;
            opponent.hand.position.y = 900;
            opponent.hand.faceup = false;

            opponent.field.position.x = 600;
            opponent.field.position.y = 630;

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

            board.Render();

            Raylib.EndDrawing();
        }
    }
}
