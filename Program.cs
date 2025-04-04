using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game;

const int screenWidth = 1200;
const int screenHeight = 800;

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
Raylib.InitWindow(screenWidth, screenHeight, "Raylib Template");
Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);

Raylib.SetTargetFPS(60);

Coord renderCoordA = new Coord(0.0, 0.0);
Coord renderCoordB = new Coord(screenWidth, screenHeight);
RenderTransform renderTransform = new RenderTransform(20.0, -10.0, 20.0);
World world = new World();

Player player = new Player();
world.entities.Add(player);

Controller controller = new Controller(player);

// game loop
while (!Raylib.WindowShouldClose())
{
    float delta = Raylib.GetFrameTime();

    if(Raylib.IsWindowResized())
    {
        renderCoordB.x = Raylib.GetRenderWidth();
        renderCoordB.y = Raylib.GetRenderHeight();
    }

    // update
    controller.Update(delta);
    world.Update(delta);

    // render
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    world.Render(renderCoordA, renderCoordB, renderTransform);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();

return 0;
