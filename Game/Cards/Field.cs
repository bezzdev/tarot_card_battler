namespace tarot_card_battler.Game.Cards
{
    public class Field
    {
        public Card past;
        public Card present;
        public Card future;
        public void Update()
        {
        }

        public void Render()
        {
            if (past != null)
                past.Render();
            if (present != null)
                present.Render();
            if (future != null)
                future.Render();
        }
    }
}
