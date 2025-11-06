using System;
using System.Collections.Generic;

namespace AZ_Kviz
{
    internal static partial class Player
    {
        public enum Players
        {
            PlayerOne,
            PlayerTwo
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

        public static void UpdateStats()
        {
            StatsChanged?.Invoke();
        }

        public class Stats
        {
            public int Correct { get; set; }
            public int Incorrect { get; set; }
        }

        internal static readonly Dictionary<Players, Stats> PlayerStats = new Dictionary<Players, Stats>()
        {
            { Players.PlayerOne, new Stats() },
            { Players.PlayerTwo, new Stats() }
        };
    }

    internal static partial class PlayerExtensions
    {
        public static string GetText(this Player.Players s)
        {
            return s switch
            {
                Player.Players.PlayerOne => "Hráč 1",
                Player.Players.PlayerTwo => "Hráč 2",
                _ => ""
            };
        }

        public static Player.Stats Stats(this Player.Players s)
        {
            return Player.PlayerStats[s];
        }
    }
}
