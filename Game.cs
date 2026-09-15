using System;
using System.Drawing;

namespace AZ_Kviz
{
    internal static class Game
    {
        // Reálné objekty obou hráčů
        public static Player PlayerOne { get; private set; }
        public static Player PlayerTwo { get; private set; }

        // Kdo je zrovna na tahu
        public static Player CurrentPlayer { get; private set; }

        public static event Action? PlayerChanged;
        public static event Action? StatsChanged;

        // Inicializace na začátku (volá se z MyAppContext)
        public static void Init(string p1Name, Color p1Color, string p2Name, Color p2Color)
        {
            PlayerOne = new Player(p1Name, p1Color);
            PlayerTwo = new Player(p2Name, p2Color);
            CurrentPlayer = PlayerOne;

            // Propojení barev hráčů s vykreslováním políček
            TileManager.Colors.PlayerOneColor = p1Color;
            TileManager.Colors.PlayerTwoColor = p2Color;

            PlayerChanged?.Invoke();
            StatsChanged?.Invoke();
        }

        // Vrátí hráče, který zrovna nehraje (pro případ náhradních otázek)
        public static Player OtherPlayer => (CurrentPlayer == PlayerOne) ? PlayerTwo : PlayerOne;

        public static void NextPlayer()
        {
            CurrentPlayer = (CurrentPlayer == PlayerOne) ? PlayerTwo : PlayerOne;
            PlayerChanged?.Invoke();
        }

        public static void UpdateStats()
        {
            StatsChanged?.Invoke();
        }

        public static void ResetScore()
        {
            PlayerOne?.Reset();
            PlayerTwo?.Reset();
            CurrentPlayer = PlayerOne;

            PlayerChanged?.Invoke();
            StatsChanged?.Invoke();
        }
    }
}