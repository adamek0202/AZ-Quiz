using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AZ_Kviz.Components
{
    internal partial class GameBoardBase : Control
    {
        protected readonly List<HexTile> tiles = new List<HexTile>();
        protected readonly Font labelFont;

        public GameBoardBase(byte[] svgResource, Font font)
        {
            DoubleBuffered = true;
            this.labelFont = font;
        }

        public void UpdateTile(int id, TileManager.TileStates state)
        {
            if(id >= 0 && id < tiles.Count)
            {
                tiles[id].FillColor = state.TileColor();
                tiles[id].State = state;
                Invalidate();
            }
        }

        public void Reset()
        {
            foreach(var item in tiles)
            {
                item.FillColor = Color.White;
                item.State = TileManager.TileStates.Clear;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach(var tile in tiles)
            {
                tile.Draw(pe.Graphics, labelFont);
            }
        }

        private void LoadSvg(byte[] svgResource)
        {
            using(var stream = new MemoryStream(svgResource))
            {
                XDocument doc = XDocument.Load(stream);
                XNamespace ns = "http://www.w3.org/2000/svg";
                int index = 1;

                foreach(var polygon in doc.Descendants(ns + "polygon"))
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
                }
            }
        }
    }
}
