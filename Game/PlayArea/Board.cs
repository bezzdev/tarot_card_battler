using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.PlayArea
{
    public class Board
    {
        public PlayerBoard player;
        public List<PlayerBoard> players = new List<PlayerBoard>();

        public Button castButton = new Button()
        {
            clickSound = AudioReferences.castButtonClick,
            hoverTexture = References.HoverButton,
            baseTexture = References.CastButton,
            position = new Coord(600, 400)
        };

        public void Update()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            castButton.buttonIsHovered = castButton.IsInBounds(x, y);

            foreach (PlayerBoard player in players)
            {
                player.Update();
            }
        }

        public void EarlyRender()
        {
            foreach (PlayerBoard player in players)
            {
                player.EarlyRender();
            }
        }

        public void Render()
        {
            castButton.Render();

            foreach (PlayerBoard player in players)
            {
                player.Render();
            }
        }
    }
}