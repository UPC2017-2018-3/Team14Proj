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
    public partial class MForm : Form
    {
        public static Form Ma = null;
        public static Form1 form1;
        public static Form2 form2;
        public static Form3 form3;
        public static Form4 form4;
        public MForm()
        {
            InitializeComponent();
            Ma = this;
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "你好，" + Userdata.Uname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Form1();//业主信息
            form1.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //注销
            this.Hide();
            Welcome.wel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Welcome.wel.Close();//退出
        }

        private void button6_Click(object sender, EventArgs e)
        {
            form2 = new Form2();//管理员信息
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3();//管理员信息
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form4 = new Form4();//投诉管理
            form4.Show();
        }
    }
}
