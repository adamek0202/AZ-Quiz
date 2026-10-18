using System.Drawing;

namespace AZ_Kviz
{
    internal static class TileManager
    {
        internal enum TileStates
        {
            Clear,
            FirstPlayer_Used,
            SecondPlayer_Used,
            Incorrect,
            Blocked
        }

    }

    internal static class TileStatesExtensions
    {
        public static Color TileColor(this TileManager.TileStates s, Color playerOneColor, Color playerTwoColor)
        {
            return s switch
            {
                TileManager.TileStates.Clear => Color.WhiteSmoke,
                TileManager.TileStates.FirstPlayer_Used => playerOneColor,
                TileManager.TileStates.SecondPlayer_Used => playerTwoColor,
                TileManager.TileStates.Incorrect => Color.Gray,
                TileManager.TileStates.Blocked => Color.Black,
                _ => Color.WhiteSmoke
            };
        }
    }
}
