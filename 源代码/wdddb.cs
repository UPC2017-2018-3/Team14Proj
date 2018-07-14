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
    public partial class wdddb : Form
    {
        private string connStr = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";

        public wdddb()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 

        private void wdddb_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“slfsqlDataSet1.wdddb”中。您可以根据需要移动或删除它。
            this.wdddbTableAdapter.Fill(this.slfsqlDataSet1.wdddb);

        }

        private void button1_Click(object sender, EventArgs e)
        {
             int a = dataGridView1.CurrentRow.Index;

            string _sql = "delete from wdddb where 姓名= '" + dataGridView1.Rows[a].Cells[0].Value + "' and 身份证号='" + dataGridView1.Rows[a].Cells[1].Value + "' and 车次='" + dataGridView1.Rows[a].Cells[2].Value + "'";
            //连接字符串
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(_sql, conn);
            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    MessageBox.Show("退票成功", "提示！");

                }
                else
                {
                    MessageBox.Show("退票失败!");
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
            chaxunjgb form = new chaxunjgb();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yhzx form = new yhzx();
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
            string sql = "SELECT*FROM wdddb";
            SqlCommand command = new SqlCommand(sql, con);
            myda = new SqlDataAdapter(command);
            myst.Tables.Clear();
            myda.Fill(myst, "wdddb");
            dataGridView1.DataSource = myst.Tables["wdddb"];
        }
        }
    }
