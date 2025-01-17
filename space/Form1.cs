using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace space
{
    public partial class Form1 : Form
    {

        Random random = new Random();

        Rectangle player1 = new Rectangle(60, 300, 12, 22);
        Rectangle player2 = new Rectangle(500, 300, 12, 22);
        

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen blackPen = new Pen(Color.Black, 5);

        bool wPressed = false;
        bool sPressed = false;
        bool upPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        int player1score = 0;
        int player2socre = 0;
        int player1Speed = 4;
        int player2Speed = 4;

        List<Rectangle> balls = new List<Rectangle>();
        List <int> ballspeeds = new List<int> ();
        List <int> ballsizes = new List<int> (); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, player1);
            e.Graphics.DrawRectangle(blackPen, player2);
            e.Graphics.FillRectangle(whiteBrush, player1);
            e.Graphics.FillRectangle(whiteBrush, player2);
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sPressed == true && player1.Y < this.Height - 10)
            {
                player1.Y += player1Speed;

            }
            Refresh();

            if (aPressed == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dPressed == true && player1.X < this.Width - 10)
            {
                player1.X += player1Speed;
            }


            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downPressed == true && player2.Y < this.Height - 10)
            {
                player2.Y += player2Speed;

            }


            if (leftPressed == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightPressed == true && player2.X < this.Width - 10)
            {
                player2.X += player2Speed;
            }


            if (random.Next(0,101) < 15)
            {
                int y = random.Next(0, this.Height);
                int size = random.Next(5,15);
                int speed = random.Next(5,10);
                balls.Add(new Rectangle(0, y , size, size));
                ballspeeds.Add(speed);  
                ballsizes.Add(size);
            }
            else if (random.Next(0,101) < 15)
            {
                int y = random.Next(0, this.Height);
                int size = random.Next(5, 15);
                int speed = random.Next(5, 10);
                balls.Add(new Rectangle(this.Width, y , size , size));
                ballspeeds.Add(-speed);
                ballsizes.Add(size);
            }


            for (int i = 0; i < balls.Count; i++)
            {
                balls[i] = new Rectangle(balls[i].X + ballspeeds[i], balls[i].Y, ballsizes[i], ballsizes[i]);

                if (balls[i].X <= 0 || balls[i].X >= this.Width - balls[i].Width)
                    ballspeeds[i] = -ballspeeds[i];
            }


            for (int i = 0; i < balls.Count; i++)
            {
                balls[i] = new Rect-angle(balls[i].X + ballspeeds[i], balls[i].Y, ballsizes[i], ballsizes[i]);

                if (balls[i].X <= 0 || balls[i].X >= this.Width - balls[i].Width)
                    ballspeeds[i] = -ballspeeds[i];
            }



        }
    }
}
