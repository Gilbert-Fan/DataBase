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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a,b;
            a = textBox1.Text;
            b = textBox2.Text;
            if (a == "lijinying" && b == "01250702")
            {
                MessageBox.Show("Successful！！");
                Form2 form = new Form2();
                form.Show();
            }
            else
                MessageBox.Show("user name or password is wrong！！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
