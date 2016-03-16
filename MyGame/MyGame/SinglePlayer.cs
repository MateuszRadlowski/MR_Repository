using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public partial class SinglePlayer : Form
    {
        bool left;
        bool right;
        int road_middle = 0;
        int score = 0;
        bool play;
        int go = 1;
        bool end = false;
        bool ch_go = false; //zmiana predkosci
        int go_help = 0; //pomocnicza do zmiany predkosci
        int i = 0;
        int go_prev = 1; // poprzednia predkosc
        bool pause = false;
        int istop = 0; //rnd pojawienia sie stop
        int steer = 3; //predkosc skrecania


        public SinglePlayer()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random enemyrnd1 = new Random();
            Random enemyrnd2 = new Random();
            Random stoprnd = new Random();

            score_lbl.Text = score.ToString();
            istop = stoprnd.Next(25,200);

            if (i == istop && go > 1)
            {
                if (!stop.Visible)
                {
                    stop.Top = road.Top;
                    stop.Visible = true;
                    Console.Write("\n STOP \n");
                }
            }

         /*   if (score == 50)
            {
                road.BackColor = Color.Khaki;
                steer = 1;            
            }

            if (score == 25)
            {
                road.BackColor = Color.White;
                steer = 3;
            }*/

            if (right && play)
            {
                car.Left += steer;
            }

            if (left && play)
            {
                car.Left -= steer;
            }

            if (play)
            {
                wall1.Top += go;
                wall2.Top += go;
                Wheel1.Top += go;
                Wheel2.Top += go;
                Wheel3.Top += go;
                Tree.Top += go;
                stop.Top += go;
                i++;

            }
            if (stop.Top > road.Bottom)
            {

                stop.Visible = false;
                i = 0;
                Console.Write("\n Stop 0 \n");
                stop.Top = road.Top;
                stop.Left = enemyrnd1.Next(road.Left, road.Right - stop.Width);
            }

            if (Tree.Top > road.Bottom)
            {
                score++;
                ch_go = true;
                Tree.Top = road.Top;
                Tree.Left = enemyrnd1.Next(road.Left, road.Right - Tree.Width);
            }

            if (wall1.Top > road.Bottom)
            {
                
                score++;
                ch_go = true;
                wall1.Top = road.Top;
                wall1.Left = enemyrnd1.Next(road.Left, road_middle-wall1.Width);

                wall2.Top = road.Top;
                wall2.Left = enemyrnd1.Next(road_middle, road.Right - wall2.Width);
            }

            if (Wheel1.Top > road.Bottom)
            {
                score++;
                ch_go = true;
                Wheel1.Top = road.Top;
                Wheel1.Left = enemyrnd1.Next(road.Left, road.Right - Wheel1.Width);

            }

            if (Wheel2.Top > road.Bottom)
            {
                score++;
                ch_go = true;
                Wheel2.Top = road.Top;
                Wheel2.Left = enemyrnd1.Next(road.Left, road.Right - Wheel2.Width);

            }

            if (Wheel3.Top > road.Bottom)
            {
                score++;
                ch_go = true;
                Wheel3.Top = road.Top;
                Wheel3.Left = enemyrnd1.Next(road.Left, road.Right - Wheel3.Width);

            }

            if (car.Left < road.Left)
            {
                left = false;
            }

            if (car.Right > road.Right)
            {
                right = false;
            }

            if (car.Left < stop.Right && car.Right > stop.Left && car.Top < stop.Bottom && car.Bottom > stop.Top && !end)
            {
                if (stop.Visible)
                {
                    go = 2;
                    stop.Visible = false;
                }
            }

            if (car.Left < Tree.Right-30 && car.Right > Tree.Left+30 && car.Top < Tree.Bottom-30 && car.Bottom > Tree.Top+30 && !end)
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (car.Left < wall1.Right && car.Right > wall1.Left && car.Top < wall1.Bottom && car.Bottom > wall1.Top && !end )
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (car.Right > wall2.Left && car.Left < wall2.Right && car.Top < wall2.Bottom && car.Bottom > wall2.Top && !end)
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (car.Left < Wheel1.Right && car.Right > Wheel1.Left && car.Top < Wheel1.Bottom && car.Bottom > Wheel1.Top && !end)
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (car.Left < Wheel2.Right && car.Right > Wheel2.Left && car.Top < Wheel2.Bottom && car.Bottom > Wheel2.Top && !end)
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (car.Left < Wheel3.Right && car.Right > Wheel3.Left && car.Top < Wheel3.Bottom && car.Bottom > Wheel3.Top && !end)
            {
                car.BackgroundImage = MyGame.Properties.Resources.Explosion_Image;
                end = true;
            }

            if (ch_go)
            {
                go+=score/10-go_help;
                ch_go = false;
                go_help = score / 10;
                
            }

            if (go - go_prev == 1)
            {
                go_prev++;
                i = 0;
            }
            
            if (i > 150)
            {
                LvlUp.Visible = false;
                //i++;
            }
            
            Console.Write("score " + score + " go " + go +" flag " + ch_go + " i " + i + " \n ");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && car.Left>road.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Right && car.Right<road.Right)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (!pause)
                {
                    play = false;
                    pause = true;
                    pause_label.Visible = true;
                }
                else
                {
                    play = true;
                    pause = false;
                    pause_label.Visible = false;
                }
                Mmenu frm2 = new Mmenu();
                frm2.Show();
            }

            if (e.KeyCode == Keys.Space)
            {
                if (!pause)
                {
                    play = false;
                    pause = true;
                    pause_label.Visible = true;
                }
                else
                {
                    play = true;
                    pause = false;
                    pause_label.Visible = false;
                }
            }

            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            stop.Visible = false;
            Mmenu frm2 = new Mmenu();
            frm2.Close();
            frm2.Hide();
            System.Threading.Thread.Sleep(500);
            play = true;
            road_middle = (road.Left + road.Right) / 2;

            LvlUp.Visible = false;
            pause_label.Visible = false;

            
         

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (end)
            {
                timer1.Stop();
                timer2.Stop();
                end = false;
                play = false;
                string message = "Game Over!! Your score is " + score;
                string caption = "Game Over";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon Icon = MessageBoxIcon.Error;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, Icon);
            }
        }
    }
}
