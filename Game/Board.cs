namespace tarot_card_battler.Game
{

    public class Board
    {
        public List<PlayerBoard> players = new List<PlayerBoard>();
        public void Render()
        {
            foreach (PlayerBoard player in players)
            {
                player.Render();
            }
        }
    }
}