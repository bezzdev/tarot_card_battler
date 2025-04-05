using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.GameLoop
{
    public class ResolveState : State
    {
        private Board board;

        private Delay delay1 = new Delay(1f);
        private Delay delay2 = new Delay(1.5f);

        private Delay delay3 = new Delay(2.5f);
        private Delay delay4 = new Delay(3f);

        private Delay delay5 = new Delay(4f);
        private Delay delay6 = new Delay(4.5f);
        
        private Delay delay7 = new Delay(6f);


        public ResolveState(Board board)
        {
            this.board = board;
        }

        public override void Update()
        {
            delay1.Update(References.delta);
            delay2.Update(References.delta);
            delay3.Update(References.delta);
            delay4.Update(References.delta);
            delay5.Update(References.delta);
            delay6.Update(References.delta);
            delay7.Update(References.delta);
            
            PlayerBoard player = board.player;
            PlayerBoard opponent = board.players[1];

            // past
            if (delay1.CompletedOnce())
            {
                player.field.past.TriggerPastEffect(player, opponent);
            }
            if (delay2.CompletedOnce())
            {
                opponent.field.past.TriggerPastEffect(opponent, player);
            }

            // present
            if (delay3.CompletedOnce())
            {
                player.field.present.TriggerPresentEffect(player, opponent);
            }
            if (delay4.CompletedOnce())
            {
                player.field.present.TriggerPresentEffect(opponent, player);
            }

            // future
            if (delay5.CompletedOnce())
            {
                player.field.future.TriggerFutureEffect(player, opponent);
            }
            if (delay6.CompletedOnce())
            {
                player.field.future.TriggerFutureEffect(opponent, player);
            }

            if (delay7.Completed())
            {
                stateMachine.SetState(new DiscardState(board));
            }
        }
    }
}
