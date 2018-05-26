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
            //textBox2.Text = textBox1.Text;
            string myConn = "Data Source=LAPTOP-R10FHC7M;Initial Catalog=MainProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(myConn);  //实例化连接对象
            sqlConnection.Open();

            string sql = "select * from Passwords where Sno = '" + Username + "' and Passwords = '" + Password + "'";                                            //编写SQL命令
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                MessageBox.Show("登陆成功！");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("失败！");


        }
    }
    
}
