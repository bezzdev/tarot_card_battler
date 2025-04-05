using System.Numerics;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.GameLoop
{
    public class OpponentChoiceState : State
    {
        private Board board;
        private PlayerBoard player;
        private Delay delay1 = new Delay(1f);
        private Delay delay2 = new Delay(1.5f);
        private Delay delay3 = new Delay(2f);

        public OpponentChoiceState(Board board, PlayerBoard player)
        {
            this.board = board;
            this.player = player;
        }

        public override void Update()
        {
            delay1.Update(References.delta);
            delay2.Update(References.delta);
            delay3.Update(References.delta);

            if (delay1.CompletedOnce())
            {
                SelectPastCard(player.hand.cards[0]);
            }
            if (delay2.CompletedOnce())
            {
                SelectPresentCard(player.hand.cards[0]);
            }
            if (delay3.CompletedOnce())
            {
                SelectFutureCard(player.hand.cards[0]);
            }
            if (delay1.Completed() && delay2.Completed() && delay3.Completed())
                stateMachine.SetState(new ChoiceState(board));
        }


        public override void Render()
        {
            // if (hover != null)
            // Render
        }

        public void SelectPastCard(Card card)
        {
            player.hand.cards.Remove(card);
            player.hand.SetCardPositions();

            player.field.SetPastCard(card);
        }

        public void SelectPresentCard(Card card)
        {
            player.hand.cards.Remove(card);
            player.hand.SetCardPositions();

            player.field.SetPresentCard(card);
        }

        public void SelectFutureCard(Card card)
        {
            player.hand.cards.Remove(card);
            player.hand.SetCardPositions();

            player.field.SetFutureCard(card);
        }
    }
}
