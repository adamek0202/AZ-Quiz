using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Components
{
    internal class GameBoard_S : GameBoardBase
    {
        internal event Action<uint, HexTile>? TileClicked;
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
                    TileClicked?.Invoke((uint)i, tiles[i]);
                    break;
                }
            }
        }
    }
}
