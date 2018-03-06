using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeConsole
{
    class Ascii_Rectangle : AsciiShape
    {
        List<char[,]> shape = new List<char[,]>();


        public Ascii_Rectangle(char symbol, Point size, bool filled, Point loc, Font fnt, Brush brsh, int FPS = 5) : base(loc, fnt, brsh, FPS)
        {
            CreateShape(symbol, size, filled);
            base.grid = shape;
        }

        void CreateShape(char sym, Point size, bool filled)
        {
            char[,] newCA = new char[size.X, size.Y];

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    if (filled)
                    {
                        newCA[x, y] = sym;
                    }
                    else
                    {
                        if ((x == 0 || x == size.X - 1 || y == 0 || y == size.Y - 1))
                        {
                            newCA[x, y] = sym;
                        }
                        else
                        {
                            newCA[x, y] = ' ';
                        }
                    }

                }
            }

            shape.Add(newCA);
        }
    }
}
