using System;
using System.IO;
using System.Media;

namespace AZ_Kviz
{
    internal static class SoundManager
    {
        private static readonly string SoundsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");

        public static void PlaySuccess() => Play("success.wav");
        public static void PlayFailure() => Play("failure.wav");
        public static void PlayTick() => Play("tick.wav");

        private static void Play(string fileName)
        {
            string fullPath = Path.Combine(SoundsPath, fileName);

            if (!File.Exists(fullPath)) return;

            try
            {
                using(SoundPlayer player = new SoundPlayer(fullPath))
                {
                    player.Play();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
