using System.Drawing;
using System.Windows.Forms;

namespace FakeConsole
{
    class AsciiShape
    {

        char[,] grid;
        public Point location;
        Font font;
        Brush color;

        public AsciiShape(char[,] shape, Point loc, Font fnt, Brush brsh)
        {
            grid = shape;
            location = loc;
            font = fnt;
            color = brsh;
        }

        public void RotateFix()
        {
            char[,] newGrid = new char[grid.GetLength(1), grid.GetLength(0)];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    newGrid[y, x] = grid[x, y];
                }
            }

            grid = newGrid;
        }

        public void Draw(PaintEventArgs p)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    p.Graphics.DrawString(grid[x, y].ToString(), font, color, new Point(location.X + (int)(x * font.Size), location.Y + (int)(y * font.Height)));
                }
            }
        }

    }
}
