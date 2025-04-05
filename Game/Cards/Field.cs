using System.Numerics;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Cards
{
    public class Field
    {
        public Card? past;
        public Card? present;
        public Card? future;

        public Coord position = new Coord(0, 0);
        public Coord pastPosition = new Coord(-170, 0);
        public Coord presentPosition = new Coord(0, 0);
        public Coord futurePosition = new Coord(170, 0);
        public float cardSpeed = 2000f;

        public void Update()
        {
            if (past != null)
                past.Update();
            if(present != null)
                present.Update();
            if(future != null)
                future.Update();
        }

        public void SetPastCard(Card card) {
            past = card;
            card.faceup = true;
            SetPastCardPosition();
        }

        public void SetPastCardPosition(bool instant = false) {
            double goalX = position.x + pastPosition.x;
            double goalY = position.y + pastPosition.y;

            past.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void SetPresentCard(Card card)
        {
            present = card;
            card.faceup = true;
            SetPresentCardPosition();
        }

        public void SetPresentCardPosition(bool instant = false)
        {
            double goalX = position.x + presentPosition.x;
            double goalY = position.y + presentPosition.y;

            present.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }
        public void SetFutureCard(Card card)
        {
            future = card;
            card.faceup = true;
            SetFutureCardPosition();
        }

        public void SetFutureCardPosition(bool instant = false)
        {
            double goalX = position.x + futurePosition.x;
            double goalY = position.y + futurePosition.y;

            future.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void Render()
        {
            if (past != null)
                past.Render();
            
            if (present != null)
                present.Render();
            
            if (future != null)
                future.Render();
        }
    }
}
