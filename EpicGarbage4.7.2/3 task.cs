using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace EpicGarbage4._7._2
{
    public partial class _3_task : Form
    {
        public _3_task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = FileCore.TypeSelect(comboBox3.Text, FileCore.Search(comboBox1.SelectedIndex, comboBox2.SelectedIndex));

            temp.Sort();

            listBox1.DataSource = temp;
        }
    }
}
