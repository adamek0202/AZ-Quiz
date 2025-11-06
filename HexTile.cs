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
            using (var pen = new Pen(Color.Black, 1))
            {
                g.FillPolygon(brush, Points);
                g.DrawPolygon(pen, Points);
            }

            if (!string.IsNullOrEmpty(Label))
            {
                var center = GetCenter();
                var size = g.MeasureString(Label, font);
                g.DrawString(Label, font, FillColor == Color.Black ? Brushes.White : Brushes.Black,
                    center.X - (size.Width / 2) + 15,
                    center.Y - (size.Height / 2) - 5);
            }
        }
    }

    
}
