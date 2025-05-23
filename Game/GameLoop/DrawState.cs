﻿using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.GameLoop
{
    public class DrawState : State
    {
        private Board board;
        private Delay delay = new Delay(0.5f);

        public DrawState(Board board)
        {
            this.board = board;
        }
        public override void OnEnter()
        {
            // death countdown
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
        }

        public override void Update()
        {
            delay.Update(References.delta);

            if (board.players[1].playerStats.drawPerTurn > 0)
            {
                if (delay.Completed()) {
                    if (TryDrawCard(board.players[1]))
                    {
                        DrawCard(board.players[1]);
                        board.players[1].playerStats.drawPerTurn -= 1;
                        delay.time = 0f;
                    } else
                    {
                        delay.time = 0f;
                        return;
                    }
                }
            }

            if (board.player.playerStats.drawPerTurn > 0)
            {
                if (delay.Completed())
                {
                    if (TryDrawCard(board.player))
                {
                        DrawCard(board.player);
                        board.player.playerStats.drawPerTurn -= 1;
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
                board.player.playerStats.drawPerTurn = 3;
                board.players[1].playerStats.drawPerTurn = 3;
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
            } else
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
