using System.Runtime.CompilerServices;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Cards;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;
using tarot_card_battler.Game.States;

References.window_height = 1200;
References.window_height = 800;
References.Load();

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
// Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
Raylib.InitWindow(References.window_width, References.window_height, "Tarot Battler");
Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);

Raylib.SetTargetFPS(60);

StateMachine gameStateMachine = new StateMachine(new MenuState());

// game loop
while (!Raylib.WindowShouldClose())
{
    float delta = Raylib.GetFrameTime();

    if(Raylib.IsWindowResized())
    {
        References.window_width = Raylib.GetRenderWidth();
        References.window_height = Raylib.GetRenderHeight();
    }

    References.delta = delta;
    gameStateMachine.Update();
    gameStateMachine.Render();
}

Raylib.CloseWindow();

return 0;
