using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Atestat
{
    public partial class Form1 : Form
    {
        bool goRight, goLeft;
        int speed = 9;
        int score = 0;
        int ballx = 2, bally = 2;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximumSize = new System.Drawing.Size(940, 726);
            MaximizeBox = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int W = r.Next(60, 620);
            int H = r.Next(220, 380);
            ball1.Location = new Point(W, H);
                       foreach( Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag=="block")
                {
                    Image myim = new Bitmap("red_block.png");
                    x.BackgroundImage = myim;
                    x.BackgroundImageLayout = ImageLayout.Stretch;
                }
                       }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Player.Left > 0)
                goLeft = true;
            if (e.KeyCode == Keys.Right && Player.Left + Player.Width < ClientSize.Width)
                goRight = true;
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            Point pt = ball1.Location;
            pt.X += speed/3 * ballx;
            pt.Y += speed/3 * bally;
            ball1.Location = pt;
            label1.Text = "Score: " + score;
            if (goRight)
                Player.Left += speed +1 ;
            if (goLeft)
                Player.Left -= speed +1 ;
            if (Player.Left < 1)
                goLeft = false;
                if ( Player.Left + Player.Width>ClientSize.Width)
                    goRight = false;
                if (pt.X < 0 || pt.X > ClientRectangle.Width - ball1.Width)
                ballx = -ballx;
                if (pt.Y < 0 || ball1.Bounds.IntersectsWith(Player.Bounds))
                    bally = -bally;
            if(pt.Y > ClientRectangle.Height)
            {
                gameOver();
                MessageBox.Show("game over!");
            }
            foreach(Control x in this.Controls)
            {

                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball1.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (ball1.Location.Y <= x.Location.Y - (x.Height / 2))
                            bally = -bally;
                        else
                        if (ball1.Location.Y >= x.Location.Y + (x.Height / 2))
                            bally = -bally;
                        else
                            if (ball1.Location.X < x.Location.X)
                            {
                                ballx = -ballx;
                                bally = -bally;
                            }
                            else
                                if (ball1.Location.X > x.Location.X)
                                {
                                    ballx = -ballx;
                                    bally = -bally;
                                }
                        x.Tag = "Hit";
                        Image myimage = new Bitmap("blue_block.png");
                        x.BackgroundImage = myimage;
                        x.BackgroundImageLayout = ImageLayout.Stretch;
                        SoundPlayer hit = new SoundPlayer("Ball_Bounce.wav");
                        hit.Play();
                    }
                }
                else
                {
                    if (x is PictureBox && x.Tag == "Hit")
                        if (ball1.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (ball1.Location.Y <= x.Location.Y - (x.Height / 2))
                                bally = -bally;
                            else
                                if (ball1.Location.Y >= x.Location.Y + (x.Height / 2))
                                    bally = -bally;
                                else
                                    if (ball1.Location.X < x.Location.X)
                                    {
                                        ballx = -ballx;
                                        bally = -bally;
                                    }
                                    else
                                        if (ball1.Location.X > x.Location.X)
                                        {
                                            ballx = -ballx;
                                            bally = -bally;
                                        }
                            score = score + 1;
                            this.Controls.Remove(x);
                            if(score<=5)
                                speed = speed + 1;
                            SoundPlayer dest = new SoundPlayer("Block_Destroy.wav");
                            dest.Play();
                        }
                }
            }
            if (score == 35)
            {
                gameOver();
                MessageBox.Show("you win");
            }

        }
        private void gameOver()
        {
            SoundPlayer sp = new SoundPlayer("loselife.wav");
            sp.Play();
            timer1.Stop();
            if (MessageBox.Show("Play again ? ", "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Restart();
            else     
                Environment.Exit(0);
        
        
            
        }
    }
}
