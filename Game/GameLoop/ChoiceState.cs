using System.Numerics;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;
using System.Security;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace tarot_card_battler.Game.GameLoop
{
    public class ChoiceState : State
    {
        private Board board;
        private Delay delay1 = new Delay(1f);
        private Delay delay2 = new Delay(1.5f);
        private Delay delay3 = new Delay(2f);

        private Card? hoveredCard;

        private Card? selectedCard;

        public ChoiceState(Board board)
        {
            this.board = board;
        }

        public override void Update()
        {
            delay1.Update(References.delta);
            delay2.Update(References.delta);
            delay3.Update(References.delta);

            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            var screen = Coordinates.ScreenToWorld(x, y);
            hoveredCard = Intersections.isHovered(board.player.hand.cards, screen.x, screen.y);


            if (hoveredCard != null)
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    selectedCard = hoveredCard;
                }
            }

            List<Card> fieldList = new List<Card>();

            if (board.player.field.past != null)
            {
                fieldList.Add(board.player.field.past);
            }
            else if (board.player.field.present != null)
            {
                fieldList.Add(board.player.field.present);
            }
            else if (board.player.field.future != null)
            {
                fieldList.Add(board.player.field.future);
            }

            var hoveredField = Intersections.isHovered(fieldList, screen.x, screen.y);

            if (hoveredField != null && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                RemoveCardFromField(hoveredField);
                hoveredCard = null;
                selectedCard = null;
                return;
            }

            if (selectedCard != null)
            {
                if (Raylib.IsMouseButtonReleased(MouseButton.Left))
                {
                    var pastPos = ((int)(board.player.field.position.x + board.player.field.pastPosition.x), (int)(board.player.field.position.y + board.player.field.pastPosition.y));
                    var presentPosition = ((int)(board.player.field.position.x + board.player.field.presentPosition.x), (int)(board.player.field.position.y + board.player.field.presentPosition.y));
                    var futurePosition = ((int)(board.player.field.position.x + board.player.field.futurePosition.x), (int)(board.player.field.position.y + board.player.field.futurePosition.y));

                    var pastDiffX = screen.x - pastPos.Item1;
                    var pastDiffY = screen.y - pastPos.Item2;
                    var pasPyth = Math.Sqrt((pastDiffX * pastDiffX) + (pastDiffY * pastDiffY));

                    var presentDiffX = screen.x - presentPosition.Item1;
                    var presentDiffY = screen.y - presentPosition.Item2;
                    var presentPyth = Math.Sqrt((presentDiffX * presentDiffX) + (presentDiffY * presentDiffY));

                    var futureDiffX = screen.x - futurePosition.Item1;
                    var futureDiffY = screen.y - futurePosition.Item2;
                    var futuretPyth = Math.Sqrt((futureDiffX * futureDiffX) + (futureDiffY * futureDiffY));

                    if (pasPyth < 100 && board.player.field.past == null)
                    {
                        SelectPastCard(selectedCard);
                    }
                    else if (presentPyth < 100 && board.player.field.present == null)
                    {
                        SelectPresentCard(selectedCard);
                    }
                    else if (futuretPyth < 100 && board.player.field.future == null)
                    {
                        SelectFutureCard(selectedCard);
                    }
                    else
                    {
                        board.player.hand.SetCardPositions();
                        selectedCard = null;
                    }
                }
                else if (Raylib.IsMouseButtonDown(MouseButton.Left))
                {
                    selectedCard.mover.SetPosition(screen.x, screen.y, float.MaxValue);
                }
            }
        }

        public void SelectPastCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.past = card;
            board.player.field.SetPastCardPosition();
        }

        public void SelectPresentCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.present = card;
            board.player.field.SetPresentCardPosition();
        }

        public void SelectFutureCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.future = card;
            board.player.field.SetFutureCardPosition();
        }

        public void RemoveCardFromField(Card card)
        {
            if (board.player.field.past == card)
            {
                board.player.field.past = null;
            }
            else if (board.player.field.present == card)
            {
                board.player.field.present = null;
            }
            else if (board.player.field.future == card)
            {
                board.player.field.future = null;
            }

            board.player.hand.Add(card);

            board.player.hand.SetCardPositions();
        }

        public override void Render()
        {
            if (hoveredCard != null)
            {
                var screen = Coordinates.WorldToScreen((int)hoveredCard.position.x, (int)hoveredCard.position.y);
                float scale = 1f;

                float width = hoveredCard.cardArt.Width * scale + 10;
                float height = hoveredCard.cardArt.Height * scale + 10;

                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Yellow);
            }
        }
    }
}
