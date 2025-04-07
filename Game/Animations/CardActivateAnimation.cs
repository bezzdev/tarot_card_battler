using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class CardActivateAnimation : Animation
    {
        public static int defaultLayer = -1;
        public Delay deathTimer;

        public CardActivateAnimation(double x, double y)
        {
            this.position.x = x;
            this.position.y = y;
            deathTimer = new Delay(duration);
        }

        public override void Update()
        {
            deathTimer.Update(References.delta);

            if (deathTimer.CompletedOnce())
            {
                destroyed = true;
            }
        }

        private float duration = 1f;

        public override void Render()
        {
            float time = deathTimer.time;
            float percent = time / duration;

            float amp = 0f;

            float growDuration = 0.2f;
            if (percent < growDuration)
            {
                amp = Math.Max(0, MathF.Sin(time/ growDuration));
            }

            float growScale = 0.2f;
            float scale = 1f + (amp * growScale);

            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);

            float cardWidth = 146f;
            float cardHeight = 236f;

            float width = (cardWidth + 10f) * scale;
            float height = (cardHeight + 10f) * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);

            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, new Color(1f, 0.8f, 0f, 0.6f));
        }
    }
}
