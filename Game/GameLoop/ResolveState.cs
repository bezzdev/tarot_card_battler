using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using static System.Reflection.Metadata.BlobBuilder;

namespace tarot_card_battler.Game.GameLoop
{
    public class ResolveState : State
    {
        private Board board;

        private Delay nextCardDelaydelay = new Delay(1f);
        private Delay endDelay = new Delay(3f);

        private List<FieldSlot> slots = new List<FieldSlot>();

        public ResolveState(Board board)
        {
            this.board = board;
        }

        public override void OnEnter()
        {
            slots.Add(board.players[0].field.past);
            slots.Add(board.players[1].field.past);
            
            slots.Add(board.players[0].field.present);
            slots.Add(board.players[1].field.present);

            slots.Add(board.players[0].field.future);
            slots.Add(board.players[1].field.future);
        }

        public override void Update()
        {
            if (slots.Count > 0)
            {
                nextCardDelaydelay.Update(References.delta);

                if (nextCardDelaydelay.CompletedOnce())
                {
                    FieldSlot slot = slots[0];
                    if (slot.card != null)
                    {
                        EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);

                        if (slot.number == 0)
                            slot.card.TriggerPastEffect(slot.field.player, slot.field.player.opponent, slot, slot.card);
                        else if (slot.number == 1)
                            slot.card.TriggerPresentEffect(slot.field.player, slot.field.player.opponent, slot, slot.card);
                        else 
                            slot.card.TriggerFutureEffect(slot.field.player, slot.field.player.opponent, slot, slot.card);
                    }
                    slots.Remove(slot);
                    nextCardDelaydelay.Reset();
                }
            }
            else
            {
                endDelay.Update(References.delta);

                if (endDelay.CompletedOnce())
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
}
