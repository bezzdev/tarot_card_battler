using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Opponent;

namespace tarot_card_battler.Game.GameLoop
{
    public class SetupState : State
    {
        private Board board;
        private Delay delay = new Delay(1f);
        private int level;

        public SetupState(Board board, int level) {
            this.board = board;
        }

        public override void Update()
        {
            delay.Update(References.delta);

            if (delay.Completed())
            {
                stateMachine.SetState(new FirstDrawState(board));
            }
        }
 
        public override void OnEnter()
        {
            OpponentData opponent = Opponents.GetOpponentForLevel(level);

            foreach (PlayerBoard player in board.players)
            {
                player.hand.cards.Clear();
                player.deck.cards.Clear();
                player.discards.cards.Clear();
                player.field.past.card = null;
                player.field.present.card = null;
                player.field.future.card = null;

                List<Card> cards = null;

                if (player == board.player)
                {
                    player.health = 20;
                    cards = CardList.GetAllCards();
                }
                else
                {
                    player.health = opponent.health;
                    cards = opponent.cards;
                }

                CardList.Shuffle(cards);

                foreach (Card card in cards)
                {
                    player.deck.Add(card);
                }
                player.deck.SetCardPositions(true);
            }
        }
    }
}
