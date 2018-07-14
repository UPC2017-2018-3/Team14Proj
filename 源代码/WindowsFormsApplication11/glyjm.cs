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
    public partial class glyjm : Form
    {
        public glyjm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fabulxb form = new fabulxb();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chaxunb form = new chaxunb();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xglx form = new xglx();
            form.Show();
            this.Hide();
        }
    }
}
