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
    public partial class chaxunb : Form
    {
        //查询
        private string sql = "";
        private string connStr = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
        public chaxunb()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

            MakeSqlStr();
            string _sql = "select 车次,出发地,出发时间,目的地,到达时间,余票,价格 from chaxunjgb where 1=1"
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

       

       
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            glyjm form = new glyjm();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Text;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

       
    }
}
