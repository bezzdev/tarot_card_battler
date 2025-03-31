using Raylib_cs;

namespace pizza_jam_raylib.Game
{
    public class Controller
    {
        public Player player;

        public Controller(Player player)
        {
            this.player = player;
        }

        public void Update(float delta)
        {
            HandleInputs(delta);
        }

        void HandleInputs(float delta)
        {
            if (Raylib.IsKeyDown(KeyboardKey.A))
                player.move_direction.X = -1f;
            else if (Raylib.IsKeyDown(KeyboardKey.D))
                player.move_direction.X = 1f;
            else
                player.move_direction.X = 0f;

            if (Raylib.IsKeyDown(KeyboardKey.W))
                player.move_direction.Y = 1f;
            else if (Raylib.IsKeyDown(KeyboardKey.S))
                player.move_direction.Y = -1f;
            else
                player.move_direction.Y = 0f;
        }
    }
}
