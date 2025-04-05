using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.GameLoop
{
    public class GameWinState : State
    {
        private Board board;
        private Delay delay = new Delay(3f);

        public GameWinState(Board board)
        {
            this.board = board;
        }

        public override void Update()
        {

            delay.Update(References.delta);

            if (delay.CompletedOnce())
            {
                foreach(PlayerBoard player in board.players)
                {
                    player.level += 1;
                }
                stateMachine.SetState(new SetupState(board, board.player.level));
            }
        }

        public override void Render()
        {
            Raylib.DrawText("Game Win", (References.window_width / 2) - 300, 100, 80, Color.White);
        }
    }
}
