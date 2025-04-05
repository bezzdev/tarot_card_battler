using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.GameLoop
{
    public class ResolveState : State
    {
        private Board board;

        public ResolveState(Board board)
        {
            this.board = board;
        }
    }
}
