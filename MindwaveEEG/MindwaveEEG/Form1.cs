using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroSky.ThinkGear;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Media;

namespace MindwaveEEG
{
    public partial class Form1 : Form
    {
        private Connector Mindwave;
        public Form1()
        {
            InitializeComponent();
            Mindwave = new Connector();
            
        }

        DateTime TimeNow = DateTime.Now;

        string filename = "";
        string time = "";
        int EEGtime = 30;
        Thread thread1;
        Thread threadPB;
        Thread threadTEST;
        Thread threadSSVEP;
        Thread threadViewSound;
        int[] time_tab = new int[5] { 2, 5, 3, 7, 4 };
        int[] TEST1_tab = new int[5] { 5, 10, 15, 10, 15 };
        string[] TEST2_tab1 = new string[22] { "a", "c","e","f","g","h","i","j","k","l","m","n","o","r","s","t","u","v","w","x","y","z" };
        string[] TEST2_tab2 = new string[3] { "b", "d", "p" };
        int quan_c = 2;
        int iter = -1;
        int iter_vs = -1;
        int quan_vs = 2;
        int freq = 10;
        double PoorSignal = 0;
        int Delta = 0;
        int Theta=0;
        int LowAlpha = 0;
        int HighAlpha = 0;
        int LowBeta = 0;
        int HighBeta = 0;
        int LowGamma = 0;
        int HighGamma = 0;
        List<double> Deltalist = new List<double>();
        List<double> Thetalist = new List<double>();
        List<double> LAlfalist = new List<double>();
        List<double> HAlfalist = new List<double>();
        List<double> LBetalist = new List<double>();
        List<double> HBetalist = new List<double>();
        List<double> LGamalist = new List<double>();
        List<double> HGamalist = new List<double>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Connector Mindwave = new Connector();
            tabControl1.TabPages.Remove(r1);
            tabControl1.TabPages.Remove(r2);
            tabControl1.TabPages.Remove(r3);
            tabControl1.TabPages.Remove(r4);
        }

        void run()
        {
            PrepareHeadset("COM4");
        
        }

        void PrepareHeadset(string v_port)
        {
            Connector v_connector = new Connector();
            v_connector.setBlinkDetectionEnabled(true);
            v_connector.DeviceConnected += delegate(object sender2, EventArgs e2)
            {
                OnDeviceConnected(sender2, e2);
            };
            v_connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            v_connector.DeviceValidating += new EventHandler(OnDeviceValidating);
            v_connector.Connect(v_port);
      
        }

        void OnDeviceConnected(object sender, EventArgs e)
        {
            Connector test = (Connector)sender;
            Connector.DeviceEventArgs deviceEventArgs = (Connector.DeviceEventArgs)e;

            deviceEventArgs.Device.DataReceived += delegate(object sender2, EventArgs e2)
            {
                OnDataReceived(sender2, e2);
            };
        }

