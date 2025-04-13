using Raylib_cs;
using tarot_card_battler.Core.Statemachines;
using static System.Formats.Asn1.AsnWriter;

namespace tarot_card_battler.Game.States
{
    public class CreditState : State {
        private Button backButton = new Button();

        public CreditState(){
            backButton.baseTexture = References.BackButton;
            backButton.hoverTexture = References.BackButtonHover;
            backButton.position = new Core.Coord(180, 40);
        }

        public override void Update(){
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
                }
            }
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(References.HowToPlayBG, new Rectangle(0f, 0f, References.HowToPlayBG.Width, References.HowToPlayBG.Height),
                new Rectangle(0f, 0f, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), System.Numerics.Vector2.Zero, 0f, Color.White);

            backButton.Render();

            int headerSize = 40;
            int nameSize = 30;
            int rowSpacing = 10;

            int columnWidth = 300;
            int columnSpacing = 40;

            int column2 = 600 - (columnWidth / 2);
            int column1 = column2 - columnWidth - columnSpacing;
            int column3 = column2 + columnWidth + columnSpacing;
            column2 += 50;

            int headerY = 200;
            int row1 = headerY + headerSize + rowSpacing;
            int row2 = row1 + headerSize + rowSpacing;


            Raylib.DrawText("Programming", column1, headerY, headerSize, Color.White);
            Raylib.DrawText("person 1", column1, row1, nameSize, Color.White);
            Raylib.DrawText("person 2", column1, row2, nameSize, Color.White);

            Raylib.DrawText("Art", column2, headerY, headerSize, Color.White);
            Raylib.DrawText("person 3", column2, row1, nameSize, Color.White);

            Raylib.DrawText("Sound Design", column3, headerY, headerSize, Color.White);
            Raylib.DrawText("person 1", column3, row1, nameSize, Color.White);

            int cardRow = row2 + rowSpacing + 100;

            float cardScale = 1f;
            float cardWidth = References.The_Hermit.Width * cardScale;

            float sixth = Raylib.GetScreenWidth() / 6f;

            int c1x = (int)(sixth - (cardWidth / 2f));
            Raylib.DrawTextureEx(References.The_Hermit, new System.Numerics.Vector2(c1x, cardRow), 0, cardScale, Color.White);

            int c2x = (int)((sixth * 3f) - (cardWidth / 2f));
            Raylib.DrawTextureEx(References.The_High_Priestess, new System.Numerics.Vector2(c2x, cardRow), 0, cardScale, Color.White);

            int c3x = (int)((sixth * 5f) - (cardWidth / 2f));
            Raylib.DrawTextureEx(References.Judgement, new System.Numerics.Vector2(c3x, cardRow), 0, cardScale, Color.White);
        }
    }
}