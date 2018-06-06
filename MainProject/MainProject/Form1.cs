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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string Username;

        private void button1_Click(object sender, EventArgs e)
        {
            string Role, Password;
            Role = comboBox1.Text;
            Username = textBox1.Text;
            Password = textBox2.Text;
            //textBox2.Text = textBox1.Text;
            string myConn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(myConn);  //实例化连接对象
            sqlConnection.Open();

            if (Role == "Student")
            {
                string sql = "select * from StudentPasswords where Sno = '" + Username + "' and Passwords = '" + Password + "'";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("Login Success ！！");
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Login Failure ！!");
                sqlConnection.Dispose();
            }
            else if(Role == "Teacher")
            {
                string sql = "select * from TeacherPasswords where Tno = '" + Username + "' and Passwords = '" + Password + "'";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("Login Success ！！");
                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Login Failure ！!");
                sqlConnection.Dispose();
            }
            else
            {
                string sql = "select * from ManagerPasswords where Mno = '" + Username + "' and Passwords = '" + Password + "'";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("Login Success ！！");
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Login Failure ！!");
                sqlConnection.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Role, Username, Password;
            Role = comboBox1.Text;
            Username = textBox1.Text;
            Password = textBox2.Text;
            //textBox2.Text = textBox1.Text;
            string myConn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(myConn);  //实例化连接对象
            sqlConnection.Open();
            if (Role == "Student")
            {
                string sql = "select Sno from StudentPasswords where Sno = '" + Username + "' ";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("The Account is already in existence !!");
                    
                }
                else
                {
                    sqlDataReader.Close();
                    try
                    {
                        string sql1 = "INSERT INTO StudentPasswords(Sno,Passwords)" + " VALUES ( '" + Username + "' , '" + Password + "' ) ";                                            //编写SQL命令

                        SqlCommand cmd = new SqlCommand(sql1, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("输入数据违反要求!");
                    }
                    finally
                    {
                        MessageBox.Show("Login in Success !!");
                        sqlConnection.Dispose();
                    }
                }
            }
            else if(Role == "Teacher")
            {
                string sql = "select Tno from TeacherPasswords where Tno = '" + Username + "' ";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("The Account is already in existence !!");
                }
                else
                {
                    sqlDataReader.Close();
                    try
                    {
                        string sql1 = "INSERT INTO TeacherPasswords (Tno,Passwords)" + " VALUES ( '" + Username + "' , '" + Password + "' ) ";                                            //编写SQL命令

                        SqlCommand cmd = new SqlCommand(sql1, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("输入违反要求!");
                    }
                    finally
                    {
                        MessageBox.Show("Login in Success !!");
                        sqlConnection.Dispose();
                    }
                }
            }
            else
            {
                string sql = "select Mno from ManagerPasswords where Mno = '" + Username + "' ";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    MessageBox.Show("The Account is already in existence !!");
                    sqlDataReader.Close();
                }
                else
                {
                    sqlDataReader.Close();
                    try
                    {
                        string sql1 = "INSERT INTO ManagerPasswords (Mno,Passwords)" + " VALUES ( '" + Username + "' , '" + Password + "' ) ";                                            //编写SQL命令

                        SqlCommand cmd = new SqlCommand(sql1, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("输入违反要求!");
                    }
                    finally
                    {
                        MessageBox.Show("Login in Success !!");
                        sqlConnection.Dispose();
                    }
                }
            }
        }
    }
}
