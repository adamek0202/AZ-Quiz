using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal static class TileManager
    {
        public static List<HexTile> HexTiles { get; }

        internal enum TileStates
        {
            Clear,
            FirtstPlayer_Used,
            SecondPlayer_Used,
            Incorrect,
            Blocked
        }
    }
}
