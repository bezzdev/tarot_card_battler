using Raylib_cs;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game
{
    public class InteractionManager
    {
        public Board board;
        
        public Card? hoveredCard;
        public static InteractionManager instance;

        public InteractionManager(Board board)
        {
            this.board = board;
            instance = this;
        }

        private List<Card> hoverableCards = new List<Card>();
        public void Update() {

            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();

            var screen = Coordinates.ScreenToWorld(x, y);
            
            hoverableCards.Clear();
            hoverableCards.AddRange(board.player.hand.cards);
            foreach (PlayerBoard player in board.players)
            {
                if (player.field.past.card != null)
                    hoverableCards.Add(player.field.past.card);
                if (player.field.present.card != null)
                    hoverableCards.Add(player.field.present.card);
                if (player.field.future.card != null)
                    hoverableCards.Add(player.field.future.card);
            }

            hoveredCard = Intersections.GetHoveredCard(hoverableCards, screen.x, screen.y);
        }
    }
}
