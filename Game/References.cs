using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;

namespace tarot_card_battler.Game
{
    public static class References
    {
        public static int window_width = 1200;
        public static int window_height = 800;

        public static World world = new World();
        public static Player player = new Player() { size = 1};
        public static Controller controller = new Controller(player);

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

        public static Texture2D CastButton;
        public static Texture2D HoverButton; 
        public static Texture2D GameBackground; 

        public static void Load()
        {

            sampleTexture = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/SingleCardDraft.png"));

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

            CastButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Button_Cast_Default.png"));
            HoverButton = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Cards/Button_Cast_Hover.png"));

            GameBackground = Raylib.LoadTextureFromImage(Raylib.LoadImage("Game/Res/Board.png"));

            CardList.cards = CardList.GetAllCards();
        }
    }
}
