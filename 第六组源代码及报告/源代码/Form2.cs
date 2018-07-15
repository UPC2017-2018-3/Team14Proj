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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//注册账号
        {
            string no = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string pass = textBox3.Text.Trim();
            string sex = comboBox1.Text.Trim();
            string note = textBox4.Text.Trim();
            if (no == string.Empty || name == string.Empty || pass == string.Empty || sex == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("insert into GL(Gno,Gname,Gsex,Password,Note)values('{0}','{1}','{2}','{3}','{4}')",no,name,sex,pass,note);
            try
            {
                connection.Open();//打开数据库
                SqlCommand cmd = new SqlCommand(sql, connection);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("注册失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)//修改信息
        {
            string no = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string pass = textBox3.Text.Trim();
            string sex = comboBox1.Text.Trim();
            string note = textBox4.Text.Trim();
            if (no == string.Empty || name == string.Empty || pass == string.Empty || sex == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("UPDATE GL SET Gname='"+name+"',Gsex='"+sex+"',Password='"+pass+"',Note='"+note+"'where Gno='"+no+"'");
            try
            {
                connection.Open();//打开数据库
                SqlCommand cmd = new SqlCommand(sql, connection);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败，请检查账号是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button4_Click(object sender, EventArgs e)//信息查询
        {
            string no = textBox1.Text.Trim();
            if (no == string.Empty)
            {
                MessageBox.Show("请输入账号！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            string strsql = "select Gno,Gname,Password,Gsex,note from GL where Gno='" + no + "'";
             SqlCommand cmd = new SqlCommand(strsql,conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table= new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(table);
                if(table.Rows.Count>0)
                {
                    textBox2.Text=table.Rows[0][1].ToString();
                    textBox4.Text=table.Rows[0][4].ToString();
                    textBox3.Text=table.Rows[0][2].ToString();
                    comboBox1.Text=table.Rows[0][3].ToString();
                    
                    MessageBox.Show("查询信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
                else
                {
                    MessageBox.Show("查询信息失败","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)//删除
        {
            string no = textBox1.Text.Trim();
            if (no == string.Empty)
            {
                MessageBox.Show("请输入账号！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = String.Format("DELETE FROM GL WHERE Gno='"+textBox1.Text+"'");
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败,","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//重置
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
        }
    }
}
