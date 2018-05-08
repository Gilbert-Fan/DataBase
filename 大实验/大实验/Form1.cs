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

namespace 大实验
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username, Password;
            Username = textBox1.Text;
            Password = textBox2.Text;
            String Mycon = "Data Source=.;Initial Catalog=Students;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(Mycon);
            sqlConnection.Open();

            string sql = "select userid,password from usertable where userid = '" + Username + "' and password = '" + Password + "'";                                            //编写SQL命令

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);



            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();



            if (sqlDataReader.HasRows)

            {

                MessageBox.Show("欢迎使用！");             //登录成功

                Form2 form2 = new Form2();

                form2.Show();

                this.Hide();

            }

            else

            {

                MessageBox.Show("登录失败！");

            }

            sqlConnection.Close();

        }

    }
}

