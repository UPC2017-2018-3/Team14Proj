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
    public partial class UserForm : Form
    {
        public static Form5 form5;
        public static Form6 form6;
        public UserForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome.wel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Welcome.wel.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "你好，" + Userdata.Uname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form5 = new Form5();//费用查询
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form6 = new Form6();//投诉
            form6.Show();
        }
    }
}
