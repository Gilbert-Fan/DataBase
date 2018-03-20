using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (username == "abc" && password == "123")
            {
                MessageBox.Show("Successful");
                
            }
            else
            {
                MessageBox.Show("Failed");
            }

        }
    }
}
