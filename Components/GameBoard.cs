using System;
using System.Collections.Generic;
using SixLabors.Fonts.Unicode;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AZ_Kviz.Components
{
    internal sealed class GameBoard : Control
    {
        private readonly List<HexTile> tiles = new List<HexTile>();

        private readonly Font labelFont;
        private RectangleF svgViewBox;

        private Color playerOneColor = Color.Orange;
        private Color playerTwoColor = Color.DeepSkyBlue;

        private int highlightedTileIndex = -1;

        public bool Interactive { get; set; } = true;

        internal event Action<uint, HexTile> TileClicked;

        private bool fitToTiles;
        public bool FitToTiles
        {
            get => fitToTiles;
            set
            {
                if (fitToTiles == value)
                {
                    return;
                }

                fitToTiles = value;
                Invalidate();
            }
        }

        public GameBoard()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            labelFont = new Font("Arial", 36, FontStyle.Bold);
            LoadSvg(Properties.Resources.map_l);
        }


        private void LoadSvg(byte[] svgResource)
        {
            using (var stream = new MemoryStream(svgResource))
            {
                XDocument doc = XDocument.Load(stream);
                XNamespace ns = "http://www.w3.org/2000/svg";

                string viewBoxText = doc.Root.Attribute("viewBox")?.Value;

                if (string.IsNullOrWhiteSpace(viewBoxText))
                {
                    throw new InvalidDataException("SVG neobsahuje viewBox.");
                }

                float[] viewBox = viewBoxText
                    .Split(new[] { ' ', ',', '\t' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => float.Parse(s, CultureInfo.InvariantCulture))
                    .ToArray();

                if (viewBox.Length != 4 ||
                    viewBox[2] <= 0 || viewBox[3] <= 0)
                {
                    throw new InvalidDataException("Neplatný SVG viewBox.");
                }


                svgViewBox = new RectangleF(
                    viewBox[0],
                    viewBox[1],
                    viewBox[2],
                    viewBox[3]);

                tiles.Clear();
                int index = 1;

                foreach (var polygon in doc.Descendants(ns + "polygon"))
                {
                    string pointsText = polygon.Attribute("points")?.Value;
                    if (string.IsNullOrWhiteSpace(pointsText)) continue;

                    float[] values = pointsText
                        .Split(new[] { ' ', ',', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => float.Parse(s, CultureInfo.InvariantCulture))
                        .ToArray();

                    if (values.Length < 6 || values.Length % 2 != 0)
                    {
                        throw new InvalidDataException($"Neplatné souřadnice polygonu {index}.");
                    }

                    PointF[] points = new PointF[values.Length / 2];

                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new PointF(
                            values[i * 2],
                            values[i * 2 + 1]);
                    }
                    tiles.Add(new HexTile
                    {
                        Points = points,
                        Label = index.ToString()
                    });

                    index++;
                }
            }
        }

        private RectangleF GetContentBounds()
        {
            if (!FitToTiles)
            {
                return svgViewBox;
            }

            var points = tiles.SelectMany(t => t.Points).ToArray();

            if (points.Length == 0)
            {
                return svgViewBox;
            }

            float minX = points.Min(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxX = points.Max(p => p.X);
            float maxY = points.Max(p => p.Y);

            const float margin = 20f;

            return RectangleF.FromLTRB(
                minX - margin,
                minY - margin,
                maxX + margin,
                maxY + margin);
        }

        private bool GetTransform(
            out float scale,
            out float offsetX,
            out float offsetY)
        {
            scale = 0;
            offsetX = 0;
            offsetY = 0;

            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return false;

            var points = tiles
                .Where(t => t.Points != null)
                .SelectMany(t => t.Points)
                .ToArray();

            if (points.Length == 0)
                return false;

            const float margin = 20f;

            float minX = points.Min(p => p.X) - margin;
            float minY = points.Min(p => p.Y) - margin;
            float maxX = points.Max(p => p.X) + margin;
            float maxY = points.Max(p => p.Y) + margin;

            float contentWidth = maxX - minX;
            float contentHeight = maxY - minY;

            scale = Math.Min(
                ClientSize.Width / contentWidth,
                ClientSize.Height / contentHeight);

            offsetX =
                (ClientSize.Width - contentWidth * scale) / 2f
                - minX * scale;

            offsetY =
                (ClientSize.Height - contentHeight * scale) / 2f
                - minY * scale;

            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!GetTransform(
                    out float scale,
                    out float offsetX,
                    out float offsetY))
            {
                return;
            }

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            GraphicsState state = g.Save();

            try
            {
                g.TranslateTransform(offsetX, offsetY);
                g.ScaleTransform(scale, scale);

                for (int i = 0; i < tiles.Count; i++)
                {
                    if (i == highlightedTileIndex)
                        continue;

                    tiles[i].Draw(g, labelFont);
                }

                if (highlightedTileIndex >= 0 &&
                    highlightedTileIndex < tiles.Count)
                {
                    DrawHighlitedTile(
                        g,
                        tiles[highlightedTileIndex],
                        1.4f);
                }
            }
            finally
            {
                g.Restore(state);
            }
        }

        public void HighlightField(uint id)
        {
            if (id >= tiles.Count)
                return;

            HexTile tile = tiles[(int)id];

            if (tile.State == TileManager.TileStates.Blocked)
                return;

            highlightedTileIndex = (int)id;
            Invalidate();
        }

        public void ClearHighlight()
        {
            highlightedTileIndex = -1;
            Invalidate();
        }

        private PointF ClientToSvg(Point point)
        {
            if (!GetTransform(
                    out float scale,
                    out float offsetX,
                    out float offsetY))
                return PointF.Empty;

            return new PointF(
                (point.X - offsetX) / scale,
                (point.Y - offsetY) / scale);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (!Interactive || e.Button != MouseButtons.Left)
            {
                return;
            }

            if (!GetTransform(
                    out float scale,
                    out float offsetX,
                    out float offsetY))
            {
                return;
            }

            float imageWidth = svgViewBox.Width * scale;
            float imageHeight = svgViewBox.Height * scale;

            if (e.X < offsetX ||
                e.Y < offsetY ||
                e.X > offsetX + imageWidth ||
                e.Y > offsetY + imageHeight)
            {
                return;
            }

            PointF svgPoint = ClientToSvg(e.Location);

            for (int i = 0; i < tiles.Count; i++)
            {
                HexTile tile = tiles[i];

                if (tile.State == TileManager.TileStates.Blocked)
                {
                    continue;
                }

                if (tile.HitTest(svgPoint))
                {
                    TileClicked?.Invoke((uint)i, tile);
                }
            }
        }

        public bool UpdateTile(uint id, TileManager.TileStates state)
        {
            if (id >= tiles.Count)
            {
                Serilog.Log.Warning(
                    "UpdateTile: index {Id} je mimo rozsah ({Count}).",
                    id, tiles.Count);

                return false;
            }

            HexTile tile = tiles[(int)id];
            tile.FillColor = state.TileColor(playerOneColor, playerTwoColor);

            tile.State = state;

            Invalidate();

            if (state == TileManager.TileStates.FirstPlayer_Used ||
                state == TileManager.TileStates.SecondPlayer_Used)
            {
                return WinChecker.CheckWin(tiles, state);
            }

            return false;
        }

        public void SetPlayerColors(Color first, Color second)
        {
            playerOneColor = first;
            playerTwoColor = second;

            foreach (HexTile tile in tiles)
            {
                tile.FillColor = tile.State.TileColor(
                    playerOneColor, playerTwoColor);
            }

            Invalidate();
        }

        public void Reset()
        {
            foreach (HexTile tile in tiles)
            {
                tile.FillColor = Color.White;
                tile.State = TileManager.TileStates.Clear;
            }

            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                labelFont.Dispose();

            base.Dispose(disposing);
        }


        private void DrawHighlitedTile(Graphics g, HexTile tile, float zoom) {
            PointF center = tile.GetCenter();

            GraphicsState state = g.Save();

            try
            {
                g.TranslateTransform(center.X, center.Y);
                g.ScaleTransform(zoom, zoom);
                g.TranslateTransform(-center.X, -center.Y);

                tile.Draw(g, labelFont);
            }
            finally
            {
                g.Restore(state);
            }
        }
    }
}