using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;
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
                FieldSlot slot = player.field.past;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    slot.card.TriggerPastEffect(player, opponent, slot, slot.card);
                }
            }
            if (delay2.CompletedOnce())
            {
                FieldSlot slot = opponent.field.past;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer); 
                    slot.card.TriggerPastEffect(opponent, player, slot, slot.card);
                }
            }

            // present
            if (delay3.CompletedOnce())
            {
                FieldSlot slot = player.field.present;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    slot.card.TriggerPresentEffect(player, opponent, slot, slot.card);
                }
            }
            if (delay4.CompletedOnce())
            {
                FieldSlot slot = opponent.field.present;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    slot.card.TriggerPresentEffect(opponent, player, slot, slot.card);
                }
            }

            // future
            if (delay5.CompletedOnce())
            {
                FieldSlot slot = player.field.future;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    slot.card.TriggerFutureEffect(player, opponent, slot, slot.card);
                }
            }
            if (delay6.CompletedOnce())
            {
                FieldSlot slot = opponent.field.future;
                if (slot.card != null)
                {
                    EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    slot.card.TriggerFutureEffect(opponent, player, slot, slot.card);
                }
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
