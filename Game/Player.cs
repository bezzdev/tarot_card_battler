using Raylib_cs;
using pizza_jam_raylib.Core;
using System.Numerics;

namespace pizza_jam_raylib.Game
{
    public class Player : Entity
    {
        public float size = 1f; // player diameter
        public Vector2 move_direction;
        public float movespeed = 10f; // units per second


        public override void Update(float delta)
        {
            if (move_direction.Length() > 0)
            {
                Vector2 move = (move_direction / move_direction.Length()) * movespeed * delta;
                position.x += move.X;
                position.y += move.Y;
            }
        }

        public override void Render(RenderTransform transformer)
        {
            double x = transformer.ApplyX(position.x);
            double y = transformer.ApplyY(position.y);
            double size = transformer.ApplyScale(this.size / 2);

            Raylib.DrawCircle((int)x, (int)y, (float)size, Color.Red);
        }
    }
}
