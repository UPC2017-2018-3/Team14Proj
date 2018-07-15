using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Login : Form
    {
        public static MForm mainForm;
        public static UserForm UForm;
        public Login()
        {
            InitializeComponent();
        }

        private void CeBtn_Click(object sender, EventArgs e)
        {
            tUser.Clear();
            tPwd.Clear();
        }

        private void DeBtn_Click(object sender, EventArgs e)
        {
            if (tUser.Text == string.Empty)
            {
                MessageBox.Show("请输入用户名！", "提示");
                return;
            }
            if (tPwd.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！", "提示");
                return;
            }
            if (radioButton1.Checked)
            {
                string username = tUser.Text.Trim();
                string password = tPwd.Text.Trim();
                string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
                SqlConnection connection = new SqlConnection(strcon);
                //管理员登录
                string Sql = String.Format("select count(*) from GL where Gno='{0}' and Password='{1}'", username, password);
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(Sql, connection);
                    int num = (int)cmd.ExecuteScalar();
                    if (num <= 0)
                    {
                        MessageBox.Show("用户名或密码不正确！", "提示");
                    }
                    else
                    {
                        SqlDataAdapter na = new SqlDataAdapter("select Gname from GL where Gno='" + username + "'", connection);
                        DataSet ds = new DataSet();
                        na.Fill(ds);
                        Userdata.Uname = ds.Tables[0].Rows[0][0].ToString().Trim();
                        Userdata.Uid = username;
                        MessageBox.Show("登录成功！", "提示");
                        mainForm = new MForm();
                        mainForm.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                //普通用户登录
                string username = tUser.Text.Trim();
                string password = tPwd.Text.Trim();
                string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
                SqlConnection connection = new SqlConnection(strcon);
                string Sql = String.Format("select count(*) from YL where Yno='{0}' and Password='{1}'", username, password);
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(Sql, connection);
                    int num = (int)cmd.ExecuteScalar();
                    if (num <= 0)
                    {
                        MessageBox.Show("用户名或密码不正确！", "提示");
                    }
                    else
                    {
                        SqlDataAdapter na = new SqlDataAdapter("select Yname,Dno from YL where Yno='" + username + "'", connection);
                        DataSet ds = new DataSet();
                        na.Fill(ds);
                        Userdata.Uname = ds.Tables[0].Rows[0][0].ToString().Trim();
                        Userdata.Dno = ds.Tables[0].Rows[0][1].ToString().Trim();
                        Userdata.Uid = username;
                        MessageBox.Show("登录成功！", "提示");
                        UForm = new UserForm();
                        UForm.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Welcome.wel.Show();
            this.Hide();
            e.Cancel = true;
        }
    }
    public static class Userdata//静态变量传递用户数据
    {
        public static string Uname;
        public static string Uid;
        public static string Dno;
    }
}
