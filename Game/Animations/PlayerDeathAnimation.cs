using Raylib_cs;

namespace tarot_card_battler.Game.Animations
{
    public class PlayerDeathAnimation : Animation
    {
        public static int defaultLayer = 2;

        public override void Render()
        {
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Color.Black);
        }
    }
}
