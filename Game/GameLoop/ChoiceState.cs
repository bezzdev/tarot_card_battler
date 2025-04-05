using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.GameLoop
{
    public class ChoiceState : State
    {
        private Board board;

        public ChoiceState(Board board)
        {
            this.board = board;
        }
    }
}
