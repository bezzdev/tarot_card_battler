using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class DiscardState : State
    {
        private Board board;
        private Delay delay = new Delay(1f);
        private State nextState;

        public DiscardState(Board board, State nextState)
        {
            this.board = board;
            this.nextState = nextState;
        }
        public override void Update()
        {
            delay.Update(References.delta);

            if (delay.Completed())
            {
                stateMachine.SetState(nextState);
            }
        }

        public override void OnEnter()
        {
            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past != null) { 
                    Card past = player.field.past.card;
                    player.field.past.RemoveCard();
                    player.discards.Add(past);
                }

                if (player.field.present != null)
                {
                    Card present = player.field.present.card;
                    player.field.present.RemoveCard();
                    player.discards.Add(present);
                }

                if (player.field.future != null)
                {
                    Card future = player.field.future.card;
                    player.field.future.RemoveCard();
                    player.discards.Add(future);
                }

                player.discards.SetCardPositions();
            }
        }
    }
}
