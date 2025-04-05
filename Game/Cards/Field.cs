using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Cards
{
    public class Field
    {
        public Card past;
        public Card present;
        public Card future;

        public Coord position = new Coord(0, 0);
        public Coord pastPosition = new Coord(-170, 0);
        public Coord presentPosition = new Coord(0, 0);
        public Coord futurePosition = new Coord(170, 0);
        public float cardSpeed = 1400f;

        public void Update()
        {
        }

        public void SetPastCardPosition(bool instant = false) {
            double goalX = position.x + pastPosition.x;
            double goalY = position.y + pastPosition.y;

            past.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void SetPresentCardPosition(bool instant = false)
        {
            double goalX = position.x + presentPosition.x;
            double goalY = position.y + presentPosition.y;

            present.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void SetFutureCardPosition(bool instant = false)
        {
            double goalX = position.x + futurePosition.x;
            double goalY = position.y + futurePosition.y;

            future.mover.SetPosition(goalX, goalY, instant ? float.MaxValue : cardSpeed);
        }

        public void Render()
        {
            float scale = 1f;
            float width = (146 + 16) * scale;
            float height = (236 + 16) * scale;

            {
                var screen = Coordinates.WorldToScreen((int)(position.x + pastPosition.x), (int)(position.y + pastPosition.y));
                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Gray);
                Raylib.DrawRectangle(x + 2, y + 2, (int)width - 4, (int)height - 4, Color.Black);
                Raylib.DrawText("past", x + 40, y + (int)(height / 2), 24, Color.Gray);
            }
            {
                var screen = Coordinates.WorldToScreen((int)(position.x + presentPosition.x), (int)(position.y + presentPosition.y));
                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Gray);
                Raylib.DrawRectangle(x + 2, y + 2, (int)width - 4, (int)height - 4, Color.Black);
                Raylib.DrawText("present", x + 30, y + (int)(height / 2), 24, Color.Gray);
            }
            {
                var screen = Coordinates.WorldToScreen((int)(position.x + futurePosition.x), (int)(position.y + futurePosition.y));
                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                Raylib.DrawRectangle(x, y, (int)width, (int)height, Color.Gray);
                Raylib.DrawRectangle(x + 2, y + 2, (int)width - 4, (int)height - 4, Color.Black);
                Raylib.DrawText("future", x + 40, y + (int)(height / 2), 24, Color.Gray);
            }
            if (past != null)
                past.Render();
            
            if (present != null)
                present.Render();
            
            if (future != null)
                future.Render();
        }
    }
}
