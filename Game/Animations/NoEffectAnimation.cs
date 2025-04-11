using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Sounds;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class NoEffectAnimation : Animation
    {
        public static int defaultLayer = -1;
        public Delay deathTimer;
        public Color color;

        public NoEffectAnimation(double x, double y, Color col)
        {
            this.position.x = x;
            this.position.y = y;
            this.color = col;
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

        private float duration = 0.2f;

        public override void Render()
        {
            float scale = 1f;

            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);

            float cardWidth = 146f;
            float cardHeight = 236f;

            float width = (cardWidth + 10f) * scale;
            float height = (cardHeight + 10f) * scale;

            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);

            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
        }
    }
}
