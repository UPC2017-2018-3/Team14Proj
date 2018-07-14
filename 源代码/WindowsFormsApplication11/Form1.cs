using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string type = comboBox1.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("登录账号或密码,身份不能为空！", "警告");
            }
            else
                if (comboBox1.Text == "管理员")
                {
                    string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "select * from dlb where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        glyjm form = new glyjm();
                        form.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("登录账号或密码错误！", "提示");
                    }
                    conn.Close();
                }
                else
                { 
                string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "select * from yhdlb where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        yhzx form = new yhzx();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("登录账号或密码错误！", "提示");
                    }
                    conn.Close();
                }
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zhuce form = new zhuce();
            form.Show();
            this.Hide();
        }

   
       
    }
}
