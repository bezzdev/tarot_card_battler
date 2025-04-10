using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Opponent;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.GameLoop
{
    public class NextGameState : State
    {
        private Board board;
        private Delay resetDelay = new Delay(2f);
        private Delay gameStartDelay = new Delay(4f);
        private int level;

        public NextGameState(Board board, int level)
        {
            this.board = board;
        }

        public override void Update()
        {
            resetDelay.Update(References.delta);
            if (resetDelay.CompletedOnce())
            {
                ResetBoard();
            }

            gameStartDelay.Update(References.delta);
            if (gameStartDelay.CompletedOnce())
            {
                stateMachine.SetState(new FirstDrawState(board));
            }
        }

        public void ResetBoard()
        {
            OpponentData opponent = Opponents.GetOpponentForLevel(level);

            foreach (PlayerBoard player in board.players)
            {
                if (player == board.player)
                    continue;

                player.hand.cards.Clear();
                player.deck.cards.Clear();
                player.discards.cards.Clear();
                player.field.past.RemoveCard();
                player.field.present.RemoveCard();
                player.field.future.RemoveCard();

                List<Card> cards = null;

                if (player == board.player)
                {
                    player.playerStats.health = 20;
                    cards = CardList.GetAllCards();
                }
                else
                {
                    player.playerStats.health = opponent.health;
                    cards = opponent.cards;
                }

                CardList.Shuffle(cards);

                foreach (Card card in cards)
                {
                    card.owner = player;
                    player.deck.Add(card);
                }
                player.deck.SetCardPositions(true);
            }

            if (References.opponentDeathAnimation != null)
            {
                References.opponentDeathAnimation.destroyed = true;
                AudioReferences.PlaySound(AudioReferences.lightCandle);
            }
        }
    }
}
