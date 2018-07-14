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
            chaxunb form = new chaxunb();
            form.Show();
            this.Hide();
        }
    }
}
