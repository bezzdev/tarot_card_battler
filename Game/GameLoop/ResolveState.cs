using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class ResolveState : State
    {
        private Board board;

        private Delay cardPingDelay = new Delay(0.5f);
        private Delay effectDelay = new Delay(1.5f);

        private Delay endDelay = new Delay(1f);

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

            if (board.player.playerStats.deathCountdown == true)
            {
                board.player.playerStats.countdown -= 1;
                Console.WriteLine($"Player countdown is {board.player.playerStats.countdown}");
            }
            else if (board.players[1].playerStats.deathCountdown == true)
            {
                board.players[1].playerStats.countdown -= 1;
                Console.WriteLine($"Opponent countdown is {board.players[0].playerStats.countdown}");
            }

            if (board.player.playerStats.countdown == 0)
            {
                stateMachine.SetState(new GameOverState(board));
            }
            else if (board.players[1].playerStats.countdown == 0)
            {
                stateMachine.SetState(new GameWinState(board));
            }
        }

        bool finishEarly = false;
        public override void Update()
        {
            if (slots.Count > 0 && !finishEarly)
            {
                FieldSlot slot = slots[0];

                cardPingDelay.Update(References.delta);
                if (cardPingDelay.CompletedOnce())
                {
                    if (slot.card != null)
                    {
                        EntityLayerManager.AddEntity(new CardActivateAnimation(slot.card.position.x, slot.card.position.y), CardActivateAnimation.defaultLayer);
                    }
                }

                effectDelay.Update(References.delta);
                if (effectDelay.CompletedOnce())
                {
                    if (slot.card != null)
                    {
                        slot.card.TriggerEffect(slot.field.player, slot.field.player.opponent, slot);
                    }
                }

                if (cardPingDelay.Completed() && effectDelay.Completed())
                {
                    slots.Remove(slot);
                    cardPingDelay.Reset();
                    effectDelay.Reset();

                    // player game over
                    if (board.player.playerStats.health == 0)
                    {
                        finishEarly = true;
                    }

                    // opponent game over, player wins
                    else if (board.players[1].playerStats.health == 0)
                    {
                        finishEarly = true;
                        EntityLayerManager.AddEntity(new OpponentDeathAnimation(), OpponentDeathAnimation.defaultLayer);
                    }
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
                        stateMachine.SetState(new DiscardState(board, new GameWinState(board)));
                    } else
                    {
                        stateMachine.SetState(new DiscardState(board, new DrawState(board)));
                    }
                }
            }
        }
    }
}
