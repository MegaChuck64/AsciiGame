using System;
using System.Windows.Forms;
using System.Drawing;
using static Tools.Helper;
using static Tools.Structures;
using System.Collections.Generic;



/// <summary>
/// ::::::::::::::::::::::::::TODO:::::::::::::::::::::::::::::::
/// 
///        IDK man, this shit is too slow
///        consider going back to a real console
///        using the c++ calls to set window and font
///        and the user32.dll import
///        or maybe even c++ and curses lol
/// 
/// ::::::::::::::::::::::::::TODO:::::::::::::::::::::::::::::::
/// </summary>


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
        AsciiShape player;


        #endregion


        #region Input

        public void KeyDown(KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                case Keys.W:
                    player.Move(0,  -5);

                    break;
                case Keys.A:
                    player.Move( -5,  0);


                    break;
                case Keys.S:
                    player.Move(0,  5);


                    break;
                case Keys.D:
                    player.Move( 5, 0);

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

                case Keys.Space:

                    moveDir = new Point(rand.Next(-10, 10), rand.Next(-10, 10));
                    
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

            //left
            border[0] = new Ascii_Rectangle('o', new Point(55, 1), true, new Point(26, 20), font, Brushes.Crimson);
            
            //top
            border[1] = new Ascii_Rectangle('o', new Point(1, 44), true, new Point(26, 20), font, Brushes.Crimson);
            
            //rihgt
            border[2] = new Ascii_Rectangle('o', new Point(1, 44), true, new Point(890, 20), font, Brushes.Crimson);

            //bottom
            border[3] = new Ascii_Rectangle('o', new Point(55, 1), true, new Point(26, 837), font, Brushes.Crimson);


            player = new AsciiShape(new Point(100, 100), font, Brushes.Orange);

            moveDir = new Point(rand.Next(-10, 10), rand.Next(-10, 10));
        }

        #endregion





        #region Updating Functions
        Point moveDir;

        public void Update(int secondsElapsed)
        {
            seconds = secondsElapsed;



            if (player.location.X < border[0].location.X + font.Size || player.location.X >= border[2].location.X - (5*font.Size))
            {
                if (moveDir.X > 0)
                {
                    moveDir.X = rand.Next(1, 10);
                    player.location.X -= 4;
                }
                else
                {
                    moveDir.X = rand.Next(-10, 0);
                    player.location.X += 4;
                }

                moveDir.X *= -1;
            }
            if (player.location.Y < border[1].location.Y + font.Height || player.location.Y >= border[3].location.Y - (5*font.Size))
            {
                if (moveDir.Y > 0)
                {
                    moveDir.Y = rand.Next(1, 10);
                    player.location.Y -= 4;
                }
                else
                {
                    moveDir.Y = rand.Next(-10, 0);
                    player.location.Y += 4;
                }

                moveDir.Y *= -1;
            }

                player.Move(moveDir.X, moveDir.Y);

            player.Play();

        }

        public void Draw(Graphics g)
        {
            foreach (Ascii_Rectangle b in border)
            {
                b.Draw(g);
            }
            player.Draw(g);

        }

        #endregion
    }
}
