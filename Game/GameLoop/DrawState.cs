using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.GameLoop
{
    public class DrawState : State
    {
        private Board board;
        private Delay delay = new Delay(1f);

        public DrawState(Board board)
        {
            this.board = board;
        }
        public override void Update()
        {
            delay.Update(References.delta);

            if (delay.Completed())
            {
                stateMachine.SetState(new OpponentChoiceState(board, board.players[1]));
            }
        }

        public override void OnEnter()
        {
            int draw = 3;

            foreach (PlayerBoard player in board.players)
            {
                for (int i = 0; i < draw; i++) {
                    if (player.deck.cards.Count > 0)
                    {
                        int last = player.deck.cards.Count - 1;
                        Card card = player.deck.cards[last];
                        player.deck.cards.RemoveAt(last);

                        player.hand.Add(card);

                        card.mover.delay = i * 0.4f;
                    }
                }
                player.hand.SetCardPositions();
            }
        }
    }
}
