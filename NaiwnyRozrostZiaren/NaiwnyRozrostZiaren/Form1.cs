using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace NaiwnyRozrostZiaren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();     
        }
        Thread thrrozrost, thrrekrystal;
        public static int[,] temp = new int[10000,10000];
        public static int[,] copy = new int[10000, 10000];
        public static bool flag = false;
        public static int btnflag = 0;
        public static int iterrekr = 1;
        List<double> dislocDensity = new List<double>();
        public static double romax = 0;

        public void swapnp(int[,] Prev, int[,] Curr)
        {
            int n = int.Parse(textBox1.Text);
            int k=int.Parse(textBox2.Text);
            int v = k + 1;
            if (!flag)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        Prev[i, j] = Curr[i, j];
                        copy[i, j] = Prev[i, j];
                    }
                }
            }
            else if (flag)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        Prev[i, j] = Curr[i, j];
                        if (Prev[i, j] == 0 && temp[i, j] == 1)
                        {
                            Curr[i, j] = v;
                            v++;
                           // flag = false;
                        }
                    }
                }
            }
            //TODO: zamiana nie periodyczne
        }
        public void swapper(int[,] Prev, int[,] Curr)
        {
            int k = int.Parse(textBox2.Text);
            int v = k+1;
            int n = int.Parse(textBox1.Text);
            if (!flag)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        Prev[i, j] = Curr[i, j];
                        copy[i, j] = Prev[i, j];
                    }
                }
            }
            else if (flag)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        Prev[i, j] = Curr[i, j];
                        if (Prev[i, j] == 0 && temp[i, j] != 0)
                        {
                            Prev[i, j] =  v;
                            v++;
                            //flag = false;
                        }
                        }
                }
            }
            Prev[0, 0] = Curr[n, n];
            Prev[n + 1, 0] = Curr[1, n];
            Prev[n + 1, n + 1] = Curr[1, 1];
            Prev[0, n + 1] = Curr[n, 1];

            for (int i = 1; i <= n; i++)
            {
                Prev[i, 0] = Curr[i, n];
                Prev[i, n + 1] = Curr[i, 1];
                Prev[0, i] = Curr[i, n];
                Prev[0, n + 1] = Curr[1, i];
            }


            //TODO: zamiana periodyczna
        }

        public void vonNeuman(int[,] Prev, int[,] Curr, Color[] Kolor)
        {
            
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h=1; h<=n; h++)
            {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    
                    for (int c = 1; c <= k+12; c++)
                    {
                        
                        if (Curr[i, j] == 0 && (Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                            Curr[i, j] = c;
                        if (button3.Text=="Stop")
                            h=n+1;
                            
                        
                        }          
                    }
                rysuj(Curr, Kolor);

            }
                //
            if (checkBox1.Checked)
                swapper(Prev, Curr);
            else
            swapnp(Prev, Curr);
              
                }
        }
        public void Moore(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i - 1, j - 1] == c || Prev[i - 1, j + 1] == c || Prev[i + 1, j - 1] == c || Prev[i + 1, j+1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void pentup(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i + 1, j - 1] == c || Prev[i + 1, j + 1] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void pentleft(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void hexright(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j - 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                swapper(Prev, Curr);
            else
            swapnp(Prev, Curr);

            }
        }
        public void hexleft(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {
                            if (Curr[i, j] == 0 && (Prev[i - 1, j - 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;
                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void pentright(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);

                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void pentdown(int[,] Prev, int[,] Curr, Color[] Kolor)
        {

            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (Curr[i, j] == 0 && (Prev[i - 1, j - 1] == c || Prev[i - 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c;
                            if (button3.Text == "Stop")
                                h = n + 1;

                        }
                    }
                    rysuj(Curr, Kolor);
                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void hexrand(int[,] Prev, int[,] Curr, Color[] Kolor)
        {
            Random rnd = new Random();
            int mod=rnd.Next(1,2);
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                 mod = rnd.Next(1, 2);
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (mod==1 && Curr[i, j] == 0 && (Prev[i - 1, j - 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //hexleft
                            if (mod==2 && Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j - 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //hexright
                            if (button3.Text == "Stop")
                                h = n + 1;


                        }
                    }
                    rysuj(Curr, Kolor);
                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }
        public void pentrand(int[,] Prev, int[,] Curr, Color[] Kolor)
        {
            Random rnd = new Random();
            int mod = rnd.Next(1, 4);
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            for (int h = 1; h <= n; h++)
            {
                mod = rnd.Next(1, 4);
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        for (int c = 1; c <= k+12; c++)
                        {

                            if (mod == 1 && Curr[i, j] == 0 && (Prev[i - 1, j - 1] == c || Prev[i - 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //pentdown
                            if (mod == 2 && Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //pentright
                            if (mod == 3 && Curr[i, j] == 0 && (Prev[i + 1, j - 1] == c || Prev[i + 1, j + 1] == c || Prev[i + 1, j] == c || Prev[i, j - 1] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //pentup
                            if (mod == 4 && Curr[i, j] == 0 && (Prev[i - 1, j + 1] == c || Prev[i + 1, j + 1] == c || Prev[i - 1, j] == c || Prev[i + 1, j] == c || Prev[i, j + 1] == c))
                                Curr[i, j] = c; //pentleft

                            if (button3.Text == "Stop")
                                h = n + 1;


                        }
                    }
                    rysuj(Curr, Kolor);
                }
                if (checkBox1.Checked)
                    swapper(Prev, Curr);
                else
                    swapnp(Prev, Curr);

            }
        }

        //--------------------------------------------------------------

        public void rysuj(int[,] Curr, Color[] Kolor)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int n = int.Parse(textBox1.Text);
            int sx = pictureBox1.Height / n;
            int sy = pictureBox1.Width / n;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (Curr[i,j]!=0)
                    {
                  SolidBrush brush = new SolidBrush(Kolor[Curr[i, j]]);
                   Rectangle rect = new Rectangle(i * sx, j * sy, sx, sy); //(wspX, wspY,wielkoscX, wielkoscY)
                    g.FillRectangle(brush, rect);
                    }
                  //  Console.Write(Curr[i,j]);
                }
              // Console.Write("\n");

            }
        }

        public void losuj(int[,] Curr, Color[] Kolor)
        {
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            Random rnd = new Random();
            int x, y;
            for (int z = 1; z <= k; z++)
            {
                x = rnd.Next(1, n);
                y = rnd.Next(1, n);
                Curr[x, y] = z;
            }
        }
        public void rownomiernie(int[,] Curr, Color[] Kolor)
        {
            //TODO: rozlozenie rownomierne
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            double sxd = (n/k)+Math.Sqrt(n-k/2);
            double syd = (n/k)+Math.Sqrt(n-k/2);
            int sx = (int)sxd;
            int sy = (int)syd;
            int z = 0;
                for (int i=sy;i<n;i+=sy)
            {
                for (int j=sx;j<n;j+=sx)
                {
                    z++;
                    Curr[j, i]=z;
                    if (z == k)
                        break;
                    
                }
                if (z == k)
                    break;
            }
        }
        public void zpromieniem(int[,] Curr, Color[] Kolor)
        {
            int temp = 0;
            int r = int.Parse(textBox3.Text);
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            Random rnd = new Random();
            int x, y;
            int z = 1;
            int it = 0;
            while (z<k && it<1000000)
            {
                it++;
                x = rnd.Next(1+r, n-r);
                y = rnd.Next(1+r, n-r);
                int xr = x + r;
                int yr = y + r;
                for (int i = x - r; i < xr; i++)
                {
                    for (int j = y - r; j < yr; j++)
                    {
                        if (Curr[i, j] != 0)
                            temp = 1;
                    }
                }
                if (temp == 0)
                {
                    Curr[x, y] = z;
                    z++;
                }
                else
                {
                    temp = 0;
                   // Curr[x, y] = 0;
                }
            }
        }
        public void myszka(int[,] Curr, Color[] Kolor)
        {
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            int z=1;
            for (int i = 1; i < n; i++)
            {
                for(int j=1; j < n;j++)
                {
                    
                    if (temp[i,j]==1)
                        {
                            Curr[i,j] = z;
                            z++;
                        }
                   
                }
            }


        }

        public void rozlozdyslokacje(double[,] border, double[,] dyslokacje, double rokom)
        {
            //TODO: rownomierne rozlozenie a pozniej co zostanie to losowanie po granicach. nadal z zasada 0.8, 0.2 a pozniej juz cale. pula to roznica miedzy poprzednia pula a ta z tego obliczenia.
            Random rnd = new Random();
            int x, y;
            double roend = 0;
            int n = int.Parse(textBox1.Text);
             for (int i = 1; i <= n; i++)
             {
                 for (int j = 1; j < n; j++)
                 {
                     dyslokacje[i, j] = rokom * border[i, j];
                     roend=+rokom*(1-border[i,j]);
                 }
             }
             while (roend > 0)
             {
                 x = rnd.Next(1, n);
                 y = rnd.Next(1, n);
                 if (border[x, y] == 0.8 && roend >= rokom)
                 {
                     dyslokacje[x, y] += rokom;
                     roend = -rokom;
                 }
                 else if (border[x, y] == 0.8 && roend < rokom)
                 {
                     dyslokacje[x, y] = +roend;
                     roend = 0;
                 }
                 
             }
        }
        public void getborder(double[,] border)
        {
            int n = int.Parse(textBox1.Text);
            int currcolor = 0;
        for (int i = 1; i < n; i++)
            {
                for (int j=1; j<n; j++)
                {
                currcolor=copy[i,j];
                if (copy[i - 1, j] != currcolor || copy[i + 1, j] != currcolor || copy[i, j - 1] != currcolor || copy[i, j + 1] != currcolor)
                    border[i, j] = 0.8;
                else
                    border[i, j] = 0.2;

                  //  Console.Write(border[i,j]+" ");
                }
                //Console.Write("\n");
                }
        }
        public void rekrystalizuj(double[,] dyslokacje, int[,] Curr, int[,] Prev,Color[] Kolor)
        {
            int n = int.Parse(textBox1.Text);
            int wybors = Convert.ToInt32(label4.Text);
            
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    //Console.Write(Curr[i,j]);
                    // TOKNOW: czy ma sie rekrystalizowac nowe ziarno ??
                    if (dyslokacje[i, j] >= romax && Curr[i,j]==0)
                    {
                        Curr[i, j] = iterrekr;
                        dyslokacje[i, j] = 0;
                        iterrekr++;
                       // Console.Write(dyslokacje[i, j]);
                    }
                }
                //Console.Write("\n");
            }
            switch (wybors)
            {
                case 0:
                    Moore(Prev, Curr, Kolor);
                    break;
                case 1:
                    vonNeuman(Prev, Curr, Kolor);
                    break;
                case 2:
                    hexleft(Prev, Curr, Kolor);
                    break;
                case 3:
                    hexright(Prev, Curr, Kolor);
                    break;
                case 4:
                    hexrand(Prev, Curr, Kolor);
                    break;
                case 5:
                    pentleft(Prev, Curr, Kolor);
                    break;
                case 6:
                    pentright(Prev, Curr, Kolor);
                    break;
                case 7:
                    pentup(Prev, Curr, Kolor);
                    break;
                case 8:
                    pentdown(Prev, Curr, Kolor);
                    break;
                case 9:
                    pentrand(Prev, Curr, Kolor);
                    break;
                default:
                    string message = "Nie wybrano typu sasiedztwa. Wybierz sąsiedztwo i naciśnij przycisk START.";
                    string caption = "Błąd";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon Icon = MessageBoxIcon.Error;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, Icon);
                    break;
            }
        }

        private void loadData()
        {
            int n = int.Parse(textBox1.Text);
           
            try
            {
                using (StreamReader sr = new StreamReader("dane.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        dislocDensity.Add(double.Parse(line, CultureInfo.InvariantCulture) * double.Parse(line, CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Blad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // double criticDensity = dislocDensity[Convert.ToInt32(textBox3.Text)] / (n * n);
            romax = Convert.ToDouble(textBox4.Text);
            //romax = Math.Pow(1042.12,2);
            //romax = 1042.12;
        }

        public void run()
        {
            Random rnd = new Random();
            int n = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            int s = pictureBox1.Width / n;
            int[,] Prev;
            Prev = new int[n + 2, n + 2];
            int[,] Curr;
            Curr = new int[n + 2, n + 2];
            Color[] Kolor;
            Kolor = new Color[k+12];
            Kolor[0] = Color.White;
            for (int i = 1; i <= k+11; i++)
            {
                Kolor[i] = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }

            for (int i = 0; i <= n + 1; i++)
            {
                for (int j = 0; j <= n + 1; j++)
                {
                    Prev[i, j] = 0;
                    Curr[i, j] = 0;
                }

            }
            int wyborlos = Convert.ToInt32(label3.Text);

            switch (wyborlos)
            {
                case 0:
                    losuj(Curr, Kolor);
                    break;
                case 1:
                    rownomiernie(Curr, Kolor);
                    break;
                case 2:
                    zpromieniem(Curr, Kolor);
                    break;
                case 3:
                    myszka(Curr, Kolor);
                    break;
                default:
                    string message = "Nie wybrano rozmieszczenia ziaren. Wybierz rozmieszczenie ziaren i naciśnij przycisk START.";
                    string caption = "UPS! Something is wrong";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon Icon = MessageBoxIcon.Error;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, Icon);
                    break;
            }
                      
            rysuj(Curr, Kolor);
             //index od 0 
            int wybors = Convert.ToInt32(label4.Text);                        
            switch (wybors)
            {
                case 0:
                    Moore(Prev, Curr, Kolor);
                    break;
                case 1:
                    vonNeuman(Prev, Curr, Kolor);
                    break;
                case 2:
                    hexleft(Prev, Curr, Kolor);
                    break;
                case 3:
                    hexright(Prev, Curr, Kolor);
                    break;
                case 4:
                    hexrand(Prev, Curr, Kolor);
                    break;
                case 5:
                    pentleft(Prev, Curr, Kolor);
                    break;
                case 6:
                    pentright(Prev, Curr, Kolor);
                    break;
                case 7:
                    pentup(Prev, Curr, Kolor);
                    break;
                case 8:
                    pentdown(Prev, Curr, Kolor);
                    break;
                case 9:
                    pentrand(Prev, Curr, Kolor);
                    break;
                default:
                    string message = "Nie wybrano typu sasiedztwa. Wybierz sąsiedztwo i naciśnij przycisk START.";
                    string caption = "Błąd";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon Icon = MessageBoxIcon.Error;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons, Icon);
                    break;
            }
                                    
            //rysuj(Prev, Curr, Kolor);
        }

        public void runrekrystal()
        {
            int n = int.Parse(textBox1.Text);
            //TODO: zrobic jakos cos zeby rekrystlizacja dzialala.
            //



            int[,] Currr = new int[n + 2, n + 2];
            int[,] Prevr = new int[n + 2, n + 2];
            double [,] border = new double [n+2,n+2];
            double [,] dyslokacje = new double [n+2,n+2];
           // double romax = 4215840142323.42/(n*n);
           // double A = 86710969050178.5;
           // double B = 9.41268203527779;
            double row = 0;
            double rokom = 0;
            getborder(border);
            Random rnd = new Random();
            Color[] Kolor;
            Kolor = new Color[n * n];
            Kolor[0] = Color.White;
            for (int i = 1; i < n * n; i++)
            {
                Kolor[i] = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }


            if (checkBox2.Checked)
            {
                loadData();
                for (int i = 1; i <= 100; i++)
                {
                    row =dislocDensity[i];
                    rokom = row / (n * n);
                   // rokom = Math.Pow(dislocDensity[i], 2) - Math.Pow(dislocDensity[i - 1], 2) / 900;
                    rozlozdyslokacje(border, dyslokacje, rokom);
                    rekrystalizuj(dyslokacje, Currr, Prevr, Kolor);
                    Console.Write(i+" "+dislocDensity[i]+" "+row + " "+romax + " "+rokom+"\n");
                }
            }
            else
            {
                romax = 4215840142323.42 / (n * n);
                double A = 86710969050178.5;
                double B = 9.41268203527779;


                for (int i = 1; i < 200; i++)
                {
                    //row = (A / B + (1 - A / B) * Math.Exp(-B * (i * 0.001))) - (A / B + (1 - A / B) * Math.Exp(-B * ((i-1) * 0.001)));
                    row = (A / B + (1 - A / B) * Math.Exp(-B * (i * 0.001)));
                    rokom = row / (n * n);
                    //rokom = row;
                    rozlozdyslokacje(border, dyslokacje, rokom);
                    rekrystalizuj(dyslokacje, Currr, Prevr, Kolor);
                  //  Console.Write(i * 0.001 + " " + row + " " + rokom + "\n");
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Start")
            {
                button1.Enabled = true;
                int wyborlos = comboBox2.SelectedIndex;
                int wybors = comboBox1.SelectedIndex;

                label3.Text = Convert.ToString(wyborlos);
                label4.Text = Convert.ToString(wybors);

                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                thrrozrost = new Thread(run);
                thrrozrost.Start();
                button2.Text = "Stop";
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        temp[i, j] = 0;
                    }
                }



                button1.Enabled = false;
                thrrozrost.Abort();
                button2.Text = "Start";
            }
          //  rysuj(Prev, Curr, Kolor);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Pause" && button3.Text=="Rekrystalizacja")
            {
                button2.Enabled = false;
                thrrozrost.Suspend();
                button1.Text = "Resume";
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j <= 1000; j++)
                    {
                        temp[i, j] = 0;
                    }
                }
            }
            else if (button1.Text == "Resume" && button3.Text=="Rekrystalizacja")
            {
                button2.Enabled = true;
                thrrozrost.Resume();
                flag = true;
                button1.Text = "Pause";
            }
            else if (button1.Text == "Resume" && button3.Text == "Stop")
                {
                button2.Enabled = true;
                thrrekrystal.Resume();
                button1.Text = "Pause";
            }
            else if (button1.Text == "Pause" && button3.Text == "Stop")
                {
                button2.Enabled = false;
                thrrekrystal.Suspend();
                button1.Text = "Resume";
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int k = int.Parse(textBox2.Text);
            Color[] MouseColour;
            MouseColour  = new Color[k+1];
            MouseColour[0] = Color.White;
            for (int i=1; i<k+1; i++)
            {
                MouseColour[i]=Color.Black;
            }
            Graphics g = pictureBox1.CreateGraphics();
            //g.Clear(Color.White);
            SolidBrush brush = new SolidBrush(Color.Black);
            int n = int.Parse(textBox1.Text);
            int sx = pictureBox1.Height / n;
            int sy = pictureBox1.Width / n;
            Point punkt=new Point();
            base.OnMouseClick(e);
            int c = 1;
            punkt.X = e.X;
            punkt.Y = e.Y;
                temp[(int)punkt.X/sx, (int)punkt.Y/sy] = c;

                rysuj(temp, MouseColour);
               /* for (int j = 0; j < n; j++)
                {
                    for (int f = 0; f<=n; f++)
                    {
                        if (temp[j, f] == i)
                        {
                            Rectangle rect = new Rectangle((int)punkt.X * sx, (int)punkt.Y * sy, sx, sy);
                        }
                    }
                }*/




        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Rekrystalizacja")
            {
                thrrekrystal = new Thread(runrekrystal);
                thrrekrystal.Start();
                thrrozrost.Abort();
                button3.Text = "Stop";
            }
            else
            {
                thrrekrystal.Abort();
                button3.Text = "Rekrystalizacja";
            }
        }
        
    }
}