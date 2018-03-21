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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“studentsDataSet.Students”中。您可以根据需要移动或删除它。
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);

        }
    }
}
