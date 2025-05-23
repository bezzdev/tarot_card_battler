using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class IndicatorAnimation : Animation
    {
        public static int defaultLayer = 1;
        public Delay deathTimer;
        private float duration = 1f;
        string indicatorValue = "";
        private Color color;

        public IndicatorAnimation(double x, double y, int indicatorValue, Color color)
        {
            this.indicatorValue = indicatorValue.ToString();
            this.position.x = x;
            this.position.y = y;
            this.color = color;
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

        public override void Render()
        {
            float time = deathTimer.time;
            float percent = time / duration;

            float amp = 0f;

            float growDuration = 1.5f;
            if (percent < growDuration)
            {
                amp = Math.Max(0, MathF.Sin(time / growDuration));
            }

            float growScale = 0.2f;
            float scale = 1f + (amp * growScale);

            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);

            float cardWidth = 146f;
            float cardHeight = 236f;

            float height = (cardHeight + 10f) * scale;

            int x = screen.x - (int) (cardWidth / 4);
            int y = screen.y - (int)(height / 2);

            Raylib.DrawText($"{indicatorValue}", x, y, 48, color);
        }

    }
}