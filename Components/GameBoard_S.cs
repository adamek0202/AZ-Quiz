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
    internal partial class GameBoard_S : GameBoardBase
    {
        internal event Action<int, HexTile>? TileClicked;
        public GameBoard_S() : base(Properties.Resources.map_s, new Font("Segoe UI", 10, FontStyle.Bold))
        {
            MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                // K 'tiles' máme přístup, protože je v bázové třídě označená jako protected
                if (tiles[i].HitTest(e.Location) && tiles[i].State != TileManager.TileStates.Blocked)
                {
                    TileClicked?.Invoke(i, tiles[i]);
                    break;
                }
            }
        }
    }
}