        void OnDataReceived(object sender, EventArgs e)
        {
            Device d = (Device)sender;
            Device.DataEventArgs de = (Device.DataEventArgs)e;

         
                TGParser tgParser = new TGParser();
                tgParser.Read(de.DataRowArray);

           

                for (int i = 0; i < tgParser.ParsedData.Length; i++)
                {
                    if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                    {
                        PoorSignal = tgParser.ParsedData[i]["PoorSignal"];
                        if (PoorSignal > 52 && PoorSignal < 80)
                            pictureBox1.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\connecting2_v1.png");
                        if (PoorSignal <= 52)
                            pictureBox1.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\connected_v1.png");
                        else
                            pictureBox1.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\nosignal_v1.png");
                    }


                    if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                    {
                        Deltalist.Add(tgParser.ParsedData[i]["EegPowerDelta"]);
                    
                        Delta++;
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerTheta"))
                    {
                        Thetalist.Add(tgParser.ParsedData[i]["EegPowerTheta"]);
                        // Console.WriteLine("Theta: " +  Thetalist[Theta]);
                        Theta++;
                        //thetawriter.WriteLine(Theta);
                        //label10.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha1"))
                    {
                        LAlfalist.Add(tgParser.ParsedData[i]["EegPowerAlpha1"]);
                        // Console.WriteLine("Low Alpha: " + LAlfalist[LowAlpha]);
                        LowAlpha++;
                        //label11.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha2"))
                    {
                        HAlfalist.Add(tgParser.ParsedData[i]["EegPowerAlpha2"]);
                        // Console.WriteLine("High Alpha: " + HAlfalist[HighAlpha]);
                        HighAlpha++;
                        //label12.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta1"))
                    {
                        LBetalist.Add(tgParser.ParsedData[i]["EegPowerBeta1"]);
                        // Console.WriteLine("Low Beta: " + LBetalist[LowBeta]);
                        LowBeta++;
                        //label13.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta2"))
                    {
                        HBetalist.Add(tgParser.ParsedData[i]["EegPowerBeta2"]);
                        // Console.WriteLine("High Beta: " + HBetalist[HighBeta]);
                        HighBeta++;
                        //label14.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma1"))
                    {
                        LGamalist.Add(tgParser.ParsedData[i]["EegPowerGamma1"]);
                        // Console.WriteLine("Low Gamma: " + LGamalist[LowGamma]);
                        //label15.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                        LowGamma++;
                    }
                    if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma2"))
                    {
                        HGamalist.Add(tgParser.ParsedData[i]["EegPowerGamma2"]);
                        //Console.WriteLine("High Gamma: " + HGamalist[HighGamma]);
                        //label16.Text = Convert.ToString(tgParser.ParsedData[i]["EegPowerDelta"]);
                        HighGamma++;
                    }

                    
            }
        }
        void OnDeviceFail(object sender, EventArgs e)
        {
            string message = "Brak połączenia z urządzeniem";
            string caption = ":-(";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon Icon = MessageBoxIcon.Error;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, Icon);
        }

        void OnDeviceValidating(object sender, EventArgs e)
        {
            Console.WriteLine("Validating: ");

           
        }

        public void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(run);
            thread1.Start();
            threadPB = new Thread(progressBarEEG);
            threadPB.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeNow=DateTime.Now;
           // time=TimeNow.ToString();
            time = TimeNow.Hour + "_" + TimeNow.Minute;
            Connector Mindwave = new Connector();
            Mindwave.Close();
            Mindwave.Disconnect();
            //POZOR POZOR
            thread1.Abort();
            StreamWriter deltawriter = new StreamWriter("delta.txt");
            StreamWriter thetawriter = new StreamWriter("theta.txt");
            StreamWriter lalfawriter = new StreamWriter("lalfa.txt");
            StreamWriter halfawriter = new StreamWriter("halfa.txt");
            StreamWriter lbetawriter = new StreamWriter("lbeta.txt");
            StreamWriter hbetawriter = new StreamWriter("hbeta.txt");
            StreamWriter lgamawriter = new StreamWriter("lgama.txt");
            StreamWriter hgamawriter = new StreamWriter("hgama.txt");
            StreamWriter aleegwriter = new StreamWriter(time+"_"+filename+"_"+"aleeg.txt");


            aleegwriter.WriteLine(TimeNow.ToString());
            aleegwriter.WriteLine("Delta Theta LowAlpha HighAlpha LowBeta HighBeta LowGamma HighGamma");

            for (int i = 0; i < Delta; i++)
            {
                deltawriter.WriteLine(Deltalist[i]);
                thetawriter.WriteLine(Thetalist[i]);
                lalfawriter.WriteLine(LAlfalist[i]);
                halfawriter.WriteLine(HAlfalist[i]);
                lbetawriter.WriteLine(LBetalist[i]);
                hbetawriter.WriteLine(HBetalist[i]);
                lgamawriter.WriteLine(LGamalist[i]);
                hgamawriter.WriteLine(HGamalist[i]);
                aleegwriter.WriteLine(Deltalist[i] + " " + Thetalist[i] + " " + LAlfalist[i] + " " + HAlfalist[i] + " " + LBetalist[i] + " " + HBetalist[i] + " " + LGamalist[i] + " " + HGamalist[i]);
            }

            
            deltawriter.Close();
            thetawriter.Close();
            lalfawriter.Close();
            halfawriter.Close();
            lbetawriter.Close();
            hbetawriter.Close();
            lgamawriter.Close();
            hgamawriter.Close();
            aleegwriter.Close();

            string message = "Zapis zakończony sukcesem";
            string caption = ":-)";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon Icon = MessageBoxIcon.Information;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, Icon);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connector Mindwave = new Connector();
            Mindwave.Close();
            Mindwave.Disconnect();
            thread1.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "SSVEP START")
            {
                threadSSVEP = new Thread(runSSVEP);
                threadSSVEP.Start();
                thread1.Start();
                button4.Text = "SSVEP STOP";
            }
            else
            {
                threadSSVEP.Abort();
                button4.Text="SSVEP START";
            }
        }

        private void runSSVEP()
    {
        Graphics g = pictureBox2.CreateGraphics();
        g.Clear(Color.White);
        Stopwatch stoper = new Stopwatch();
        int step = 1000 / freq;
        while (true)
        {
            Thread.Sleep(step);
            g.Clear(Color.GreenYellow);
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\facebook_chat_sound.wav");
            simpleSound.Play();
            Thread.Sleep(step);
            g.Clear(Color.White);
        }
           
    }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            freq = trackBar1.Value;
            label2.Text = Convert.ToString(freq);   
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox3.CreateGraphics();
            g.Clear(Color.White);
            if (iter == -1)
            {

                Thread.Sleep(quan_c * 1000);

            }
            else
            {
                Thread.Sleep(time_tab[iter]*1000);
                iter++;
                if (iter > 4)
                    iter = 0;
                g.Clear(Color.Red);
                button11.Text = "CLICK";
            }
        }


        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            quan_c = trackBar2.Value;
            if (quan_c == 0)
            {
                iter = 0;
                label3.Text = "in order";

            }
            else
            {
                label3.Text = Convert.ToString(quan_c);
            }
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            quan_vs = trackBar3.Value;
            if (quan_vs == 0)
            {
                iter_vs = 0;
                label4.Text = "in order";
            }
            else
            {
                label4.Text = Convert.ToString(quan_vs);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                threadViewSound = new Thread(runViewSound);
                threadViewSound.Start();
                button15.Text = "View/Sound Test STOP";
                checkBox3.Checked = true;
            }
            else
            {
                threadViewSound.Abort();
                button15.Text="View/Sound Test Start";
                checkBox3.Checked = false;
            }
        }

