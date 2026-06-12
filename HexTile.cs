using System.Drawing;
using System.Drawing.Drawing2D;

namespace AZ_Kviz
{
    internal class HexTile
    {
        public PointF[] Points;
        public Color FillColor = Color.WhiteSmoke;
        public string Label = "";
        public TileManager.TileStates State;

        public bool HitTest(PointF p) {
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(Points);
                return path.IsVisible(p);
            }
        }

        public PointF GetCenter()
        {
            float x = 0, y = 0;
            foreach (var pt in Points)
            {
                x += pt.X;
                y += pt.Y;
            }
            return new PointF(x / Points.Length, y / Points.Length);
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
                using(var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(Label, font, textBrush, center, sf);
                }
            }
        }
    }

    
}
