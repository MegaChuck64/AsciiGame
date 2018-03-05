using System;
using System.Drawing;


namespace Tools
{
    public class Helper
    {
        float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
        }


    }
}
