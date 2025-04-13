using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Animations;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public static class References
    {
        public static bool exit;
        public static int window_width = 1200;
        public static int window_height = 800;

        public static EntityLayer world = new EntityLayer();
        public static OpponentDeathAnimation opponentDeathAnimation;

        public static float frameDelta;
        public static float gameSpeed = 1f;
        public static float delta
        {
            get
            {
                return frameDelta * gameSpeed;
            }
        }

        public static Texture2D sampleTexture;
        public static Image windowIcon;

        // cards
        public static Texture2D The_Fool;
        public static Texture2D The_Magician;
        public static Texture2D The_High_Priestess;
        public static Texture2D The_Empress;
        public static Texture2D The_Emperor;
        public static Texture2D The_Hierophant;
        public static Texture2D The_Lovers;
        public static Texture2D The_Chariot;
        public static Texture2D Strength;
        public static Texture2D The_Hermit;
        public static Texture2D Wheel_Of_Fortune;
        public static Texture2D Justice;
        public static Texture2D The_Hanged_Man;
        public static Texture2D Death;
        public static Texture2D Temperance;
        public static Texture2D The_Devil;
        public static Texture2D The_Tower;
        public static Texture2D The_Star;
        public static Texture2D The_Moon;
        public static Texture2D The_Sun;
        public static Texture2D Judgement;
        public static Texture2D The_World;

        // card backs
        public static Texture2D Back_Plain;
        public static Texture2D Back_Text;
        public static Texture2D Back_Marbled;
        public static Texture2D Back_Eye_Sigil;
        public static Texture2D Back_Eye_Sigil_Holo;

        // buttons
        public static Texture2D CastButton;
        public static Texture2D HoverButton; 
        public static Texture2D CastButtonInactive;
        public static Texture2D StartButton;
        public static Texture2D StartButtonHover;
        public static Texture2D HelpButton;
        public static Texture2D HelpButtonHover;
        public static Texture2D CreditsButton;
        public static Texture2D CreditsButtonHover;
        public static Texture2D QuitButton;
        public static Texture2D QuitButtonHover;
        public static Texture2D BackButton;
        public static Texture2D BackButtonHover;

        // menus
        public static Texture2D GameBackground;
        public static Texture2D MenuBackground;

        // cursor
        public static Texture2D Cursor;

        // candle
        public static Texture2D CandleBase;
        public static Texture2D CandleSegment;
        public static Texture2D CandleTop;
        public static Texture2D CandleTopOut;

        // stats
        public static Texture2D ShieldIcon;
        public static Texture2D WeaknessIcon;
        public static Texture2D StrengthIcon;
        public static Texture2D GoldIcon;
        public static Texture2D SkullIcon;

        // effects
        public static Texture2D NegateEffect;
        public static Texture2D OpponentShadow;
        public static Texture2D CardBurnEffect1;
        public static Texture2D CardBurnEffect2;
        public static Texture2D CardBurnEffect3;
        public static Texture2D CardBurnEffect4;
        public static Texture2D CardBurnEffect5;
        public static Texture2D CardBurnEffect6;

        // tutorial
        public static Texture2D HowToPlayBG;
        public static Texture2D TutorialImage1;
        public static Texture2D TutorialImage2;
        public static Texture2D TutorialImage3;
        public static Texture2D TutorialImage4;
        public static Texture2D TutorialImage5;

        public static void Load()
        {
            sampleTexture = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/SingleCardDraft.png"));
            windowIcon = Raylib.LoadImage("Game/Res/AppIcon.png");

            // load textures
            The_Fool = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/00_The_Fool.png"));
            The_Magician = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/01_The_Magician.png"));
            The_High_Priestess = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/02_The_High_Priestess.png"));
            The_Empress = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/03_The_Empress.png"));
            The_Emperor = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/04_The_Emperor.png"));
            The_Hierophant = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/05_The_Hierophant.png"));
            The_Lovers = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/06_The_Lovers.png"));
            The_Chariot = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/07_The_Chariot.png"));
            Strength = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/08_Strength.png"));
            The_Hermit = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/09_The_Hermit.png"));
            Wheel_Of_Fortune = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/10_Wheel_Of_Fortune.png"));
            Justice = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/11_Justice.png"));
            The_Hanged_Man = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/12_The_Hanged_Man.png"));
            Death = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/13_Death.png"));
            Temperance = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/14_Temperance.png"));
            The_Devil = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/15_The_Devil.png"));
            The_Tower = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/16_The_Tower.png"));
            The_Star = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/17_The_Star.png"));
            The_Moon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/18_The_Moon.png"));
            The_Sun = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/19_The_Sun.png"));
            Judgement = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/20_Judgement.png"));
            The_World = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/21_The_World.png"));

            Back_Plain = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cardbacks/Back_Plain.png"));
            Back_Text = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cardbacks/Back_Text.png"));
            Back_Marbled = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cardbacks/Back_Marbled.png"));
            Back_Eye_Sigil = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cardbacks/Back_Eye_Sigil.png"));
            Back_Eye_Sigil_Holo = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cardbacks/Back_Eye_Sigil_Holo.png"));

            CastButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Button_Cast_Default.png"));
            HoverButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Button_Cast_Hover.png"));
            CastButtonInactive = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Button_Cast_Inactive.png"));

            StartButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Start_Default.png"));
            StartButtonHover = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Start_Hover.png"));
            HelpButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Help_Default.png"));
            HelpButtonHover = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Help_Hover.png"));
            CreditsButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Credits_Default.png"));
            CreditsButtonHover = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Credits_Hover.png"));
            QuitButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Quit_Default.png"));
            QuitButtonHover = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Quit_Hover.png"));
            BackButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Back_Default.png"));
            BackButtonHover = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Menu/Button_Back_Hover.png"));

            GameBackground = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Board.png"));
            MenuBackground = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/MenuBG.png"));

            Cursor = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cursor.png"));

            CandleBase = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Candle/CandleBase.png"));
            CandleSegment = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Candle/CandleSegment.png"));
            CandleTop = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Candle/CandleTop.png"));
            CandleTopOut = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Candle/CandleTopOut.png"));

            ShieldIcon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Shield.png"));
            StrengthIcon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Strength.png"));
            WeaknessIcon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Weakness.png"));
            GoldIcon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Gold.png"));
            SkullIcon = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Skull.png"));

            NegateEffect = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/negate_effect.png"));
            OpponentShadow = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/opponent_shadow.png"));
            CardBurnEffect1 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_1.png"));
            CardBurnEffect2 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_2.png"));
            CardBurnEffect3 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_3.png"));
            CardBurnEffect4 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_4.png"));
            CardBurnEffect5 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_5.png"));
            CardBurnEffect6 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Effects/burn_effect_6.png"));

            HowToPlayBG = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/HowToPlayBG.png"));
            TutorialImage1 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/SelectCard.png"));
            TutorialImage2 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/CastFate.png"));
            TutorialImage3 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/CardEffects.png"));
            TutorialImage4 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/PlayerStats.png"));
            TutorialImage5 = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/HowToPlay/CandleOut.png"));

            CardList.cards = CardList.GetAllCards();
        }
    }
}
