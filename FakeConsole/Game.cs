using System;
using System.Windows.Forms;
using System.Drawing;
using static Tools.Helper;
using static Tools.Structures;


namespace FakeConsole
{
    class Game
    {

        Form form;


        Font font;

        int seconds;

        Point screenSize;

        Random rand;


        public Game(Form frm, Font fnt, Point size)
        {
            form = frm;
            font = fnt;
            screenSize = size;
            Start();

        }


        bool isMoving;

        public void KeyDown(KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                case Keys.W:
                    walk0.location.Y -= 5;
                    walk1.location.Y -= 5;
                    idle.location.Y -= 5;
                    isMoving = true;
                    break;
                case Keys.A:
                    walk0.location.X -= 5;
                    walk1.location.X -= 5;
                    idle.location.X -= 5;
                    isMoving = true;

                    break;
                case Keys.S:
                    walk0.location.Y += 5;
                    walk1.location.Y += 5;
                    idle.location.Y += 5;
                    isMoving = true;

                    break;
                case Keys.D:
                    walk0.location.X += 5;
                    walk1.location.X += 5;
                    idle.location.X += 5;
                    isMoving = true;
                    break;

                default:
                    break;
            }
        }

        public void KeyUp(KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                case Keys.W:
                    isMoving = false;
                    break;
                case Keys.A:

                    isMoving = false;

                    break;
                case Keys.S:

                    isMoving = false;

                    break;
                case Keys.D:

                    isMoving = false;
                    break;

                default:
                    break;
            }
        }
        AsciiShape idle;
        AsciiShape walk0;
        AsciiShape walk1;

        void CreatePlayer()
        {

        }


        private void Start()
        {
            rand = new Random();
            char[,] gridIdle =
            {
                {' ',' ','0','0','0',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ','0','0','0',' ',' '},
                {' ',' ',' ','0',' ',' ',' '},
                {' ','0','0','0','0','0',' '},
                {' ',' ',' ','0',' ',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
            };

            char[,] gridWalk0 =
{
                {' ',' ','0','0','0',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ','0','0','0',' ',' '},
                {' ',' ',' ','0',' ',' ',' '},
                {' ','0','0','0','0',' ',' '},
                {' ',' ',' ','0',' ','0',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ',' ',' ','0',' ',' '},
            };



            char[,] gridWalk1 =
            {
                {' ',' ','0','0','0',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ','0','0','0',' ',' '},
                {' ',' ',' ','0',' ',' ',' '},
                {' ',' ','0','0','0','0',' '},
                {' ','0',' ','0',' ',' ',' '},
                {' ',' ','0',' ','0',' ',' '},
                {' ',' ','0',' ',' ',' ',' '},
            };

            idle = new AsciiShape(gridIdle, new Point(20, 20), font, Brushes.CornflowerBlue);
            idle.RotateFix();

            walk0 = new AsciiShape(gridWalk0, new Point(20, 20), font, Brushes.CornflowerBlue);
            walk0.RotateFix();

            walk1 = new AsciiShape(gridWalk1, new Point(20, 20), font, Brushes.CornflowerBlue);
            walk1.RotateFix();
        }

        int currentFrame = 0;

        public void Update(int secondsElapsed)
        {
            seconds = secondsElapsed;



            if (currentFrame < 8)
            {
                currentFrame++;
            }
            else
            {
                currentFrame = 0;
            }
        }

        public void Draw(PaintEventArgs g)
        {
            if (isMoving)
            {
                if (currentFrame < 4)
                    walk0.Draw(g);
                else
                    walk1.Draw(g);
            }
            else
            {
                idle.Draw(g);
            }
        }
    }
}
