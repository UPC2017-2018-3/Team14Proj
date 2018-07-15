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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//添加业主
        {
            string no = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string dno = textBox3.Text.Trim();
            string sex = comboBox1.Text.Trim();
            string id = textBox4.Text.Trim();
            string date = textBox8.Text.Trim();
            string tel = textBox5.Text.Trim();
            string pass = textBox6.Text.Trim();
            string note = textBox7.Text.Trim();
            if (no == string.Empty || name == string.Empty || pass == string.Empty || sex == string.Empty||id== string.Empty ||date== string.Empty ||tel== string.Empty ||dno== string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("insert into YL(Yno,Dno,Yname,Ysex,Ydate,Yid,Ytel,Password,Note)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", no,dno, name, sex,date,id,tel, pass, note);
            try
            {
                connection.Open();//打开数据库
                SqlCommand cmd = new SqlCommand(sql, connection);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)//查询信息
        {
            string no = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string dno = textBox3.Text.Trim();
            string sex = comboBox1.Text.Trim();
            string id = textBox4.Text.Trim();
            string tel = textBox5.Text.Trim();
            string note = textBox7.Text.Trim();
            string pass = textBox6.Text.Trim();
            string date = textBox8.Text.Trim();
            string strsql = "select Yno as 业主编号,Yname as 姓名,Dno as 房编号,Ysex as 性别,Ydate as 入住日期,Yid as 证件号码,Ytel as 联系方式,note as 备注,password as 登录密码 from YL where 1=1";
            if (no != string.Empty)
            {
                strsql += " and Yno='" + no+"'";
            }
            if (name != string.Empty)
            {
                strsql += " and Yname='"+name+"'";
            }
            if (dno != string.Empty)
            {
                strsql += " and Dno='"+dno+"'";
            }
            if (sex != string.Empty)
            {
                strsql += " and Ysex='"+sex+"'";
            }
            if (id != string.Empty)
            {
                strsql += " and Yid='"+id+"'";
            }
            if (tel != string.Empty)
            {
                strsql +=" and Ytel='"+ tel+"'";
            }
            if (date != string.Empty)
            {
                strsql += " and Ydate='"+date+"'";
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

        private void button5_Click(object sender, EventArgs e)//重置
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)//修改信息
        {
            string no = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string dno = textBox3.Text.Trim();
            string sex = comboBox1.Text.Trim();
            string id = textBox4.Text.Trim();
            string tel = textBox5.Text.Trim();
            string note = textBox7.Text.Trim();
            string pass = textBox6.Text.Trim();
            string date = textBox8.Text.Trim();
            if (no == string.Empty || name == string.Empty || dno == string.Empty || sex == string.Empty || id == string.Empty || tel == string.Empty || date == string.Empty || pass == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql ="UPDATE YL SET Yname='" + name + "',Ysex='" + sex + "',dno='" + dno + "',Yid='" + id + "',Ytel='" + tel + "',Ydate='" + date + "',Password='" + pass + "',Note='" + note + "'where Yno='" + no + "'";
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
                    MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button4_Click_1(object sender, EventArgs e)//删除
        {
            string no = textBox1.Text.Trim();
            if (no == string.Empty)
            {
                MessageBox.Show("请输入编号！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = String.Format("DELETE FROM YL WHERE Yno='" + textBox1.Text + "'");
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
                    MessageBox.Show("删除失败,", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox8.Text = dateTimePicker1.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }
    }
}
