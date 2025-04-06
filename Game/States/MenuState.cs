using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.States
{
    public class MenuState : State
    {
        private Button startButton = new Button();
        private Button howToPlayButton = new Button();
        private Button creditsButton = new Button();
        private Button quitButton = new Button();

        public MenuState()
        {
            float height = References.CastButton.Height;
            float width = References.CastButton.Width / 2;
            int x = (int)((References.window_width / 2) - width);
            int y = References.window_height / 2;

            startButton.baseTexture = References.CastButton;
            startButton.hoverTexture = References.HoverButton;
            startButton.position = new Coord(x, y);

            howToPlayButton.baseTexture = References.CastButton;
            howToPlayButton.hoverTexture = References.HoverButton;
            howToPlayButton.position = new Coord(x, (int)(y + height + 20));

            creditsButton.baseTexture = References.CastButton;
            creditsButton.hoverTexture = References.HoverButton;
            creditsButton.position = new Coord(x, y + height + height + 40);

            quitButton.baseTexture = References.CastButton;
            quitButton.hoverTexture = References.HoverButton;
            quitButton.position = new Coord(x, y + height + height + height + 60);

        }
        public override void Update()
        {
            int x = Raylib.GetMouseX() - startButton.baseTexture.Width / 2; //hehe i'm evil
            int y = Raylib.GetMouseY()  - startButton.baseTexture.Height / 2;

            if (startButton.IsInBounds(x, y))
            {
                startButton.buttonIsHovered = true;
            }
            else if (howToPlayButton.IsInBounds(x, y))
            {
                howToPlayButton.buttonIsHovered = true;
            }
            else if (creditsButton.IsInBounds(x, y))
            {
                creditsButton.buttonIsHovered = true;
            }
            else if (quitButton.IsInBounds(x, y))
            {
                quitButton.buttonIsHovered = true;
            }
            else
            {
                startButton.buttonIsHovered = false;
                howToPlayButton.buttonIsHovered = false;
                creditsButton.buttonIsHovered = false;
                quitButton.buttonIsHovered = false;
            }

            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                if (startButton.IsInBounds(x, y))
                {
                    stateMachine.SetState(new GameState());
                }
                else if (howToPlayButton.IsInBounds(x, y))
                {
                    //howToPlayButton.buttonIsHovered = true;
                }
                else if (creditsButton.IsInBounds(x, y))
                {
                    //creditsButton.buttonIsHovered = true;
                }
                else if (quitButton.IsInBounds(x, y))
                {
                    Raylib.CloseWindow();
                }
            } else if (Raylib.IsKeyDown(KeyboardKey.Space)){
                stateMachine.SetState(new GameState());
            }
        }

        public override void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Tarot Battler", (References.window_width / 2) - 300, 100, 80, Color.White);

            float height = References.CastButton.Height;
            float width = References.CastButton.Width / 2;
            int x = (int)((References.window_width / 2) - width);
            int y = References.window_height / 2;

            startButton.Render();
            howToPlayButton.Render();
            creditsButton.Render();
            quitButton.Render();

            Raylib.EndDrawing();
        }
    }
}
