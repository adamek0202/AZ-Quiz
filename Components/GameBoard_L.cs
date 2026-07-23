using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AZ_Kviz.Components
{
    internal partial class GameBoard_L : GameBoardBase
    {
        public GameBoard_L() : base(Properties.Resources.map_l, new Font("Arial", 20, FontStyle.Bold))
        {

        }
    }
}
