using System;
using System.Collections.Generic;

namespace AZ_Kviz
{
    internal static class Player
    {
        public enum Players
        {
            PlayerOne,
            PlayerTwo
        }
        public class PlayerData
        {
            public string Name { get; set; }
            public int Correct { get; set; }
            public int Incorrect { get; set; }
            public int Points => Correct + Incorrect;

            public PlayerData(string defaultName)
            {
                Name = defaultName;
            }
        }

        public static Players CurrentPlayer { get; private set; } = Players.PlayerOne;
        public static Players OtherPlayer => (CurrentPlayer == Players.PlayerOne) ? Players.PlayerTwo : Players.PlayerOne;

        public static event Action PlayerChanged;
        public static event Action StatsChanged;
        
        public static void NextPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Players.PlayerOne) ? Players.PlayerTwo : Players.PlayerOne;
            PlayerChanged?.Invoke();
        }

        public static void UpdateStats() => StatsChanged?.Invoke();

        public static void ResetScore()
        {
            CurrentPlayer = Players.PlayerOne;
            foreach (var data in PlayerRegistry.Values)
            {
                data.Correct = 0;
                data.Incorrect = 0;
            }
            PlayerChanged?.Invoke();
            StatsChanged?.Invoke();
        }

        internal static readonly Dictionary<Players, PlayerData> PlayerRegistry = new Dictionary<Players, PlayerData>
        {
            { Players.PlayerOne, new PlayerData("Hráč 1") },
            { Players.PlayerTwo, new PlayerData("Hráč 2") }
        };

        public static void SetPlayerNames(string firstPlayer, string secondPlayer)
        {
            if (!string.IsNullOrWhiteSpace(firstPlayer)) PlayerRegistry[Players.PlayerOne].Name = firstPlayer;
            if (!string.IsNullOrWhiteSpace(secondPlayer)) PlayerRegistry[Players.PlayerTwo].Name = secondPlayer;

            StatsChanged?.Invoke();
        }
    }

    internal static partial class PlayerExtensions
    {
        public static string GetName(this Player.Players s) => Player.PlayerRegistry[s].Name;

        public static Player.PlayerData Stats(this Player.Players s) => Player.PlayerRegistry[s];
    }
}
