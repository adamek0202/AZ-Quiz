using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal static class Player
    {
        public enum Players
        {
            PlayerOne,
            PlayerTwo
        }
        public static Players currentPlayer { get; private set; } = Players.PlayerOne;

        public static void NextPlayer()
        {
            currentPlayer = (currentPlayer == Players.PlayerOne) ? Players.PlayerTwo : Players.PlayerOne;
        }
    }
}
