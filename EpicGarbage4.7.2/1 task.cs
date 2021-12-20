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
    public partial class _1_task : Form
    {
        public _1_task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Garbage temp = FileCore.Search(comboBox1.Text, comboBox2.SelectedIndex);
            MessageBox.Show("В " + (temp.Month + 1) + " месяце " + "Район: " + temp.DistrictType + ", индустриального мусора: " + temp.AmountIndustrial +
                ", строительного мусора:" + temp.AmountConstruction + ", коммунального мусора:" + temp.AmountMunicipal);
        }

        private void _1_task_Load(object sender, EventArgs e)
        {

        }
    }
}