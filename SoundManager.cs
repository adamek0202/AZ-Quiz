using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace AZ_Kviz
{
    internal static class SoundManager
    {
        private enum Sounds
        {
            Tick,
            Success,
            Failure
        }
        private static readonly string SoundsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        private static readonly Dictionary<string, SoundPlayer> Players = new Dictionary<string, SoundPlayer>();
        private static readonly Dictionary<Sounds, string> AudioFiles = new Dictionary<Sounds, string>()
        {
            { Sounds.Tick, "tick.wav"},
            { Sounds.Success, "success.wav" },
            { Sounds.Failure, "failure.wav" }
        };

        public static void PlaySuccess() => Play(Sounds.Success);
        public static void PlayFailure() => Play(Sounds.Failure);
        public static void PlayTick() => Play(Sounds.Tick);

        private static void Play(Sounds sound)
        {
            if (!AudioFiles.TryGetValue(sound, out var fileName)) return;

            string fullPath = Path.Combine(SoundsPath, fileName);

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
                Log.Warning($"Nelze přehrát zvuk '{fileName}': {ex.Message}");
            }
        }

        public static void CheckAudioFiles()
        {
            if (!Directory.Exists(SoundsPath))
            {
                Log.Error("Složka se zvuky neexistuje");
            }

            foreach(var file in AudioFiles.Values)
            {
                string fullPath = Path.Combine(SoundsPath, file);
                if (!File.Exists(fullPath))
                {
                    Log.Warning($"Chybí zvukový soubor: {file}");
                }
            }
        }
    }
}
