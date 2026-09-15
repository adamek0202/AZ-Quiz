using System;
using System.Collections.Generic;

namespace AZ_Kviz
{
    internal static class WinChecker
    {
        // Indexy políček tvořících okraje trojúhelníku (0 až 27)
        private static readonly HashSet<int> LeftEdge = new HashSet<int> { 0, 1, 3, 6, 10, 15, 21 };
        private static readonly HashSet<int> RightEdge = new HashSet<int> { 0, 2, 5, 9, 14, 20, 27 };
        private static readonly HashSet<int> BottomEdge = new HashSet<int> { 21, 22, 23, 24, 25, 26, 27 };

        // Definice sousedů pro každé z 28 políček (podle jejich indexu 0-27)
        private static readonly int[][] Neighbors = new int[][]
        {
            /* 0 (1) */  new int[] { 1, 2 },
            /* 1 (2) */  new int[] { 0, 2, 3, 4 },
            /* 2 (3) */  new int[] { 0, 1, 4, 5 },
            /* 3 (4) */  new int[] { 1, 4, 6, 7 },
            /* 4 (5) */  new int[] { 1, 2, 3, 5, 7, 8 },
            /* 5 (6) */  new int[] { 2, 4, 8, 9 },
            /* 6 (7) */  new int[] { 3, 7, 10, 11 },
            /* 7 (8) */  new int[] { 3, 4, 6, 8, 11, 12 },
            /* 8 (9) */  new int[] { 4, 5, 7, 9, 12, 13 },
            /* 9 (10) */ new int[] { 5, 8, 13, 14 },
            /* 10 (11) */ new int[] { 6, 11, 15, 16 },
            /* 11 (12) */ new int[] { 6, 7, 10, 12, 16, 17 },
            /* 12 (13) */ new int[] { 7, 8, 11, 13, 17, 18 },
            /* 13 (14) */ new int[] { 8, 9, 12, 14, 18, 19 },
            /* 14 (15) */ new int[] { 9, 13, 19, 20 },
            /* 15 (16) */ new int[] { 10, 16, 21, 22 },
            /* 16 (17) */ new int[] { 10, 11, 15, 17, 22, 23 },
            /* 17 (18) */ new int[] { 11, 12, 16, 18, 23, 24 },
            /* 18 (19) */ new int[] { 12, 13, 17, 19, 24, 25 },
            /* 19 (20) */ new int[] { 13, 14, 18, 20, 25, 26 },
            /* 20 (21) */ new int[] { 14, 19, 26, 27 },
            /* 21 (22) */ new int[] { 15, 22 },
            /* 22 (23) */ new int[] { 15, 16, 21, 23 },
            /* 23 (24) */ new int[] { 16, 17, 22, 24 },
            /* 24 (25) */ new int[] { 17, 18, 23, 25 },
            /* 25 (26) */ new int[] { 18, 19, 24, 26 },
            /* 26 (27) */ new int[] { 19, 20, 25, 27 },
            /* 27 (28) */ new int[] { 20, 26 }
        };

        /// <summary>
        /// Zkontroluje, zda daný stav políčka (hráč) spojil všechny 3 strany trojúhelníku.
        /// </summary>
        public static bool CheckWin(List<HexTile> tiles, TileManager.TileStates playerState)
        {
            // Validace, zda kontrolujeme hráče 1 nebo hráče 2
            if (playerState != TileManager.TileStates.FirstPlayer_Used &&
                playerState != TileManager.TileStates.SecondPlayer_Used)
                return false;

            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            bool hitLeft = false;
            bool hitRight = false;

            // 1. Najdeme všechna políčka na SPODNÍ hraně, která patří kontrolovanému hráči
            foreach (int index in BottomEdge)
            {
                if (index < tiles.Count && tiles[index].State == playerState)
                {
                    queue.Enqueue(index);
                    visited.Add(index);
                }
            }

            // Pokud hráč nemá obsazené ani jedno políčko na spodní řadě, nemohl spojit všechny tři strany
            if (queue.Count == 0) return false;

            // 2. Prohledávání do šířky (BFS) - "rozlévání vody"
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                // Kontrola, zda jsme vlnou narazili na levou nebo pravou stranu
                if (LeftEdge.Contains(current)) hitLeft = true;
                if (RightEdge.Contains(current)) hitRight = true;

                // Pokud jsme během rozlévání ze spodu už dosáhli na levou i pravou stranu -> máme vítěze!
                if (hitLeft && hitRight) return true;

                // Projdeme všechny sousedy aktuálního políčka
                foreach (int neighbor in Neighbors[current])
                {
                    // Do fronty přidáme souseda pouze pokud:
                    // - jsme ho ještě nenavštívili
                    // - patří stejnému hráči
                    if (!visited.Contains(neighbor) && neighbor < tiles.Count && tiles[neighbor].State == playerState)
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return false;
        }
    }
}