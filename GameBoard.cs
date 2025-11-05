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
    public partial class GameBoard : Control
    {
        private readonly List<HexTile> tiles = new List<HexTile>();
        private readonly Font labelFont = new Font("Segoe UI", 10, FontStyle.Bold);

        internal event Action<int, HexTile>? TileClicked;

        public GameBoard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            LoadSvg();
            MouseClick += OnMouseClick;
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
            var stream = new MemoryStream(Properties.Resources.map);
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

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].HitTest(e.Location) && tiles[i].State != TileStates.Blocked)
                {
                    TileClicked?.Invoke(i, tiles[i]);
                    break;
                }
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

        public void BlockTile(int index)
        {
            if (index >= 0 && index < tiles.Count)
            {
                tiles[index].FillColor = Color.Black;
                tiles[index].State = TileStates.Blocked;
                Invalidate();
            }
        }

        public void SetTileLabel(int index, string text)
        {
            if (index >= 0 && index < tiles.Count)
            {
                tiles[index].Label = text;
                Invalidate();
            }
        }
    }
}
