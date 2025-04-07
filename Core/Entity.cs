namespace tarot_card_battler.Core
{
    public class Entity
    {
        public int layer = 0;
        public Coord position = new Coord(0, 0);
        public bool destroyed;

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
        }
    }
}
