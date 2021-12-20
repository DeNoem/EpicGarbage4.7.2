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
            List<Garbage> temp = FileCore.Search(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    
                    break;

                case 1:
                    
                    break;

                case 2:
                    
                    break;
            }
            temp.Sort();

            listBox1.DataSource = temp;
        }
    }
}
