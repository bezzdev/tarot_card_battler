using Raylib_cs;
using tarot_card_battler.Core.Statemachines;

namespace tarot_card_battler.Game.States
{
    public class HowToPlayState : State
    {
        private Button backButton = new Button();

        public HowToPlayState()
        {
            backButton.baseTexture = References.StartButton;
            backButton.hoverTexture = References.StartButtonHover;
            backButton.position = new Core.Coord(10, 10);
        }

        public override void Update() {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            if (backButton.IsInBounds(x, y))
            {
                backButton.buttonIsHovered = true;
            } else {
                backButton.buttonIsHovered = false;
            }

            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                if (backButton.IsInBounds(x, y))
                {
                    stateMachine.SetState(new MenuState());
                }
            }
         }

        public override void Render()
        {
            backButton.Render();

            Raylib.DrawText("How To Play", (References.window_width / 2) - 300, 100, 80, Color.White);
        }
    }
}