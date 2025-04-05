namespace tarot_card_battler.Core
{
    public class Delay
    {
        private float time;
        private float goal;

        public Delay(float goal)
        {
            this.goal = goal;
        }

        public void Update(float delta)
        {
            time += delta;
        }


        public bool Completed()
        {
            return time >= goal;
        }
    }
}
