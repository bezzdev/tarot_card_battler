using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class CardActivateAnimation : Animation
    {
        public static int defaultLayer = -1;
        public Delay deathTimer = new Delay(1f);

        public CardActivateAnimation(double x, double y)
        {
            this.position.x = x;
            this.position.y = y;
        }

        public override void Update()
        {
            deathTimer.Update(References.delta);

            if (deathTimer.CompletedOnce())
            {
                destroyed = true;
            }
        }

        public override void Render()
        {
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);

            float cardWidth = 146f;
            float cardHeight = 236f;

            float width = cardWidth + 10f;
            float height = cardHeight + 10f;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);

            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, Color.Yellow);
        }
    }
}
