using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.GameLoop
{
    public class DiscardState : State
    {
        private Board board;
        private Delay delay = new Delay(3f);

        public DiscardState(Board board)
        {
            this.board = board;
        }
        public override void Update()
        {
            delay.Update(References.delta);

            if (delay.Completed())
            {
                stateMachine.SetState(new DrawState(board));
            }
        }

        public override void OnEnter()
        {
            int draw = 3;

            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past != null) { 
                    Card past = player.field.past;
                    player.field.past = null;
                    player.discards.Add(past);
                }

                if (player.field.present != null)
                {
                    Card present = player.field.present;
                    player.field.present = null;
                    player.discards.Add(present);
                }


                if (player.field.future != null)
                {
                    Card future = player.field.future;
                    player.field.future = null;
                    player.discards.Add(future);
                }

                player.discards.SetCardPositions();
            }
        }
    }
}
