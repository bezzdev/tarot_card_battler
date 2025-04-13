using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.GameLoop;
using tarot_card_battler.Game.PlayArea;
using tarot_card_battler.Game.Sounds;

namespace tarot_card_battler.Game.Animations
{
    public class PlayerDeathAnimation : Animation
    {
        public static int defaultLayer = 2;
        private Delay delay = new Delay(3f);
        public PlayerDeathAnimation()
        {
            AudioReferences.PlaySound(AudioReferences.playerDeath);
        }
        public override void Update()
        {
            delay.Update(References.delta);
        }

        public override void Render()
        {
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), new Color(0f, 0f, 0f, 0.9f));

            float gameOverPercent = Math.Clamp(delay.time / 1f, 0f, 1f);
            Color gameOverTextColor = new Color(1f, 1f, 1f, gameOverPercent);
            string gameOverText = "Game Over";
            int gameOverFontSize = 80;
            int gameOverX = (References.window_width / 2) - (Raylib.MeasureText(gameOverText, gameOverFontSize) / 2);
            Raylib.DrawText(gameOverText, gameOverX, (References.window_height / 2) - gameOverFontSize, gameOverFontSize, gameOverTextColor);

            float amp = (0.25f * MathF.Sin(delay.time * 2f)) + 0.5f;
            float continuePercent = Math.Clamp((delay.time - 1.5f) / 1f, 0f, 1f);
            Color continueTextColor = new Color(1f, 1f, 1f, continuePercent * amp);
            string continueText = "Continue?";
            int continueFontSize = 50;
            int continueX = (References.window_width / 2) - (Raylib.MeasureText(continueText, continueFontSize) / 2);
            Raylib.DrawText(continueText, continueX, References.window_height / 2 + 40, continueFontSize, continueTextColor);
        }
    }
}
