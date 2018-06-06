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

namespace MainProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.ManagerPasswords”中。您可以根据需要移动或删除它。
            this.managerPasswordsTableAdapter.Fill(this.mainProjectDataSet.ManagerPasswords);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.Manager”中。您可以根据需要移动或删除它。
            this.managerTableAdapter.Fill(this.mainProjectDataSet.Manager);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.TeacherPasswords”中。您可以根据需要移动或删除它。
            this.teacherPasswordsTableAdapter.Fill(this.mainProjectDataSet.TeacherPasswords);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.StudentPasswords”中。您可以根据需要移动或删除它。
            this.studentPasswordsTableAdapter.Fill(this.mainProjectDataSet.StudentPasswords);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.SC”中。您可以根据需要移动或删除它。
            this.sCTableAdapter.Fill(this.mainProjectDataSet.SC);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.Course”中。您可以根据需要移动或删除它。
            this.courseTableAdapter.Fill(this.mainProjectDataSet.Course);
            // TODO: 这行代码将数据加载到表“mainProjectDataSet.Teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.mainProjectDataSet.Teacher);
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
            String TeachID = textBox6.Text.Trim();
            String TeachName = textBox7.Text.Trim();
            String TeachSex = textBox8.Text.Trim();
            String TeachAge = textBox9.Text.Trim();
            String TeachSdept = textBox10.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  Teacher (Tno,Tname,Tsex,Tage,Tdept)    " +
                    "VALUES ('" + TeachID + "','" + TeachName + "','" + TeachSex + "','" + TeachAge + "','" + TeachSdept + "')";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "输入数据违反要求!");
            }
            finally
            {
                con.Dispose();
            }
            this.teacherTableAdapter.Fill(this.mainProjectDataSet.Teacher);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Teacher where Tno=" + select_id;//sql删除语句
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
            this.teacherTableAdapter.Fill(this.mainProjectDataSet.Teacher);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String TeachID = textBox6.Text.Trim();
            String TeachName = textBox7.Text.Trim();
            String Teachsex = textBox8.Text.Trim();
            String TeachAge = textBox9.Text.Trim();
            String TeachSdept = textBox10.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE Teacher SET Tname = '" + TeachName + "',Tsex = '" + Teachsex + "', Tage = '" + TeachAge + "',Tdept = '" + TeachSdept + "' WHERE Tno = '" + TeachID + "'";
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
            this.teacherTableAdapter.Fill(this.mainProjectDataSet.Teacher);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String TeachID = textBox6.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Teacher where Tno='" + TeachID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView2.DataSource = bindingSource;
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

        private void button9_Click(object sender, EventArgs e)
        {
            String CourID = textBox11.Text.Trim();
            String CourName = textBox12.Text.Trim();
            String Courpno = textBox13.Text.Trim();
            String CourCredit = textBox14.Text.Trim();
            String TeachID = textBox15.Text.Trim();
            String TeachName = textBox16.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  Course (Cno,Cname,Cpno,Ccredit,Tno,Tname)    " +
                    "VALUES ('" + CourID + "','" + CourName + "','" + Courpno + "','" + CourCredit + "','" + TeachID + "','" + TeachName + "')";
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
            this.courseTableAdapter.Fill(this.mainProjectDataSet.Course);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Course where Cno=" + select_id;//sql删除语句
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
            this.courseTableAdapter.Fill(this.mainProjectDataSet.Course);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String CourID = textBox11.Text.Trim();
            String CourName = textBox12.Text.Trim();
            String Courpno = textBox13.Text.Trim();
            String CourCredit = textBox14.Text.Trim();
            String TeachID = textBox15.Text.Trim();
            String TeachName = textBox16.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE Course SET Cname = '" + CourName + "',Cpno = '" + Courpno + "', Ccredit = '" + CourCredit + "',Tno = '"+TeachID +"',Tname = '"+TeachName+"'  WHERE Cno = '" + CourID + "'";
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
            this.courseTableAdapter.Fill(this.mainProjectDataSet.Course);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            String CourID = textBox11.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Course where Cno='" + CourID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView3.DataSource = bindingSource;
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

        private void button13_Click(object sender, EventArgs e)
        {
            String StuID = textBox17.Text.Trim();
            String CourID = textBox18.Text.Trim();
            String Grade = textBox19.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  SC (Sno,Cno,Grade)    " +
                    "VALUES ('" + StuID + "','" + CourID + "','" + Grade + "')";
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
            this.sCTableAdapter.Fill(this.mainProjectDataSet.SC);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_Sno = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string select_Cno = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from SC where Sno=" + select_Sno + " and Cno = " + select_Cno;//sql删除语句
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
            this.sCTableAdapter.Fill(this.mainProjectDataSet.SC);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String StuID = textBox17.Text.Trim();
            String CourID = textBox18.Text.Trim();
            String Grade = textBox19.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE SC SET Grade = '" + Grade + "' WHERE Sno = '" + StuID + "'and Cno = '" + CourID + "' ";
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
            this.sCTableAdapter.Fill(this.mainProjectDataSet.SC);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            String StuID = textBox17.Text.Trim();
            String CourID = textBox18.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from SC where Sno='" + StuID + "'and Cno ='" + CourID + "' ";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView4.DataSource = bindingSource;
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

        private void button17_Click(object sender, EventArgs e)
        {
            String StuID = textBox20.Text.Trim();
            String Password = textBox21.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  StudentPasswords (Sno,Passwords)    " +
                    "VALUES ('" + StuID + "','" + Password + "')";
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
            this.studentPasswordsTableAdapter.Fill(this.mainProjectDataSet.StudentPasswords);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_id = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from StudentPasswords where Sno=" + select_id;//sql删除语句
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
            this.studentPasswordsTableAdapter.Fill(this.mainProjectDataSet.StudentPasswords);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            String StuID = textBox20.Text.Trim();
            String Password = textBox21.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE StudentPasswords SET Passwords = '" + Password + "' WHERE Sno = '" + StuID + "'";
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
            this.studentPasswordsTableAdapter.Fill(this.mainProjectDataSet.StudentPasswords);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            String StuID = textBox20.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from StudentPasswords where Sno='" + StuID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView5.DataSource = bindingSource;
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

        private void button21_Click(object sender, EventArgs e)
        {
            String TeachID = textBox22.Text.Trim();
            String Password = textBox23.Text.Trim();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  TeacherPasswords (Tno,Passwords)    " +
                    "VALUES ('" + TeachID + "','" + Password + "')";
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
            this.teacherPasswordsTableAdapter.Fill(this.mainProjectDataSet.TeacherPasswords);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string select_id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from TeacherPasswords where Tno=" + select_id;//sql删除语句
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
            this.teacherPasswordsTableAdapter.Fill(this.mainProjectDataSet.TeacherPasswords);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            String TeachID = textBox22.Text.Trim();
            String Password = textBox23.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE TeacherPasswords SET Passwords = '" + Password + "' WHERE Tno = '" + TeachID + "'";
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
            this.teacherPasswordsTableAdapter.Fill(this.mainProjectDataSet.TeacherPasswords);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            String TeachID = textBox22.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from TeacherPasswords where Tno='" + TeachID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView6.DataSource = bindingSource;
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

        private void button25_Click(object sender, EventArgs e)
        {
            String ManID = textBox24.Text.Trim();
            String ManName = textBox25.Text.Trim();
            String Mansex = textBox26.Text.Trim();
            String ManAge = textBox27.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE Manager SET Mname = '" + ManName + "',Msex = '" + Mansex + "', Mage = '" + ManAge + "'WHERE Mno = '" + ManID + "'";
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
            this.managerTableAdapter.Fill(this.mainProjectDataSet.Manager);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            String ManID = textBox24.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Manager where Mno='" + ManID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView7.DataSource = bindingSource;
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

        private void button27_Click(object sender, EventArgs e)
        {
            String ManID = textBox28.Text.Trim();
            String Password = textBox29.Text.Trim();


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True");
            try
            {
                con.Open();
                string insertStr = "UPDATE ManagerPasswords SET Passwords = '" + Password + "' WHERE Mno = '" + ManID + "'";
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
            this.managerPasswordsTableAdapter.Fill(this.mainProjectDataSet.ManagerPasswords);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            String ManID = textBox28.Text.Trim();
            String conn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from ManagerPasswords where Mno='" + ManID + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView8.DataSource = bindingSource;
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