        private void runViewSound()
        {
           
            Stopwatch stoper = new Stopwatch();
            while (true)
            {
                if (iter_vs == -1)
                {
                    Thread.Sleep(quan_vs * 1000 - quan_vs * 50);
                    if (checkBox1.Checked)
                    {
                        pictureBox4.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\a0.jpg");
                        Thread.Sleep(quan_vs * 50);
                        pictureBox4.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\blank.jpg");
                    }
                    if (checkBox2.Checked)
                    {
                        //Thread.Sleep(quan_vs * 1000);
                        SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\facebook_chat_sound.wav");
                        simpleSound.Play();
                        Thread.Sleep(quan_vs * 50);
                    }
                }
                else
                {
                    Thread.Sleep(time_tab[iter_vs] * 1000 - 150);
                    if (checkBox1.Checked)
                    {
                        
                        Console.Write(iter_vs+" :im ");
                        pictureBox4.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\a0.jpg");
                        Thread.Sleep(150);
                        pictureBox4.Image = new Bitmap(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\blank.jpg");
                    }
                    if (checkBox2.Checked)
                    {
                       // Thread.Sleep(time_tab[iter_vs] * 1000);
                        Console.Write(iter_vs + " :sd ");
                        SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\facebook_chat_sound.wav");
                        simpleSound.Play();
                        Thread.Sleep(150);
                    }
                    iter_vs++;
                    if (iter_vs > 4)
                        iter_vs = 0;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            filename = "TEST1";
            thread1 = new Thread(run);
            thread1.Start();
            threadTEST = new Thread(runTEST1);
            threadTEST.Start();
            threadPB = new Thread(progressBarTEST1);
            threadPB.Start();
            button16.Enabled = false;
            
            
        }
        private void progressBarTEST1()
        {
            int i = 1;
            Thread.Sleep(6000);
          /*  while (i < 1000)
            {
                progressBar1.Invoke(new Action(delegate()
                {
                    progressBar1.Value = i;
                }));
                Thread.Sleep(6);
                i++;
            }
            i = 1;*/
            while (i < 1000)
            {
                progressBar1.Invoke(new Action (delegate()
                {
                    progressBar1.Value = i;
                }));
                Thread.Sleep(60);
                i++;
            }
        }

        private void progressBarEEG()
        {

            progressBar3.Invoke(new Action(delegate()
                {
                    progressBar3.Maximum = EEGtime * 1000;
                }));

            int i = 1;
            Thread.Sleep(6000);
            while (i < EEGtime*1000)
            {
                progressBar3.Invoke(new Action(delegate()
                {
                    progressBar3.Value = i;
                }));
                Thread.Sleep(1);
                i++;
            }
        }

        private void runTEST1()
        {
            Thread.Sleep(6000);
            Deltalist.Add(-1);
            Thetalist.Add(-1);
            LAlfalist.Add(-1);
            HAlfalist.Add(-1);
            LBetalist.Add(-1);
            HBetalist.Add(-1);
            LGamalist.Add(-1);
            HGamalist.Add(-1);
            Console.Write(filename + "  START");
            int i = 0;
            while (i<5)
            {
                Thread.Sleep(TEST1_tab[i] * 1000);
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Mateusz\documents\visual studio 2012\Projects\MindwaveEEG\MindwaveEEG\Resources\facebook_chat_sound.wav");
                simpleSound.Play();
                i++;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Connector Mindwave = new Connector();
            Mindwave.Close();
            Mindwave.Disconnect();
            thread1.Abort();
            threadTEST.Abort();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            filename = "TEST2";
            thread1 = new Thread(run);
            thread1.Start();
            threadTEST = new Thread(runTEST2);
            threadTEST.Start();
            threadPB = new Thread(progressBarTEST2);
            threadPB.Start();
            button16.Enabled = false;
        }

        private void progressBarTEST2()
        {
            Thread.Sleep(6000);

            int i = 1;
          /*  while (i < 1000)
            {
                progressBar2.Invoke(new Action(delegate()
                {
                    progressBar1.Value = i*10;
                }));
                Thread.Sleep(6);
                i++;
            }
            i = 1;*/
            while (i < 60)
            {
                progressBar2.Invoke(new Action(delegate()
                {
                    progressBar2.Value = i;
                }));
                Thread.Sleep(1000);
                i++;
            }
        }

        private void runTEST2()
        {
            Thread.Sleep(6000);
            Deltalist.Add(-1);
            Thetalist.Add(-1);
            LAlfalist.Add(-1);
            HAlfalist.Add(-1);
            LBetalist.Add(-1);
            HBetalist.Add(-1);
            LGamalist.Add(-1);
            HGamalist.Add(-1);
            Console.Write(filename + "  START");
            string letter = "";
            int i = 1;
            //int j = 0;
            while (i < 60)
            {
                Random rnd = new Random();
                Console.Write(i + " ");
                if (i==5 || i==15 || i==30 || i==40 || i==55 )
                {
                    letter = TEST2_tab2[rnd.Next(0, 3)];                   
                }
                else
                {

                    letter = TEST2_tab1[rnd.Next(0, 22)];
                }
                label9.Invoke(new Action(delegate()
                    {
                        label9.Text = letter;
                    }));
                Thread.Sleep(300);
                label9.Invoke(new Action(delegate()
                    {
                        label9.Text = " ";
                    }));
                Thread.Sleep(700);
                i++;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            EEGtime += 10;
            label11.Text = EEGtime.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (EEGtime>0)
            {
            EEGtime -= 10;
            label11.Text = EEGtime.ToString();
            }
        }

      //END  
    }
}
