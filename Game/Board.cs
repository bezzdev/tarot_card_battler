namespace tarot_card_battler.Game
{
    public class Board
    {
        public PlayerBoard player;
        public List<PlayerBoard> players = new List<PlayerBoard>();
        
        public void Update()
        {
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
            foreach (PlayerBoard player in players)
            {
                player.Render();
            }
        }
    }
}