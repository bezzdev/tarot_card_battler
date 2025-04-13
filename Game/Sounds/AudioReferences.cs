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
        public static Sound opponentDeath;
        public static Sound playerDeath;
        public static Sound lightCandle;
        public static Sound negated;
        public static Sound cardBurn;

        public static Sound music_1;
        public static Sound music_2;
        public static void Load()
        {
            cardDraw = Raylib.LoadSound("Game/Res/Sounds/card_draw.wav");
            cardSet = Raylib.LoadSound("Game/Res/Sounds/card_set.wav");
            buttonHover = Raylib.LoadSound("Game/Res/Sounds/button_hover.wav");
            buttonClick = Raylib.LoadSound("Game/Res/Sounds/button_click.wav");
            castButtonClick = Raylib.LoadSound("Game/Res/Sounds/cast_button_click.wav");
            castButtonClick = Raylib.LoadSound("Game/Res/Sounds/cast_button_click.mp3");
            Raylib.SetSoundPitch(castButtonClick, 0.9f);
            Raylib.SetSoundVolume(castButtonClick, 1f);
            cardEffectActivate = Raylib.LoadSound("Game/Res/Sounds/card_effect_activate.wav");
            Raylib.SetSoundVolume(cardEffectActivate, 0.1f);
            Raylib.SetSoundPitch(cardEffectActivate, 0.6f);
            negated = Raylib.LoadSound("Game/Res/Sounds/negated.wav");
            cardBurn = Raylib.LoadSound("Game/Res/Sounds/card_burn.wav");
            Raylib.SetSoundVolume(cardBurn, 0.2f);
            Raylib.SetSoundPitch(cardBurn, 0.8f);

            opponentDeath = Raylib.LoadSound("Game/Res/Sounds/opponent_death.wav");
            Raylib.SetSoundVolume(opponentDeath, 0.1f);
            playerDeath = Raylib.LoadSound("Game/Res/Sounds/player_death.wav");
            Raylib.SetSoundVolume(opponentDeath, 0.4f);

            lightCandle = Raylib.LoadSound("Game/Res/Sounds/light_candle.wav");

            music_1 = Raylib.LoadSound("Game/Res/Sounds/music_1.mp3");
            Raylib.SetSoundVolume(music_1, 0.07f);
            MusicHandler.RegisterTrack(music_1);

            music_2 = Raylib.LoadSound("Game/Res/Sounds/music_2.mp3");
            Raylib.SetSoundVolume(music_2, 0.07f);
            MusicHandler.RegisterTrack(music_2);
        }

        public static void PlaySound(Sound sound)
        {
            Raylib.PlaySound(sound);
        }
    }
}
