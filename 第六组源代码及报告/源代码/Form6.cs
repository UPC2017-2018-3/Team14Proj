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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)//重置编辑内容
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            dateTimePicker1.ResetText();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = Userdata.Uname;
        }

        private void button5_Click(object sender, EventArgs e)//重置查询信息
        {
            textBox5.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name=textBox1.Text.Trim();
            string dno = textBox3.Text.Trim();
            string date = dateTimePicker1.Text.Trim();
            string tel = textBox2.Text.Trim();
            string type = comboBox1.Text.Trim();
            string note = textBox4.Text.Trim();
            if (dno == string.Empty || type == string.Empty || date == string.Empty || tel == string.Empty || note == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("insert into TL(Tname,Dno,Tdate,tel,type,Tsta,text)values('{0}','{1}','{2}','{3}','{4}','待受理','{5}')",name, dno, date, tel, type,note);
            try
            {
                connection.Open();//打开数据库
                SqlCommand cmd = new SqlCommand(sql, connection);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("提交成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("提交失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string type = comboBox2.Text.Trim();
            string sta = comboBox3.Text.Trim();
            string date = textBox5.Text.Trim();
            string strsql = "select Tno as 投诉编号,Tname as 投诉人,Text as 投诉内容,Dno as 房编号,Tdate as 投诉时间,type as 投诉类型,Tsta as 状态 from TL where 1=1";
            if (type != string.Empty)
            {
                strsql += " and type='" + type + "'";
            }
            if (sta != string.Empty)
            {
                strsql += " and Tsta='" + sta + "'";
            }
            if (date != string.Empty)
            {
                strsql += " and Tdate='" + date + "'";
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(strsql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    dataGridView1.DataSource = table;

                }
                else
                {
                    MessageBox.Show("查询信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker2.Text;
        }
    }
}
