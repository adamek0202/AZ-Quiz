using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AZ_Kviz
{
    public partial class GameBoard_L : Control
    {
        private readonly List<HexTile> tiles = new List<HexTile>();
        private readonly Font labelFont = new Font("Arial", 20, FontStyle.Bold);

        public GameBoard_L()
        {
            InitializeComponent();
            DoubleBuffered = true;
            LoadSvg();
            TileManager.TileUpdated += TileManager_TileUpdated;
        }

        private void TileManager_TileUpdated(int id, TileManager.TileStates state)
        {
            SetTileColor(id, state.TileColor());
            tiles[id].State = state;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var tile in tiles)
            {
                tile.Draw(pe.Graphics, labelFont);
            }
        }

        public void Reset()
        {
            foreach(var item in tiles)
            {
                item.FillColor = Color.White;
            }
            Invalidate();
        }

        private void LoadSvg()
        {
            var stream = new MemoryStream(Properties.Resources.map_l);
            XDocument doc = XDocument.Load(stream);
            XNamespace ns = "http://www.w3.org/2000/svg";

            int index = 1;

            foreach (var polygon in doc.Descendants(ns + "polygon"))
            {
                string pointsAttr = polygon.Attribute("points")?.Value;
                if (string.IsNullOrWhiteSpace(pointsAttr)) continue;

                var points = pointsAttr
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, i) => new { s, i })
                    .GroupBy(x => x.i / 2)
                    .Select(g => new PointF(
                        float.Parse(g.ElementAt(0).s, CultureInfo.InvariantCulture),
                        float.Parse(g.ElementAt(1).s, CultureInfo.InvariantCulture)))
                    .ToArray();

                tiles.Add(new HexTile
                {
                    Points = points,
                    Label = index.ToString()
                });

                index++;
            }
        }

        public void SetTileColor(int index, Color color)
        {
            if (index >= 0 && index < tiles.Count)
            {
                tiles[index].FillColor = color;
                Invalidate();
            }
        }
    }
}
