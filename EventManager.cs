using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal static class EventManager
    {
        internal static event Action<int, TileManager.TileStates>? UpdateField;
    }
}
