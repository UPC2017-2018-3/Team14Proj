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
    public partial class Formasd : Form
    {
        public Formasd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no =textBox1.Text.Trim();
            
            string strcon = "Data Source=.\\sqlexpress;Initial Catalog=psql;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            string strsql = "select Yno as xxxx,Yname,Dno,Ysex,Ydate,Yid,Ytel,note,password from YL where Ysex='" + no + "'";
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
    }
}
