using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.States;

namespace tarot_card_battler.Game.GameLoop
{
    public class GameOverState : State
    {
        private Board board;
        private Delay delay = new Delay(2f);
        private PlayerDeathAnimation playerDeathAnimation;

        public GameOverState(Board board, PlayerDeathAnimation playerDeathAnimation)
        {
            this.board = board;
            this.playerDeathAnimation = playerDeathAnimation;
        }

        public override void Update()
        {
            delay.Update(References.delta);

            if (delay.Completed())
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left) || Raylib.GetKeyPressed() != 0)
                {
                    stateMachine.SetState(new SetupState(board, 0));
                    playerDeathAnimation.destroyed = true;
                }
            }
        }
    }
}
