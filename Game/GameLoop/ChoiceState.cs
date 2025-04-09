using System.Numerics;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using Raylib_cs;
using tarot_card_battler.Util;
using System.Security;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Text;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.GameLoop
{
    public class ChoiceState : State
    {
        private Board board;
        private Delay delay1 = new Delay(1f);
        private Delay delay2 = new Delay(1.5f);
        private Delay delay3 = new Delay(2f);

        private bool isDragged;

        private Card? selectedCard;

        private List<Card> draggableCards = new List<Card>();

        public ChoiceState(Board board)
        {
            this.board = board;
        }

        public override void OnEnter()
        {
            board.castButton.disabled = true;
        }

        public override void OnLeave()
        {
            board.castButton.disabled = true;
        }

        public override void Update()
        {
            delay1.Update(References.delta);
            delay2.Update(References.delta);
            delay3.Update(References.delta);

            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            var screen = Coordinates.ScreenToWorld(x, y);

            Card hoveredCard = InteractionManager.instance.hoveredCard;


            if (board.player.field.past.card != null && board.player.field.present.card != null && board.player.field.future.card != null)
            {
                board.castButton.disabled = false;

                if (Raylib.IsMouseButtonDown(MouseButton.Left) && board.castButton.buttonIsHovered)
                {
                    board.castButton.Click();
                    stateMachine.SetState(new ResolveState(board));
                    return;
                }
            } else
            {
                board.castButton.disabled = true;
            }

            draggableCards.Clear();
            draggableCards.AddRange(board.player.hand.cards);

            // start drag
            if (hoveredCard != null)
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left) && draggableCards.Contains(hoveredCard))
                {
                    selectedCard = InteractionManager.instance.hoveredCard;
                    isDragged = true;
                }
            }

            // remove field card
            List<Card> fieldCards = board.player.field.slots.Where(s => s.card != null).Select(s => s.card).ToList();

            if (hoveredCard != null && fieldCards.Contains(hoveredCard) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                RemoveCardFromField(hoveredCard);
                selectedCard = null;
                return;
            }

            if (selectedCard != null)
            {
                if (Raylib.IsMouseButtonReleased(MouseButton.Left))
                {
                    isDragged = false;
                    var pastPos = board.player.field.past.GetWorldPosition();
                    var presentPosition = board.player.field.present.GetWorldPosition();
                    var futurePosition = board.player.field.future.GetWorldPosition();

                    var pastDist = Coordinates.Distance(screen.x, screen.y, pastPos.x, pastPos.y);
                    var presentDist = Coordinates.Distance(screen.x, screen.y, presentPosition.x, presentPosition.y);
                    var futureDist = Coordinates.Distance(screen.x, screen.y, futurePosition.x, futurePosition.y);

                    if (pastDist < 100 && board.player.field.past.card == null)
                    {
                        SelectPastCard(selectedCard);
                    }
                    else if (presentDist < 100 && board.player.field.present.card == null)
                    {
                        SelectPresentCard(selectedCard);
                    }
                    else if (futureDist < 100 && board.player.field.future.card == null)
                    {
                        SelectFutureCard(selectedCard);
                    }
                    else
                    {
                        board.player.hand.SetCardPositions();
                    }
                    selectedCard = null;
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

            board.player.field.past.SetCard(card);

            AudioReferences.PlaySound(AudioReferences.cardSet);
        }

        public void SelectPresentCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.present.SetCard(card);

            AudioReferences.PlaySound(AudioReferences.cardSet);
        }

        public void SelectFutureCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.future.SetCard(card);

            AudioReferences.PlaySound(AudioReferences.cardSet);
        }

        public void RemoveCardFromField(Card card)
        {
            if (board.player.field.past.card == card)
            {
                board.player.field.past.RemoveCard();
            }
            else if (board.player.field.present.card == card)
            {
                board.player.field.present.RemoveCard();
            }
            else if (board.player.field.future.card == card)
            {
                board.player.field.future.RemoveCard();
            }

            board.player.hand.Add(card);

            board.player.hand.SetCardPositions();
            AudioReferences.PlaySound(AudioReferences.cardDraw);
        }

        public override void EarlyRender()
        {
            if (InteractionManager.instance.hoveredCard != null && isDragged == false && InteractionManager.instance.hoveredCard.owner == board.player)
            {
                Card hovered = InteractionManager.instance.hoveredCard;
                var screen = Coordinates.WorldToScreen((int)hovered.position.x, (int)hovered.position.y);
                float scale = 1f;

                float width = hovered.cardArt.Width * scale + 10;
                float height = hovered.cardArt.Height * scale + 10;

                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Yellow);
            }
        }
    }
}
