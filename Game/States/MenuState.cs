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
            float height = References.StartButton.Height;
            int x = References.window_width / 2;
            int y = References.window_height / 2;

            startButton.baseTexture = References.StartButton;
            startButton.hoverTexture = References.StartButtonHover;
            startButton.position = new Coord(304, 330);

            howToPlayButton.baseTexture = References.HelpButton;
            howToPlayButton.hoverTexture = References.HelpButtonHover;
            howToPlayButton.position = new Coord(304, 420);

            creditsButton.baseTexture = References.CreditsButton;
            creditsButton.hoverTexture = References.CreditsButtonHover;
            creditsButton.position = new Coord(304, 510);

            quitButton.baseTexture = References.QuitButton;
            quitButton.hoverTexture = References.QuitButtonHover;
            quitButton.position = new Coord(304, 600);

        }
        public override void Update()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            startButton.buttonIsHovered = startButton.IsInBounds(x, y);
            howToPlayButton.buttonIsHovered = howToPlayButton.IsInBounds(x, y);
            creditsButton.buttonIsHovered = creditsButton.IsInBounds(x, y);
            quitButton.buttonIsHovered  = quitButton.IsInBounds(x, y);

            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                if (startButton.IsInBounds(x, y))
                {
                    startButton.Click();
                    stateMachine.SetState(new GameState());
                }
                else if (howToPlayButton.IsInBounds(x, y))
                {
                    howToPlayButton.Click();
                    stateMachine.SetState(new HowToPlayState());
                }
                else if (creditsButton.IsInBounds(x, y))
                {
                    creditsButton.Click();
                    stateMachine.SetState(new CreditState());
                }
                else if (quitButton.IsInBounds(x, y))
                {
                    quitButton.Click();
                    Raylib.CloseWindow();
                }
            } else if (Raylib.IsKeyDown(KeyboardKey.Space)){
                stateMachine.SetState(new GameState());
            } else if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                Raylib.CloseWindow();
            }
        }

        public override void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("Tarot Battler", (References.window_width / 2) - 300, 100, 80, Color.White);

            startButton.Render();
            howToPlayButton.Render();
            creditsButton.Render();
            quitButton.Render();

            Raylib.EndDrawing();
        }
    }
}
