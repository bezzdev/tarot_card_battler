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

        private Card hoveredCard;

        private Card? selectedCard;

        private double originalX;
        private double originalY;

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
            hoveredCard = Intersections.isHovered(board.players[0].hand.cards, screen.x, screen.y);

            if(hoveredCard != null){
                if(Raylib.IsMouseButtonPressed(MouseButton.Left)){
                    selectedCard = hoveredCard;
                    originalX = hoveredCard.position.x;
                    originalY = hoveredCard.position.y;
                }
            }

            if(selectedCard != null){
                if(Raylib.IsMouseButtonUp(MouseButton.Left)){
                       selectedCard.mover.SetPosition(originalX, originalY, 2500);
                       selectedCard = null;
                    } else if(Raylib.IsMouseButtonDown(MouseButton.Left)){
                        selectedCard.mover.SetPosition(screen.x, screen.y, float.MaxValue);
                }
            }


            //if (delay1.CompletedOnce())
            //{
            //    SelectPastCard(board.player.hand.cards[0]);
            //}
            //if (delay2.CompletedOnce())
            //{
            //    SelectPresentCard(board.player.hand.cards[0]);
            //}
            //if (delay3.CompletedOnce())
            //{
            //    SelectFutureCard(board.player.hand.cards[0]);
            //}
            //if (delay1.Completed() && delay2.Completed() && delay3.Completed())
            //    stateMachine.SetState(new ResolveState(board));
        }

        //if (hoveredCard != null)
        // {
        //     if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        //     {
        //         selectedCard = hoveredCard;
        //         if (!isLocked)
        //         {
        //             Console.WriteLine($"Locked, {hoveredCard.position.x}, {hoveredCard.position.y}");
        //             isLocked = true;
        //             originalPos = hoveredCard.position;
        //         }
        //     }
        //     if (Raylib.IsMouseButtonReleased(MouseButton.Left))
        //     {
        //         Console.WriteLine($"Selected");
        //         selectedCard = hoveredCard;
        //     }
        // }


        // if (isLocked && selectedCard != null)
        // {
        //     Console.WriteLine("Moving back");
        //     selectedCard.mover.SetPosition(originalPos.x, originalPos.y, float.MaxValue);
        //     if (selectedCard.position == originalPos)
        //     {   
        //         Console.WriteLine("Returned to OG position");
        //         isLocked = false;
        //         selectedCard = null;
        //     }
        // }


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
