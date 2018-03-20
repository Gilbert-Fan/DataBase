using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._15_练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "这是一个测试";
            this.BackColor = Color.FromArgb(204, 232, 207);
           // this.label1.SetBounds(300, 300, 400, 300);
           // this.label1.Left += 500;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text =e.X + "," + e.Y;
        }
    }
}
