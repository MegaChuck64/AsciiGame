using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FakeConsole
{
    class AsciiShape
    {

        public List<char[,]> grid;
        public Point location;
        Font font;
        Brush color;
        public int currentFrame;
        public bool isMoving = false;
        public int fps;
        private int framesToWait;

        public AsciiShape(List<char[,]> shape, Point loc, Font fnt, Brush brsh, int FPS = 5)
        {
            grid = shape;
            location = loc;
            font = fnt;
            color = brsh;
            fps = FPS;

            framesToWait = 30 / fps;
        }


        public AsciiShape(Point loc, Font fnt, Brush brsh, int FPS = 5)
        {
            grid = DefaultShape();
            location = loc;
            font = fnt;
            color = brsh;
            fps = FPS;

            framesToWait = 30 / fps;
        }


        List<char[,]> DefaultShape()
        {
            List<char[,]> newLC = new List<char[,]>();

            newLC.Add(new char[,]
            {
                {'=','=','=','='},
                {'=','=','=','='},
                {'=','=','=','='},
                {'=','=','=','='},


            });


            newLC.Add(new char[,]
            {
                {' ',' ','=',' ',' '},
                {' ','=','=','=',' '},
                {'=','=','=','=','='},
                {' ','=','=','=',' '},
                {' ',' ','=',' ',' '},


            });

            return newLC;
        }




        public void RotateFix()
        {
            for (int i = 0; i < grid.Count; i++)
            {
                char[,] newGrid = new char[grid[i].GetLength(1), grid[i].GetLength(0)];

                for (int x = 0; x < grid[i].GetLength(0); x++)
                {
                    for (int y = 0; y < grid[i].GetLength(1); y++)
                    {
                        newGrid[y, x] = grid[i][x, y];
                    }
                }

                grid[i] = newGrid;
            }
        }

        public void Move(int dx, int dy)
        {
            isMoving = true;
            location.X += dx;
            location.Y += dy;
        }


        int counter = 0;
        public void Play()
        {
            if (counter < framesToWait)
            {
                counter++;
            }
            else
            {
                counter = 0;

                if (currentFrame < grid.Count - 1)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(Graphics g)
        {
            for (int y = 0; y < grid[currentFrame].GetLength(1); y++)
            {
                for (int x = 0; x < grid[currentFrame].GetLength(0); x++)
                {
                    g.DrawString(grid[currentFrame][x, y].ToString(), font, color, new Point(location.X + (int)(x * font.Size), location.Y + (int)(y * font.Height)));
                }
            }
        }

    }
}
