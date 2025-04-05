using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_card_battler.Game;

namespace tarot_card_battler.Core
{
    public class Mover
    {
        public Coord coord;
        public double goalX;
        public double goalY;
        public float speed;
        public float delay = 0f;

        public Mover(Coord coord)
        {
            this.coord = coord;
            goalX = coord.x;
            goalY = coord.y;
            speed = 1f;
        }

        public void SetPosition(double x, double y, float speed = 1f)
        {
            goalX = x;
            goalY = y;
            this.speed = speed;
        }

        public void Update()
        {
            if (delay > 0)
            {
                delay -= References.delta;
                return;
            }

            double currentX = coord.x;
            double currentY = coord.y;

            double deltaX = goalX - currentX;
            double deltaY = goalY - currentY;

            double mag = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            if (mag > 0)
            {
                double nX = deltaX / mag;
                double nY = deltaY / mag;

                double moveX = nX * References.delta * speed;
                double moveY = nY * References.delta * speed;

                double newX = currentX + moveX;
                if (Math.Abs(moveX) > Math.Abs(deltaX))
                    newX = goalX;

                double newY = currentY + moveY;
                if (Math.Abs(moveY) > Math.Abs(deltaY))
                    newY = goalY;

                coord.x = newX;
                coord.y = newY;
            }
        }
    }
}
