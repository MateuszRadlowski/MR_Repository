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
    public partial class Mmenu : Form
    {
        public Mmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinglePlayer frmSP = new SinglePlayer();
            frmSP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Move left   [ <- ] \n Move right   [ -> ] \n Pause   [ Space ] \n Restart   [ R ]";
            string caption = "Sterowanie";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon Icon = MessageBoxIcon.Information;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, Icon);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MultiPlayer frmMP = new MultiPlayer();
            frmMP.Show();

        }
    }
}
