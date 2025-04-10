using Raylib_cs;
using System.Numerics;
using tarot_card_battler.Game.Effects;

namespace tarot_card_battler.Game.Sounds
{
    public static class MusicHandler
    {

        public static List<Sound> tracks = new List<Sound>();
        public static Sound currentTrack;
        public static bool muted;


        public static void RegisterTrack(Sound music)
        {
            tracks.Add(music);
        }
        public static void Update()
        {
            //int p = Raylib.GetCharPressed();
            //if (p != 0)
            //    Console.WriteLine(p);

            if (!Raylib.IsSoundPlaying(currentTrack))
            {
                Play();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.M))
            {
                Console.WriteLine("M");
                muted = !muted;
                Raylib.SetMasterVolume(muted ? 0f : 1f);
            }
        }

        public static void Play()
        {
            currentTrack = GetNextTrack();
            Raylib.PlaySound(currentTrack);
        }

        public static Sound GetNextTrack()
        {
            int choice = Random.Shared.Next(0, tracks.Count);
            return tracks[choice];
        }
    }
}
