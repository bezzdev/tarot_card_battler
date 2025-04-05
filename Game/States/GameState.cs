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
            player.hand.position.y = 40;

            player.field.position.x = 600;
            player.field.position.y = 350;

            player.candle.position.x = 140;
            player.candle.position.y = 140;

            player.discards.position.x = player.candle.position.x;
            player.discards.position.y = player.candle.position.y;

            PlayerBoard opponent = new PlayerBoard();
            opponent.health = 30;
            opponent.deck.position.x = 140;
            opponent.deck.position.y = 580;

            opponent.hand.position.x = 600;
            opponent.hand.position.y = 900;
            opponent.hand.faceup = false;

            opponent.field.position.x = 600;
            opponent.field.position.y = 630;

            opponent.candle.position.x = 1060;
            opponent.candle.position.y = 580;

            opponent.discards.position.x = opponent.candle.position.x;
            opponent.discards.position.y = opponent.candle.position.y;

            board = new Board()
            {
                player = player,
                players = new List<PlayerBoard>()
                {
                    player,
                    opponent
                }
            };

            gameLoop = new StateMachine(new SetupState(board, 0));
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

            Raylib.DrawText(gameLoop.current_state.ToString(), 0, 20, 20, Color.White);

            gameLoop.EarlyRender();
            board.EarlyRender();

            gameLoop.Render();
            board.Render();

            Raylib.EndDrawing();
        }
    }
}
