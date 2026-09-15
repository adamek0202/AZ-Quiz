using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace AZ_Kviz
{
    internal static class SoundManager
    {
        private static readonly string SoundsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        private static readonly Dictionary<string, SoundPlayer> Players = new Dictionary<string, SoundPlayer>();

        public static void PlaySuccess() => Play("success.wav");
        public static void PlayFailure() => Play("failure.wav");
        public static void PlayTick() => Play("tick.wav");

        private static void Play(string fileName)
        {
            string fullPath = Path.Combine(SoundsPath, fileName);

            if (!File.Exists(fullPath)) return;

            try
            {
                if (!Players.TryGetValue(fileName, out var player))
                {
                    player = new SoundPlayer(fullPath);
                    player.Load();
                    Players[fileName] = player;
                }
                player.Play();
            }
            catch (Exception ex)
            {
                Serilog.Log.Warning($"Nelze přehrát zvuk '{fileName}': {ex.Message}");
            }
        }
    }
}
