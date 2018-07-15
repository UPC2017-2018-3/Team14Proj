using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Welcome : Form
    {
        public static Login loginForm;
        public static Form wel=null;
        public Welcome()
        {
            InitializeComponent();
            loginForm = new Login();
            wel = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
