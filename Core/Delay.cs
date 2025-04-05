namespace tarot_card_battler.Core
{
    public class Delay
    {
        public float time;
        private float goal;
        private bool resolved;
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
        public bool CompletedOnce()
        {
            if (!resolved && time >= goal)
            {
                resolved = true;    
                return true;
            }
            return false;
        }
    }
}
