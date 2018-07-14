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
    public partial class xgmmb : Form
    {
        public xgmmb()
        {
            InitializeComponent();
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

                MessageBox.Show(this, "     请输入旧密码！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox3.Text == string.Empty)
            {

                MessageBox.Show(this, "     请输入新密码！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox4.Text == string.Empty)
            {

                MessageBox.Show(this, "     请确认新密码！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("两次输入的密码不一致!");
                
                return;
            }  


            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string newpassword = textBox3.Text.Trim();
            string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();

            string sql = string.Format("select count(*) from [yhdlb] where username='{0}' and password='{1}'", username, password);

            SqlCommand cmd = new SqlCommand(sql, con);
            int num = (int)cmd.ExecuteScalar();
            if (num > 0)
            {
               
                string sqll = "UPDATE yhdlb SET password='" + newpassword + "'where username='" + username + "'and password='" + password + "'";
                SqlCommand cmdd = new SqlCommand(sqll, con);
                cmdd.CommandText = sqll;
                cmdd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("修改失败，请确保用户名与密码正确！");
                xgmmb form = new xgmmb();
                form.Show();
                this.Hide();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yhzx form = new yhzx();
            form.Show();
            this.Hide();
        }
    }
}