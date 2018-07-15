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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = textBox1.Text.Trim();
            string type = comboBox1.Text.Trim();
            string date = "";
            if (comboBox2.Text != "" && comboBox3.Text != "") { date = comboBox2.Text.Trim() + "年" + comboBox3.Text.Trim() + "月"; }
            string sta = comboBox4.Text.Trim();
            string strsql = "select Cno as 费用编号,Dno as 房编号,type as 费用类型,Cp as 价格,Cdate as 费用年月,Csta as 缴费状态 from CL where Dno='"+Userdata.Dno+"'";
            if (no != string.Empty)
            {
                strsql += " and Cno='" + no + "'";
            }
            if (type != string.Empty)
            {
                strsql += " and type='" + type + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            string date = dataGridView1.Rows[i].Cells[4].Value.ToString();
            string[] da = date.Split(new string[] { "年", "月" }, StringSplitOptions.RemoveEmptyEntries);
            comboBox2.Text = da[0];
            comboBox3.Text = da[1];
            comboBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }
    }
}
