using Raylib_cs;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.Animations
{
    public class PlayerDeathAnimation : Animation
    {
        public static int defaultLayer = 2;
        public PlayerDeathAnimation()
        {
            AudioReferences.PlaySound(AudioReferences.opponentDeath);
        }

        public override void Render()
        {
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), new Color(0f, 0f, 0f, 0.9f));
        }
    }
}
