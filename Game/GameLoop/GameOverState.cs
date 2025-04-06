using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class GameOverState : State
    {
        private Board board;
        private Delay delay = new Delay(3f);

        public GameOverState(Board board)
        {
            this.board = board;
        }
        public override void Render()
        {
            Raylib.DrawText("Game Over", (References.window_width / 2) - 300, 100, 80, Color.White);
        }
    }
}
