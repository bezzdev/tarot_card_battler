using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.PlayArea;

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
                if (player.field.past.card != null)
                    player.field.past.card.TriggerPastEffect(player, opponent);
            }
            if (delay2.CompletedOnce())
            {
                if (opponent.field.past.card != null)
                    opponent.field.past.card.TriggerPastEffect(opponent, player);
            }

            // present
            if (delay3.CompletedOnce())
            {
                if (player.field.present.card != null)
                    player.field.present.card.TriggerPresentEffect(player, opponent);
            }
            if (delay4.CompletedOnce())
            {
                if (opponent.field.present.card != null)
                    opponent.field.present.card.TriggerPresentEffect(opponent, player);
            }

            // future
            if (delay5.CompletedOnce())
            {
                if (player.field.future.card != null)
                    player.field.future.card.TriggerFutureEffect(player, opponent);
            }
            if (delay6.CompletedOnce())
            {
                if (opponent.field.future.card != null)
                    opponent.field.future.card.TriggerFutureEffect(opponent, player);
            }

            if (delay7.Completed())
            {
                // player game over
                if (board.player.playerStats.health == 0)
                {
                    stateMachine.SetState(new GameOverState(board));
                }

                // opponent game over, player wins
                else if (board.players[1].playerStats.health == 0)
                {
                    stateMachine.SetState(new GameWinState(board));
                } 
                else
                {
                    stateMachine.SetState(new DiscardState(board));
                }
            }
        }
    }
}
