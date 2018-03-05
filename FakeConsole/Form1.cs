using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;

namespace FakeConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Game game;


        private int seconds = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(this, this.Font, (Point)this.Size);

            UpdateTimer.Interval = 1000 / 16;

            UpdateTimer.Enabled = true;
            SecondTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            game.Update(seconds);
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
        }




        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            ///Combinations

            if (Keyboard.IsKeyDown(Key.W) && Keyboard.IsKeyDown(Key.D))
            {

            }

            if (Keyboard.IsKeyDown(Key.W) && Keyboard.IsKeyDown(Key.A))
            {

            }

            if (Keyboard.IsKeyDown(Key.S) && Keyboard.IsKeyDown(Key.D))
            {

            }

            if (Keyboard.IsKeyDown(Key.S) && Keyboard.IsKeyDown(Key.A))
            {

            }


            ///Single key presses
            switch (e.KeyCode)
            {
                case Keys.W:
                    break;
                case Keys.A:
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
                case Keys.Enter:
                    break;
                default:
                    break;
            }

            game.KeyDown(e);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             game.Draw(e);

           // e.Graphics.DrawString("Font Width: " + this.Font.Size + "--- Font Height: " + this.Font.Height, this.Font, Brushes.Red, new Point(200, 200));
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {



        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            game.KeyUp(e);
        }
    }
}

