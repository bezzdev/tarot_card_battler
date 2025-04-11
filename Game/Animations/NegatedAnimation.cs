using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Sounds;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class NegatedAnimation : Animation
    {
        public static int defaultLayer = 1;
        public Delay deathTimer;

        public NegatedAnimation(double x, double y)
        {
            this.position.x = x;
            this.position.y = y;
            deathTimer = new Delay(duration);
            AudioReferences.PlaySound(AudioReferences.negated);
        }

        public override void Update()
        {
            deathTimer.Update(References.delta);

            if (deathTimer.CompletedOnce())
            {
                destroyed = true;
            }
        }

        private float duration = 0.5f;

        public override void Render()
        {
            float p = deathTimer.time / duration;
            p = 1f - (1f - p) * (1f - p);

            float a = (0.2f + (p * 0.6f));

            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            float scaleStart = 0.95f;
            float scaleEnd = 1.02f;
            float scale = scaleStart + (p * (scaleEnd - scaleStart));
            float width = References.NegateEffect.Width * scale;
            float height = References.NegateEffect.Height * scale;
            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);
            Raylib.DrawTextureEx(References.NegateEffect, new System.Numerics.Vector2(x, y), 0f, scale, new Color(1f, 0f, 0f, a));
        }
    }
}
