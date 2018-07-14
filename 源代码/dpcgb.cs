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
    public partial class dpcgb : Form
    {
        public dpcgb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wdddb form = new wdddb();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           yhzx form = new yhzx();
            form.Show();
            this.Hide();
        }
    }
}
