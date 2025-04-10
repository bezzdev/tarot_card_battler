using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class GameWinState : State
    {
        private Board board;
        private Delay delay = new Delay(0.5f);

        public GameWinState(Board board)
        {
            this.board = board;
        }
        public override void OnEnter()
        {
        }

        public override void Update()
        {

            delay.Update(References.delta);

            if (delay.CompletedOnce())
            {
                foreach(PlayerBoard player in board.players)
                {
                    player.playerStats.level += 1;
                }
                stateMachine.SetState(new NextGameState(board, board.player.playerStats.level));
            }
        }

        public override void Render()
        {
            Raylib.DrawText("Game Win", (References.window_width / 2) - 300, 100, 80, Color.White);
        }
    }
}
