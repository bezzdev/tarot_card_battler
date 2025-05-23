﻿using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.GameLoop
{
    public class FirstDrawState : State
    {
        private Board board;
        private Delay delay = new Delay(0.5f);

        private int playerDraw = 5;
        private int opponentDraw = 5;

        public FirstDrawState(Board board)
        {
            this.board = board;
        }

        public override void Update()
        {
            delay.Update(References.delta);

            if (board.players[1].hand.cards.Count < opponentDraw)
            {
                if (delay.Completed())
                {
                    if (TryDrawCard(board.players[1]))
                    {
                        DrawCard(board.players[1]);
                        delay.time = 0f;
                    }
                    else
                    {
                        delay.time = 0f;
                        return;
                    }
                }
            }

            if (board.player.hand.cards.Count < playerDraw)
            {
                if (delay.Completed())
                {
                    if (TryDrawCard(board.player))
                    {
                        DrawCard(board.player);
                        delay.time = 0f;
                    }
                    else
                    {
                        delay.time = 0f;
                        return;
                    }
                }
            }

            if (delay.Completed())
            {
                stateMachine.SetState(new OpponentChoiceState(board, board.players[1]));
            }
        }

        public bool TryDrawCard(PlayerBoard player)
        {
            if (player.deck.cards.Count == 0)
            {
                List<Card> discardCards = player.discards.cards.ToList();
                CardList.Shuffle(discardCards);

                foreach (Card card in discardCards)
                {
                    player.discards.cards.Remove(card);
                    player.deck.Add(card);
                }
                player.deck.SetCardPositions();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DrawCard(PlayerBoard player)
        {
            int last = player.deck.cards.Count - 1;
            Card card = player.deck.cards[last];
            player.deck.cards.RemoveAt(last);

            player.hand.Add(card);

            player.hand.SetCardPositions();
            AudioReferences.PlaySound(AudioReferences.cardDraw);
            // card.mover.delay = i * 0.4f;
        }
    }
}
