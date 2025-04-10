using Raylib_cs;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.Animations
{
    public class OpponentDeathAnimation : Animation
    {
        public static int defaultLayer = 2;

        public OpponentDeathAnimation()
        {
            AudioReferences.PlaySound(AudioReferences.opponentDeath);
            References.opponentDeathAnimation = this;
        }

        public override void Render()
        {
            Raylib.DrawTexture(References.OpponentShadow, 0, 0, Color.White);
        }
    }
}
