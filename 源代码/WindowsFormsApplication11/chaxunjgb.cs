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
    public partial class chaxunjgb : Form
    {
        private string sql = "";
        private string connStr = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
        public chaxunjgb()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeSqlStr();
            string _sql = "select 车次,出行方式,出发地,出发时间,目的地,到达时间,余票,价格 from chaxunjgb where 1=1"
                + sql;
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(_sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void chaxunb_Load(object sender, EventArgs e)
        {
            string _sql = "select * from chaxunjgb";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(_sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        private void MakeSqlStr()
        {
            sql = "";
            if (textBox1.Text.Trim() != string.Empty)
            {
                sql = "and 出发地 like'%" + textBox1.Text.Trim() + "%'";
            }
            if (textBox2.Text.Trim() != string.Empty)
            {
                sql += "and 目的地 like'%" + textBox2.Text.Trim() + "%'";
            }
            if (textBox3.Text.Trim() != string.Empty)
            {
                sql += "and 出发时间 like'%" + textBox3.Text.Trim() + "%'";
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Text;
        }

        
        

         private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
         {
             textBox6.Text = dateTimePicker2.Text;
         }

         private void button1_Click(object sender, EventArgs e)
         {
             if (textBox12.Text == string.Empty)
             {
                 MessageBox.Show(this, "     请输入乘客姓名 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }
             if (textBox13.Text == string.Empty)
             {
                 MessageBox.Show(this, "     请输入乘客身份证号 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }
            
             SqlConnection conn = new SqlConnection(connStr);
            
            

                 
              if(textBox9.Text!="0")
             { SqlCommand cmd = new SqlCommand();
             cmd.CommandText="insert into wdddb(姓名,身份证号,车次,出行方式,出发地,出发时间,目的地,到达时间,余票,价格) values（'"
                            + textBox12.Text + "','"
                            + textBox13.Text + "','"
                            + textBox7.Text + "','"
                            + textBox8.Text + "','"
                            + textBox5.Text + "','"
                            + textBox4.Text + "','"
                            + textBox11.Text + "','"
                            + textBox6.Text + "','"
                            + textBox9.Text + "','"
                            + textBox10.Text + "'）";
                     cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
             MessageBox.Show("订票成功", "提示！");

             }
                 
 else
                 {
                     MessageBox.Show("订票失败", "提示！");
                 }
             
           
                 conn.Close();
             
             }
           
            
         

         private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
         {
             textBox4.Text = dateTimePicker3.Text;
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             
             //获得选中的记录行
             DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];
             //获得行单元集合
             DataGridViewCellCollection dgvCC = dgvRow.Cells;
             //获得单元格数据
             textBox7.Text = dgvCC[0].Value.ToString();
             textBox8.Text = dgvCC[1].Value.ToString();
             textBox5.Text = dgvCC[2].Value.ToString();
             textBox4.Text = dgvCC[3].Value.ToString();
             textBox11.Text = dgvCC[4].Value.ToString();
             textBox6.Text = dgvCC[5].Value.ToString();
             textBox9.Text = dgvCC[6].Value.ToString();
             textBox10.Text = dgvCC[7].Value.ToString();

         }
       
         }
           
           
        }

        
    

