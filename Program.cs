﻿using System.Runtime.CompilerServices;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;
using tarot_card_battler.Game.States;

References.window_width = 1200;
References.window_height = 800;

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
// Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
Raylib.InitWindow(References.window_width, References.window_height, "Tarot Battler");
Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);

Raylib.SetTargetFPS(60);

References.Load();

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

    References.frameDelta = delta;
    gameStateMachine.Update();
    gameStateMachine.Render();
}

Raylib.CloseWindow();

return 0;
