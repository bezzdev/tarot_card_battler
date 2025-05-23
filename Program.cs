﻿using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;
using tarot_card_battler.Game.Sounds;
using tarot_card_battler.Game.States;


References.window_width = 1200;
References.window_height = 800;

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);

#if RELEASE
    Raylib.SetTraceLogLevel(TraceLogLevel.None);
#endif

Raylib.InitWindow(References.window_width, References.window_height, "Ars Minerva");
Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);
Raylib.SetExitKey(0);
Raylib.SetTargetFPS(60);

Raylib.HideCursor();

Raylib.InitAudioDevice();

References.Load();
AudioReferences.Load();

Raylib.SetWindowIcon(References.windowIcon);

StateMachine gameStateMachine = new StateMachine(new MenuState());

// game loop
while (!Raylib.WindowShouldClose() && !References.exit)
{
    float delta = Raylib.GetFrameTime();

    if(Raylib.IsWindowResized())
    {
        References.window_width = Raylib.GetRenderWidth();
        References.window_height = Raylib.GetRenderHeight();
    }

    References.frameDelta = delta;
    gameStateMachine.Update();
    EntityLayerManager.Update();

    MusicHandler.Update();

#if DEBUG
    DebugTools.Update();
#endif

    if (!References.exit)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);

        gameStateMachine.Render();

        int x = Raylib.GetMouseX();
        int y = Raylib.GetMouseY();
        Raylib.DrawTexture(References.Cursor, x, y, Color.White);

        Raylib.EndDrawing();
    }
}

Raylib.CloseAudioDevice();

Raylib.CloseWindow();


return 0;
