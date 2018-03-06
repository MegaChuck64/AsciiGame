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

            UpdateTimer.Interval = 1000 / 30;

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

            if (Keyboard.IsKeyDown(Key.Escape))
            {
               Application.Exit();
            }

            game.KeyDown(e);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             game.Draw(e.Graphics);

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

