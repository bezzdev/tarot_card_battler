using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game.GameLoop
{
    public class SetupState : State
    {
        private Board board;
        private Delay delay = new Delay(1f);

        public SetupState(Board board) {
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
            foreach(PlayerBoard player in board.players)
            {
                foreach (Card card in CardList.GetAllCards())
                {
                    player.deck.Add(card);
                }
                player.deck.SetCardPositions(true);
            }
        }
    }
}
