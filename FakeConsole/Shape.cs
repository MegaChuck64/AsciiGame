using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FakeConsole
{
    class Shape
    {

        public Region region;

        public Brush color;

        public Point location;


        bool created = false;


        public Shape( Brush col, Region reg)
        {
            region = reg;
            color = col;
            created = true;
        }

        public Shape(Brush col, Point loc)
        {
            color = col;
            location = loc;

            CreateShape();
        }

        public void CreateShape()
        {
            List<Point> points = new List<Point>();

            List<byte> types = new List<byte>();

            points.Add(new Point(location.X - 16, location.Y - 32));
            points.Add(new Point(location.X + 16, location.Y - 32));
            points.Add(new Point(location.X + 16, location.Y + 32));
            points.Add(new Point(location.X -16, location.Y + 32));

            byte START = (byte)(PathPointType.Start | PathPointType.Line);
            byte LINE = (byte)(PathPointType.Line);
            byte CLOSE = (byte)(PathPointType.Line | PathPointType.CloseSubpath);

            types.Add(START);
            types.Add(LINE);
            types.Add(LINE);
            types.Add(CLOSE);

            GraphicsPath path = new GraphicsPath(points.ToArray(), types.ToArray());

            region = new Region(path);

            created = true;
        }

        public void Move(int xOffset, int yOffset)
        {
            region.Translate(xOffset, yOffset);
        }

        public void Draw(PaintEventArgs p)
        {
            if (created)
                p.Graphics.FillRegion(color, region);
            else
                p.Graphics.DrawString("Error, didnt create region.", new Font(FontFamily.Families[0].Name, 20), Brushes.Red, location);
        }
    }
}
