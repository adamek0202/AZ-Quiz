using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace AZ_Kviz
{
    internal class HexTile
    {
        public PointF[] Points { get; set; }
        public Color FillColor = Color.WhiteSmoke;
        public string Label = "";
        public TileManager.TileStates State;

        public bool HitTest(PointF p)
        {
            if (Points == null || Points.Length == 0) return false;
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(Points);
                return path.IsVisible(p);
            }
        }

        public PointF GetCenter()
        {
            if (Points == null || Points.Length == 0)
                return PointF.Empty;

            float minX = Points.Min(p => p.X);
            float maxX = Points.Max(p => p.X);
            float minY = Points.Min(p => p.Y);
            float maxY = Points.Max(p => p.Y);

            return new PointF(
                (minX + maxX) / 2f,
                (minY + maxY) / 2f
            );
        }

        public void Draw(Graphics g, Font font)
        {
            using (var brush = new SolidBrush(FillColor))
            {
                g.FillPolygon(brush, Points);
                g.DrawPolygon(Pens.Black, Points);
            }

            if (!string.IsNullOrEmpty(Label))
            {
                var center = GetCenter();
                var textBrush = (FillColor == Color.Black) ? Brushes.White : Brushes.Black;
                using (var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(Label, font, textBrush, center, sf);
                }
            }
        }
    }


}
