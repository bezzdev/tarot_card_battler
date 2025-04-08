using Raylib_cs;

namespace tarot_card_battler.Game.Sounds
{
    public static class AudioReferences
    {
        public static Sound cardDraw;
        public static Sound cardSet;
        public static Sound buttonHover;
        public static Sound buttonClick;
        public static Sound castButtonClick;
        public static Sound cardEffectActivate; 
        public static void Load()
        {
            cardDraw = Raylib.LoadSound("Game/Res/Sounds/card_draw.wav");
            cardSet = Raylib.LoadSound("Game/Res/Sounds/card_set.wav");
            buttonHover = Raylib.LoadSound("Game/Res/Sounds/button_hover.wav");
            buttonClick = Raylib.LoadSound("Game/Res/Sounds/button_click.wav");
            castButtonClick = Raylib.LoadSound("Game/Res/Sounds/cast_button_click.wav");
            Raylib.SetSoundVolume(castButtonClick, 0.5f);
            cardEffectActivate = Raylib.LoadSound("Game/Res/Sounds/card_effect_activate.wav");
            Raylib.SetSoundVolume(cardEffectActivate, 0.1f);
            Raylib.SetSoundPitch(cardEffectActivate, 0.7f);
        }

        public static void PlaySound(Sound sound)
        {
            Raylib.PlaySound(sound);
        }
    }
}
