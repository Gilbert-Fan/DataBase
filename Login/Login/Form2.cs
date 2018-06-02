using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.Student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.mainProjectDataSet.Student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();
            String StuName = textBox2.Text.Trim();
            String StuSex = textBox3.Text.Trim();
            String StuAge = textBox4.Text.Trim();
            String StuSdept = textBox5.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  Student (Sno,Sname,Ssex,Sage,Sdept)    " +
                    "VALUES ('" + StuID + "','" + StuName + "','" + StuSex + "','" + StuAge + "','" + StuSdept + "')";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Dispose();
            }
            this.studentTableAdapter.Fill(this.mainProjectDataSet.Student);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Student where Sno=" + select_id;//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("请正确选择行!");
            }
            finally
            {
                con.Dispose();
            }
            this.studentTableAdapter.Fill(this.mainProjectDataSet.Student);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();
            String StuName = textBox2.Text.Trim();
            String Ssex = textBox3.Text.Trim();
            String StuAge = textBox4.Text.Trim();
            String StuSdept = textBox5.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE Student SET Sname = '" + StuName + "',Ssex = '" + Ssex + "', Sage = '" + StuAge + "',Sdept = '" + StuSdept + "' WHERE Sno = '" + StuID + "'";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Dispose();
            }
            this.studentTableAdapter.Fill(this.mainProjectDataSet.Student);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Student where Sno='" + StuID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
