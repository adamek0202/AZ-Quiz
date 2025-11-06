using System;
using System.Drawing;

namespace AZ_Kviz
{
    internal static class TileManager
    {
        public static event Action<int, TileManager.TileStates> TileUpdated;
        
        public static void UpdateTile(int id, TileStates state)
        {
            TileUpdated?.Invoke(id - 1, state);
        }

        internal enum TileStates
        {
            Clear,
            FirtstPlayer_Used,
            SecondPlayer_Used,
            Incorrect,
            Blocked
        }
    }

        internal static class TileStatesExtensions
        {
            public static Color TileColor( this TileManager.TileStates s)
            {
                return s switch
                {
                    TileManager.TileStates.Clear => Color.WhiteSmoke,
                    TileManager.TileStates.FirtstPlayer_Used => Color.Orange,
                    TileManager.TileStates.SecondPlayer_Used => Color.DeepSkyBlue,
                    TileManager.TileStates.Incorrect => Color.Gray,
                    TileManager.TileStates.Blocked => Color.Black,
                    _ => Color.WhiteSmoke
                };
            }
        }
}
