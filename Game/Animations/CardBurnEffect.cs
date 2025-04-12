using Raylib_cs;
using System;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Animations
{
    public class CardBurnEffect : Animation
    {
        public static int defaultLayer = 1;
        public Delay deathTimer;
        public bool end;
        public float split = 0.375f;
        private Texture2D texture;

        public CardBurnEffect(double x, double y, int version)
        {
            this.position.x = x;
            this.position.y = y;
            deathTimer = new Delay(duration);

            texture = GetTexture(version);
        }

        public Texture2D GetTexture(int version)
        {
            if (version == 0)
                return References.CardBurnEffect1;
            else if (version == 1)
                return References.CardBurnEffect2;
            else if (version == 2)
                return References.CardBurnEffect3;
            else if (version == 3)
                return References.CardBurnEffect4;
            else if (version == 4)
                return References.CardBurnEffect5;
            else if (version == 5)
                return References.CardBurnEffect6;
            return References.CardBurnEffect1;
        }
        public override void Update()
        {
            if (deathTimer.time < split || end)
                deathTimer.Update(References.delta);

            if (deathTimer.CompletedOnce())
            {
                destroyed = true;
            }
        }

        private float duration = 1f;

        public override void Render()
        {
            int totalFrames = 24;
            float percent = deathTimer.time / duration;
            // percent = 1f - ((1f - percent) * (1f - percent));
            int frame = (int)MathF.Round(percent * totalFrames, MidpointRounding.ToZero); 

            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            float width = References.CardBurnEffect1.Width / totalFrames;
            float height = References.CardBurnEffect1.Height;
            int x = screen.x - (int)(width / 2);
            int y = screen.y - (int)(height / 2);

            float alpha = 1f;
            Color col = new Color(1f, 1f, 1f, alpha);
            Raylib.DrawTextureRec(texture, new Rectangle(new System.Numerics.Vector2(frame * width, 0), width, height), new System.Numerics.Vector2(x, y), col);
        }
    }
}
