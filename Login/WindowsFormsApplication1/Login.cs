using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username,password;
            username = textBox1.Text;
            password = textBox2.Text;
            string myConn = "Data Source=.;Initial Catalog=Students;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(myConn);  //实例化连接对象
            sqlConnection.Open();

            string sql = "select Name,Password from Students where Name = '" + username + "' and Password = '" + password + "'";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                MessageBox.Show("Successful");
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Failed");
            }

        }
    }
}
