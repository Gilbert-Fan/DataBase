using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_3._14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你好");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "这是一个程序";
            this.label1.SetBounds(100, 100, 300, 60);
            this.BackColor = Color.FromArgb(255,255,0);
            //this.label1.Left += 200;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text=e.X+"，"+e.X;
        }
    }
}
