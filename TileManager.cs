using System;
using System.Drawing;

namespace AZ_Kviz
{
    internal static class TileManager
    {
        internal enum TileStates
        {
            Clear,
            FirtstPlayer_Used,
            SecondPlayer_Used,
            Incorrect,
            Blocked
        }

        internal struct Colors
        {
            public static Color PlayerOneColor { get; set; }
            public static Color PlayerTwoColor { get; set; }
        }
    }

        internal static class TileStatesExtensions
        {
            public static Color TileColor( this TileManager.TileStates s)
            {
                return s switch
                {
                    TileManager.TileStates.Clear => Color.WhiteSmoke,
                    TileManager.TileStates.FirtstPlayer_Used => TileManager.Colors.PlayerOneColor,
                    TileManager.TileStates.SecondPlayer_Used => TileManager.Colors.PlayerTwoColor,
                    TileManager.TileStates.Incorrect => Color.Gray,
                    TileManager.TileStates.Blocked => Color.Black,
                    _ => Color.WhiteSmoke
                };
            }
        }
}
