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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Text;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string strsql = "select Tno as 投诉编号,Tname as 投诉人,Tsta as 状态,Text as 投诉内容,Dno as 房编号,Tdate as 投诉时间,type as 投诉类型,tel as 联系电话 from TL";
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(strsql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//查询
        {
            string no = textBox7.Text.Trim();
            string name = textBox1.Text.Trim();
            string tel = textBox2.Text.Trim();
            string dno = textBox3.Text.Trim();
            string sta = comboBox2.Text.Trim();
            string type = comboBox1.Text.Trim();
            string date = textBox6.Text.Trim();
            string note = textBox4.Text.Trim();
            string strsql = "select Tno as 投诉编号,Tname as 投诉人,Tsta as 状态,Text as 投诉内容,Dno as 房编号,Tdate as 投诉时间,type as 投诉类型,tel as 联系电话 from TL where 1=1";
            if (no != string.Empty)
            {
                strsql += " and Tno='" + no + "'";
            }
            if (type != string.Empty)
            {
                strsql += " and type='" + type + "'";
            }
            if (name != string.Empty)
            {
                strsql += " and Tname='" + name + "'";
            }
            if (dno != string.Empty)
            {
                strsql += " and Dno='" + dno + "'";
            }
            if (sta != string.Empty)
            {
                strsql += " and Tsta='" + sta + "'";
            }
            if (date != string.Empty)
            {
                strsql += " and Tdate='" + date + "'";
            }
            if (tel != string.Empty)
            {
                strsql += " and tel='" + tel + "'";
            }
            if (note != string.Empty)
            {
                strsql += " and Text like '%" + note + "%'";
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

        private void button1_Click(object sender, EventArgs e)//状态操作
        {
            if (comboBox2.Text.Trim() == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请选择受理状态！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql ="UPDATE TL SET Tsta='" + comboBox2.Text.Trim() + "'where Tno='" + textBox7.Text.Trim() + "'";
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
    }
}
