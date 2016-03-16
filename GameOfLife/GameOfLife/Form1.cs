using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class GameOfLife : Form
    {
        public GameOfLife()
        {
            InitializeComponent();
        }

        Thread thread;

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(run);
            thread.Start();
        }

        private void run()
        {
            if (button1.Text=="START")
            {
                button1.Invoke(new Action(delegate()
                    {
                        button1.Enabled = false;
                    }));
                Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            Random rnd = new Random();
            int n, iter, p, x, y, s;
            n = int.Parse(textBox1.Text);
            int[,] Prev;
            Prev = new int[n + 2, n + 2];
            int[,] Curr;
            Curr = new int[n + 2, n + 2];
            iter = 0;
            for (int i = 0; i <= n + 2; i++)
            {
                for (int j = 0; j <= n + 2; j++)
                {
                    Prev[0, 0] = 0;
                    Curr[0, 0] = 0;
                }

            }
            if (radioButton1.Checked)
            {
                s = pictureBox1.Width / n;
                p = int.Parse(textBox2.Text);
                for (int z = 1; z <= p; z++)
                {
                    x = rnd.Next(1, n);
                    y = rnd.Next(1, n);
                    Curr[x, y] = 1;
                }
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        SolidBrush brush = new SolidBrush(Curr[i, j] == 1 ? Color.Black : Color.White);
                        Rectangle rect = new Rectangle(i * s, j * s, s, s); //(wspX, wspY,wielkoscX, wielkoscY)
                        g.FillRectangle(brush, rect);
                    }
                }
                while (iter < 1000)
                {
                    iter++;
                   // label3.Text = iter.ToString();
                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            if (Prev[i, j] == 0 && (Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) == 3)
                                Curr[i, j] = 1;
                            if (Prev[i, j] == 1 && ((Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) > 3 || (Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) < 2))
                                Curr[i, j] = 0;
                        }
                    }
                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            SolidBrush brush = new SolidBrush(Curr[i, j] == 1 ? Color.Black : Color.White);
                            Rectangle rect = new Rectangle(i * s, j * s, s, s); //(wspX, wspY,wielkoscX, wielkoscY)
                            g.FillRectangle(brush, rect);
                        }
                    }

                    for (int i = 0; i <= n + 1; i++)
                    {
                        for (int j = 0; j <= n + 1; j++)
                        {
                            Prev[i, j] = Curr[i, j];
                        }
                    }

                }
            }
            if (radioButton2.Checked)
            {
                s = pictureBox1.Width / n;
                p = int.Parse(textBox2.Text);
                for (int z = 1; z <= 2 * p / 3; z++)
                {
                    x = rnd.Next(1, n);
                    y = rnd.Next(1, n);
                    Curr[x, y] = 1;
                }
                for (int z = 1; z <= p / 3; z++)
                {
                    x = rnd.Next(1, n);
                    y = rnd.Next(1, n);
                    Curr[x, y] = 2;
                }
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        SolidBrush brush = new SolidBrush(Curr[i, j] == 0 ? Color.White : Curr[i, j] == 1 ? Color.Red : Color.Green);
                        Rectangle rect = new Rectangle(i * s, j * s, s, s); //(wspX, wspY,wielkoscX, wielkoscY)
                        g.FillRectangle(brush, rect);
                    }
                }
                while (iter < 1000)
                {
                    iter++;
                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            if (Prev[i, j] == 0 && (Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) == 3)
                                Curr[i, j] = 1;
                            if (Prev[i, j] == 1 && ((Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) > 3 || (Prev[i - 1, j - 1] + Prev[i - 1, j] + Prev[i - 1, j + 1] + Prev[i, j - 1] + Prev[i, j + 1] + Prev[i + 1, j - 1] + Prev[i + 1, j] + Prev[i + 1, j + 1]) < 2))
                                Curr[i, j] = 0;
                        }
                    }
                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            SolidBrush brush = new SolidBrush(Curr[i, j] == 0 ? Color.White : Curr[i, j] == 1 ? Color.Red : Color.Green);
                            Rectangle rect = new Rectangle(i * s, j * s, s, s); //(wspX, wspY,wielkoscX, wielkoscY)
                            g.FillRectangle(brush, rect);
                        }
                    }

                    for (int i = 0; i <= n + 1; i++)
                    {
                        for (int j = 0; j <= n + 1; j++)
                        {
                            Prev[i, j] = Curr[i, j];
                        }
                    }



                    //System.Threading.Thread.Sleep(20);
                }
               
            }   
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread.Abort();
            button1.Invoke(new Action(delegate()
            {
                button1.Enabled = true;
            }));
        }
    }
}