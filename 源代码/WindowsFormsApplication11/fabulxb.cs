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
    public partial class fabulxb : Form
    {

        public fabulxb()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入出行方式 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入出发地 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dateTimePicker1.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入出发时间！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox3.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入目的地 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dateTimePicker2.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入到达时间 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox5.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入车票数量 ！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox4.Text == string.Empty)
                {
                    MessageBox.Show(this, "     请输入车票价格！    ", "Phoenix Information:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string str = "Data Source=DESKTOP-H6GDTOQ\\SQLEXPRESS;Initial Catalog=slfsql;Integrated Security=True";
                DataSet myst=new DataSet();
                SqlDataAdapter myda;
                SqlConnection con = new SqlConnection(str);
                try
                {
                    string chuxing = textBox1.Text.Trim();
                    string chufadi = textBox2.Text.Trim();
                    string stshijian = dateTimePicker1.Text.Trim();
                    string mudidi = textBox3.Text.Trim();
                    string ddshijian = dateTimePicker2.Text.Trim();
                    string yupiao = textBox5.Text.Trim();
                    string jiage = textBox4.Text.Trim();
                    string checi = textBox6.Text.Trim();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "insert into chaxunjgb(车次,出行方式,出发地,出发时间,目的地,到达时间,余票,价格)values('"
                 + checi + "','"
                  + chuxing + "','"
                 + chufadi + "','"
                 + stshijian + "','"
                 + mudidi + "','"
                 + ddshijian + "','"
                 + yupiao + "','"
                 + jiage + "')";
                    command.CommandType = CommandType.Text;
                    command.Connection = con;
                    con.Open();
                    myda = new SqlDataAdapter(command);
                  
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("添加成功!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("添加失败!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            glyjm form = new glyjm();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void fabulxb_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“slfsqlDataSet.chaxunjgb”中。您可以根据需要移动或删除它。
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
            {

            }

        }

        

       

    }
