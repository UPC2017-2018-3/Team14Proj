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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";  
        }

        private void button1_Click(object sender, EventArgs e)//添加费用
        {
            string no = textBox1.Text.Trim();
            string dno = textBox2.Text.Trim();
            string pr = textBox3.Text.Trim();
            string date="";
            if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                date=comboBox2.Text.Trim() + "年" + comboBox3.Text.Trim() + "月";
            }
            string type = comboBox1.Text.Trim();
            string sta = comboBox4.Text.Trim();
            if (no == string.Empty || dno == string.Empty || type == string.Empty || date == string.Empty || pr == string.Empty || sta == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("insert into CL(Cno,Dno,type,Cp,Cdate,Csta)values('{0}','{1}','{2}','{3}','{4}','{5}')", no, dno, type, pr, date,sta);
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

        private void button2_Click(object sender, EventArgs e)//修改费用表
        {
            string no = textBox1.Text.Trim();
            string dno = textBox2.Text.Trim();
            string pr = textBox3.Text.Trim();
            string date = "";
            if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                date = comboBox2.Text.Trim() + "月" + comboBox3.Text.Trim() + "日";
            }
            string type = comboBox1.Text.Trim();
            string sta = comboBox4.Text.Trim();
            if (no == string.Empty || dno == string.Empty || pr == string.Empty || type == string.Empty || date == string.Empty || sta == string.Empty)//检测信息完整度
            {
                MessageBox.Show("请将信息输入完整！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = string.Format("UPDATE CL SET Cno='" + no + "',Dno='" + dno + "',Cp='" + pr + "',Cdate='" + date + "',Csta='" + sta + "'where Cno='" + no + "'");
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

        private void button3_Click(object sender, EventArgs e)
        {
            string no = textBox1.Text.Trim();
            if (no == string.Empty)
            {
                MessageBox.Show("请输入编号！", "提示");
                return;
            }
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strcon);
            string sql = String.Format("DELETE FROM CL WHERE Cno='" + textBox1.Text + "'");
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

        private void button4_Click(object sender, EventArgs e)//查询费用
        {
            string no = textBox1.Text.Trim();
            string dno = textBox2.Text.Trim();
            string pr = textBox3.Text.Trim();
            string type = comboBox1.Text.Trim();
            string date="";
            if (comboBox2.Text != "" && comboBox3.Text != "") {date = comboBox2.Text.Trim() + "年" + comboBox3.Text.Trim() + "月"; }
            string sta = comboBox4.Text.Trim();
            string strsql = "select Cno as 费用编号,Dno as 房编号,type as 费用类型,Cp as 价格,Cdate as 费用年月,Csta as 缴费状态 from CL where 1=1";
            if (no != string.Empty)
            {
                strsql += " and Cno='" + no + "'";
            }
            if (dno != string.Empty)
            {
                strsql += " and Dno='" + dno + "'";
            }
            if (type != string.Empty)
            {
                strsql += " and type='" + type + "'";
            }
            if (pr != string.Empty)
            {
                strsql += " and Cp='" + pr + "'";
            }
            if (date != string.Empty)
            {
                strsql += " and Cdate='" + date + "'";
            }
            if (sta != string.Empty)
            {
                strsql += " and Csta='" + sta + "'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            string date = dataGridView1.Rows[i].Cells[4].Value.ToString();
            string[] da = date.Split(new string[] { "年", "月" }, StringSplitOptions.RemoveEmptyEntries);
            comboBox2.Text = da[0];
            comboBox3.Text = da[1];
            comboBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }
    }
}
