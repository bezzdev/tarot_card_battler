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

namespace tarot_card_battler.Game.GameLoop
{
    public class ChoiceState : State
    {
        private Board board;
        private Delay delay1 = new Delay(1f);
        private Delay delay2 = new Delay(1.5f);
        private Delay delay3 = new Delay(2f);

        private Card? hoveredCard;

        private bool isDragged;

        private Card? selectedCard;

        private List<Card> hoverableCards = new List<Card>();
        private List<Card> draggableCards = new List<Card>();

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

            // determine valid hover targets
            hoverableCards.Clear();
            hoverableCards.AddRange(board.player.hand.cards);
            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past.card != null)
                    hoverableCards.Add(player.field.past.card);
                if (player.field.present.card != null)
                    hoverableCards.Add(player.field.present.card);
                if (player.field.future.card != null)
                    hoverableCards.Add(player.field.future.card);
            }

            hoveredCard = Intersections.GetHoveredCard(hoverableCards, screen.x, screen.y);

            draggableCards.Clear();
            draggableCards.AddRange(board.player.hand.cards);

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && board.castButton.buttonIsHovered)
            {
                if (board.player.field.past.card != null && board.player.field.present.card != null && board.player.field.future.card != null)
                {
                    stateMachine.SetState(new ResolveState(board));
                    return;
                }
            }


            if (hoveredCard != null)
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left) && draggableCards.Contains(hoveredCard))
                {
                    selectedCard = hoveredCard;
                    isDragged = true;
                }
            }

            List<Card> fieldCards = board.player.field.slots.Where(s => s.card != null).Select(s => s.card).ToList();
            var hoveredField = Intersections.GetHoveredCard(fieldCards, screen.x, screen.y);

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
        }

        public void SelectPresentCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.present.SetCard(card);
        }

        public void SelectFutureCard(Card card)
        {
            board.player.hand.cards.Remove(card);
            board.player.hand.SetCardPositions();

            board.player.field.future.SetCard(card);
        }

        public void RemoveCardFromField(Card card)
        {
            if (board.player.field.past.card == card)
            {
                board.player.field.past.card = null;
            }
            else if (board.player.field.present.card == card)
            {
                board.player.field.present.card = null;
            }
            else if (board.player.field.future.card == card)
            {
                board.player.field.future.card = null;
            }

            board.player.hand.Add(card);

            board.player.hand.SetCardPositions();
        }

        public override void EarlyRender()
        {
            if (hoveredCard != null && isDragged == false)
            {
                var screen = Coordinates.WorldToScreen((int)hoveredCard.position.x, (int)hoveredCard.position.y);
                float scale = 1f;

                float width = hoveredCard.cardArt.Width * scale + 10;
                float height = hoveredCard.cardArt.Height * scale + 10;

                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Yellow); //CARD HOVER
            }
        }

        public override void Render()
        {
            if (hoveredCard != null && isDragged == false)
            {
                var screen = Coordinates.WorldToScreen((int)hoveredCard.position.x, (int)hoveredCard.position.y);
                float scale = 1f;

                float width = hoveredCard.cardArt.Width * scale;
                float height = hoveredCard.cardArt.Height * scale;

                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                string pastText = $"Past: {hoveredCard.pastEffect.tooltip}";
                string presentText = $"Present: {hoveredCard.presentEffect.tooltip}";
                string futureText = $"Future: {hoveredCard.futureEffect.tooltip}";

                int maxLength = new [] { pastText.Length, presentText.Length, futureText.Length }.Max();
                int maxSize = maxLength * 12;

                Raylib.DrawRectangle((int)(x - (maxSize / 2)), (y - 200), maxSize, (int)height / 2, Color.White); //CARD TOOLTIP
                Raylib.DrawText("Past: " + hoveredCard.pastEffect.tooltip, x - (maxSize / 2), (int)(y - 200), 24, Color.Purple);
                Raylib.DrawText("Present: " + hoveredCard.presentEffect.tooltip, x - (maxSize / 2), (y - 200 + 20), 24, Color.SkyBlue);
                Raylib.DrawText("Future: " + hoveredCard.futureEffect.tooltip, x - (maxSize / 2), (y - 200 + 40), 24, Color.Red);
            }
        }
    }
}
