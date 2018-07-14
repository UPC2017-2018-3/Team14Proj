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
    public partial class xglx : Form
    {
        private string connStr = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";

        public xglx()
        {
            InitializeComponent();
        }
        private void xglx_Load(object sender, EventArgs e)
        {
            string _sql = "select 车次,出行方式,出发地,出发时间,目的地,到达时间,余票,价格 from chaxunjgb";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(_sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellEventArgs e)
        {
            //获得选中的记录行
            DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];
            //获得行单元集合
            DataGridViewCellCollection dgvCC = dgvRow.Cells;
            //获得单元格数据
            textBox8.Text = dgvCC[0].Value.ToString();
            textBox1.Text = dgvCC[1].Value.ToString();
            textBox2.Text = dgvCC[2].Value.ToString();
            textBox6.Text = dgvCC[3].Value.ToString();
            textBox3.Text = dgvCC[4].Value.ToString();
            textBox7.Text = dgvCC[5].Value.ToString();
            textBox4.Text = dgvCC[6].Value.ToString();
            textBox5.Text = dgvCC[7].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox7.Text = dateTimePicker2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _sql = "select count(*)from chaxunjgb where 车次='" + textBox8.Text + "'";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(_sql, conn);
            //检查有无此车次记录
            try
            {
                conn.Open();
              
                int cnt = (int)cmd.ExecuteScalar();
                if (cnt == 1)
                {
                    MessageBox.Show("更新成功!");
                    _sql = "update chaxunjgb set 车次='"
                        + textBox8.Text + "',出行方式='"
                        + textBox1.Text + "',出发地='"
                        + textBox2.Text + "',出发时间='"
                        + textBox6.Text + "',目的地='"
                        + textBox3.Text + "',到达时间='"
                        + textBox7.Text + "',余票='"
                        + textBox4.Text + "',价格='"
                        + textBox5.Text + "'where 车次='" + textBox8.Text + "'";
                }
                //添加新记录
                else
                {
                    _sql = "insert into chaxunjgb values('" 
                        + textBox8.Text + "','"
                        + textBox1.Text + "','"
                        + textBox2.Text + "','"
                        + textBox6.Text + "','"
                        + textBox3.Text + "','" 
                        + textBox7.Text + "','" 
                        + textBox4.Text + "','" 
                        + textBox5.Text + "')";
                }
                cmd = new SqlCommand(_sql, conn);
                cmd.ExecuteNonQuery();
                
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要删除吗？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Cancel)
            {
                return;
            }
            string _sql = "delete from chaxunjgb where 车次='" + textBox8.Text + "'";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(_sql, conn);
            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            { conn.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            glyjm form = new glyjm();
            form.Show();
            this.Hide();
        }

        
            private void button4_Click(object sender, EventArgs e)
        {
           string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
            DataSet myst = new DataSet();
            SqlDataAdapter myda;
            SqlConnection con = new SqlConnection(str);
            con.Open();
                string sql = "SELECT*FROM chaxunjgb";
                SqlCommand command = new SqlCommand(sql,con);
                myda = new SqlDataAdapter(command);
                myst.Tables.Clear();
                myda.Fill(myst, "chaxunjgb");
                dataGridView1.DataSource = myst.Tables["chaxunjgb"];
            
        }

        }
    }
