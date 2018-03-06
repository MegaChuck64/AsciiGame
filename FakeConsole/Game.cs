using System;
using System.Windows.Forms;
using System.Drawing;
using static Tools.Helper;
using static Tools.Structures;
using System.Collections.Generic;


namespace FakeConsole
{
    class Game
    {


        Form form;          //refrence to the main form

        Font font;          //generic font to draw all text with

        int seconds;        //seconds elapsed so far

        Point screenSize;   // in pixels

        Random rand;        //our random number generator   



        #region Instances
        Ascii_Rectangle[] border;
        Ascii_Rectangle player;

        #endregion


        #region Input

        public void KeyDown(KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                case Keys.W:
                    player.Move(0, -5);
                    break;
                case Keys.A:
                    player.Move(-5, 0);

                    break;
                case Keys.S:
                    player.Move(0, 5);

                    break;
                case Keys.D:
                    player.Move(5, 0);
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
                    player.isMoving = false;
                    break;
                case Keys.A:
                    player.isMoving = false;
                    break;
                case Keys.S:
                    player.isMoving = false;
                    break;
                case Keys.D:
                    player.isMoving = false;
                    break;

                default:
                    break;
            }
        }


        #endregion




        #region Initialization Functions
        /// <summary>
        /// Game Constructor is essentially the equivelent of the Unity Awake function
        /// </summary>
        public Game(Form frm, Font fnt, Point size)
        {
            form = frm;
            font = fnt;
            screenSize = size;
            Start();

        }

        /// <summary>
        /// Consider making game static, and only having one of these functions instead of both start and constuctor
        /// </summary>
        private void Start()
        {
            rand = new Random();


            border = new Ascii_Rectangle[4];

            border[0] = new Ascii_Rectangle('o', new Point(55, 1), true, new Point(26, 20), font, Brushes.Crimson);
            border[1] = new Ascii_Rectangle('o', new Point(1, 44), true, new Point(26, 20), font, Brushes.Crimson);
            border[2] = new Ascii_Rectangle('o', new Point(1, 44), true, new Point(890, 20), font, Brushes.Crimson);
            border[3] = new Ascii_Rectangle('o', new Point(55, 1), true, new Point(26, 840), font, Brushes.Crimson);

            foreach (Ascii_Rectangle b in border)
            {
                b.Draw(form.CreateGraphics());
            }

            player = new Ascii_Rectangle('=', new Point(2, 2), true, new Point(100, 100), font, Brushes.Orange);

        }

        #endregion





        #region Updating Functions

        public void Update(int secondsElapsed)
        {
            seconds = secondsElapsed;


        }

        public void Draw(Graphics g)
        {

            player.Draw(g);
        }

        #endregion
    }
}
