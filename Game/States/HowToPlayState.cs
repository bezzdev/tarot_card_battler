using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.States
{
    public class HowToPlayState : State
    {
        private Button backButton = new Button();
        private int page;
        private TutorialPageData[] pages;


        public HowToPlayState()
        {
            backButton.baseTexture = References.BackButton;
            backButton.hoverTexture = References.BackButtonHover;
            backButton.position = new Core.Coord(180, 40);

            pages = new TutorialPageData[]
            {
                new TutorialPageData()
                {
                    image = References.TutorialImage1,
                    textWidth = 800,
                    text = "Drag a card from your hand into each of the past, present, and future slots. (click to continue)",
                    imageScale = 1f
                },
                new TutorialPageData()
                {
                    image = References.TutorialImage2,
                    textWidth = 700,
                    text = "Click \"CAST FATE\" once 3 cards have been chosen to end the turn. (click to continue)",
                    imageScale = 1f
                },
                new TutorialPageData()
                {
                    image = References.TutorialImage3,
                    textWidth = 700,
                    text = "Each card has a different effect depending on the position they are in. (click to continue)",
                    imageScale = 0.7f
                },
                new TutorialPageData()
                {
                    image = References.TutorialImage4,
                    textWidth = 700,
                    text = "Keep an eye on the player stats. The candle represents the health of each player. (click to continue)",
                    imageScale = 1.5f
                },
                new TutorialPageData()
                {
                    image = References.TutorialImage5,
                    textWidth = 600,
                    text = "Once a player's candle goes out, they lose.",
                    imageScale = 1.5f
                }
            };
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
                    backButton.Click();
                    stateMachine.SetState(new MenuState());
                } else
                {
                    page += 1;
                    if (page == pages.Length)
                    {
                        stateMachine.SetState(new MenuState());
                    }
                }
            }
         }

        public override void Render()
        {
            Raylib.DrawTexturePro(References.HowToPlayBG, new Rectangle(0f, 0f, References.HowToPlayBG.Width, References.HowToPlayBG.Height),
                new Rectangle(0f, 0f, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), System.Numerics.Vector2.Zero, 0f, Color.White);
            
            backButton.Render();


            string text = pages[page].text;
            Texture2D image = pages[page].image;

            // 6Raylib.DrawText("How To Play", (References.window_width / 2) - 300, 100, 80, Color.White);

            int screenX = Raylib.GetScreenWidth() / 2;
            int screenY = Raylib.GetScreenHeight() / 2;

            float scale = pages[page].imageScale;
            int imageWidth = (int)(image.Width * scale);
            int imageHeight = (int)(image.Height * scale);
            int imageX = screenX - (imageWidth / 2);
            int imageY = screenY - (imageHeight / 2) - 40;
            Raylib.DrawTextureEx(image, new System.Numerics.Vector2(imageX, imageY), 0f, scale, Color.White);

            int textWidth = pages[page].textWidth;
            int textX = screenX - (textWidth / 2);
            int textY = screenY + (imageHeight / 2) - 20;
            TextRendering.RenderLines(text, 40, Color.White, textX, textY, textWidth);
        }
    }

    public struct TutorialPageData
    {
        public string text;
        public int textWidth;
        public Texture2D image;
        public float imageScale;
    }
}