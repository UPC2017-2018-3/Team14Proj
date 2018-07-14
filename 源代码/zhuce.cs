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
    public partial class zhuce : Form
    {
        public zhuce()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == string.Empty)
            {

                MessageBox.Show(this, "     请输入用户名！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox2.Text == string.Empty)
            {

                MessageBox.Show(this, "     请输入密码！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox3.Text == string.Empty)
            {

                MessageBox.Show(this, "     密码不能为空！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string username = textBox1.Text.Trim();
            string code1 = textBox2.Text.Trim();
            string code2 = textBox3.Text.Trim();
            
            if (code1!=code2)
            {
             MessageBox.Show(this, "     两次输入的密码必须相同！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         else
            {
                string admin_id=textBox1.Text.Trim();
                string admin_psw=textBox2.Text.Trim();
                string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string sql = string.Format("select count(*) from [yhdlb] where username='{0}' and password='{1}'", username, code1);
                SqlCommand cmd = new SqlCommand(sql, con);
                int num = (int)cmd.ExecuteScalar();
                if (num > 0)
                {
                    MessageBox.Show("该用户名已被注册！请重新填写用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    zhuce form = new zhuce();
                    form.Show();
                    this.Hide();
                }
                else
                {
                SqlCommand command = new SqlCommand(); 
                    string sqll = string.Format("insert into yhdlb(username,password)values('{0}','{1}')", username, code1);
                    command.Connection = con;

                    SqlCommand cmdd = new SqlCommand(sqll, con);
                    int count = cmdd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("注册失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                con.Close();

            }
                }
            }
     
        }
    