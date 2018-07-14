using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class yhzx : Form
    {
        public yhzx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chaxunjgb form = new chaxunjgb();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chaxunjgb form = new chaxunjgb();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wdddb form = new wdddb();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xgmmb form = new xgmmb();
            form.Show();
            this.Hide();
        }
    }
}
