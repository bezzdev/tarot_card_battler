using Raylib_cs;
using System.Numerics;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.States
{
    public class CreditState : State {
        private Button backButton = new Button();
        private List<CreditsCard> cards = new List<CreditsCard>();

        public CreditState(){
            backButton.baseTexture = References.BackButton;
            backButton.hoverTexture = References.BackButtonHover;
            backButton.position = new Core.Coord(180, 40);

            List<Texture2D> cardTextures = CardList.GetAllCards().Select(c => c.cardArt).ToList();
            SpawnCards(cardTextures);
            SpawnCards(cardTextures);
            SpawnCards(cardTextures);
        }

        public void SpawnCards(List<Texture2D> cardTextures)
        {
            foreach (Texture2D texture in cardTextures)
            {
                var spawn = GetRandomSpawn(true);
                float scale = 0.7f + (cards.Count * 0.005f);
                cards.Add(new CreditsCard()
                {
                    x = spawn.x,
                    y = spawn.y,
                    dy = spawn.dy,
                    r = spawn.r,
                    s = scale,
                    texture = texture
                });
            }
        }

        public (float x, float y, float dy, float r) GetRandomSpawn(bool randomY = false)
        {
            float x = 0 + ((float)Random.Shared.NextDouble() * 1100);
            float y = randomY ? -100 - ((float)Random.Shared.NextDouble() * 1100) : -300;
            float dy = 50f;// + (float)Random.Shared.NextDouble() * 60f;
            float r = (float)Random.Shared.NextDouble() * 360f;
            return (x, y, dy, r);
        }

        public class CreditsCard
        {
            public float x;
            public float y;
            public float dy;
            public float r;
            public float s;
            public Texture2D texture;
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

            UpdateCards();
        }

        public void UpdateCards ()
        {
            foreach(CreditsCard card in cards)
            {
                card.y += References.delta * card.dy * card.s; 

                if (card.y > 1100)
                {
                    var spawn = GetRandomSpawn();
                    card.x = spawn.x;
                    card.y = spawn.y;
                    card.r = spawn.r;
                }
            }
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(References.HowToPlayBG, new Rectangle(0f, 0f, References.HowToPlayBG.Width, References.HowToPlayBG.Height),
                new Rectangle(0f, 0f, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), System.Numerics.Vector2.Zero, 0f, Color.White);



            foreach (CreditsCard card in cards)
            {
                Raylib.DrawTextureEx(card.texture, new System.Numerics.Vector2(card.x, card.y), card.r, card.s, Color.White);
            }
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), new Color(0f, 0f, 0f, 0.8f));

            backButton.Render();

            int headerSize = 40;
            int nameSize = 30;
            int rowSpacing = 10;


            int column2 = 450;
            int column1 = 110;
            int column3 = 850;
            column2 += 50;

            int headerY = 200;
            int row1 = headerY + headerSize + rowSpacing;
            int row2 = row1 + headerSize + rowSpacing;


            Raylib.DrawText("Programming", column1, headerY, headerSize, Color.White);
            Raylib.DrawText("person 1", column1, row1, nameSize, Color.White);
            Raylib.DrawText("maya :)", column1, row2, nameSize, Color.White);

            Raylib.DrawText("Art", column2, headerY, headerSize, Color.White);
            Raylib.DrawText("person 3", column2, row1, nameSize, Color.White);

            Raylib.DrawText("Sound Design", column3, headerY, headerSize, Color.White);
            Raylib.DrawText("person 1", column3, row1, nameSize, Color.White);

            int cardRow = row2 + rowSpacing + 70;

            float cardScale = 1.5f;
            float cardWidth = References.The_Hermit.Width * cardScale;

            float sixth = Raylib.GetScreenWidth() / 6f;

            int c1x = (int)(sixth - (cardWidth / 2f)) + 20;
            Raylib.DrawTextureEx(References.The_Hermit, new System.Numerics.Vector2(c1x, cardRow), 0, cardScale, Color.White);

            int c2x = (int)((sixth * 3f) - (cardWidth / 2f));
            Raylib.DrawTextureEx(References.The_High_Priestess, new System.Numerics.Vector2(c2x, cardRow), 0, cardScale, Color.White);

            int c3x = (int)((sixth * 5f) - (cardWidth / 2f)) - 20;
            Raylib.DrawTextureEx(References.Judgement, new System.Numerics.Vector2(c3x, cardRow), 0, cardScale, Color.White);
        }
    }
}