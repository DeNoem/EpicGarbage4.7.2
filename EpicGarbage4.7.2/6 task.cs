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
    public partial class _6_task : Form
    {
        public _6_task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Industrial garbage"].Points.Clear();
            chart1.Series["Construction garbage"].Points.Clear();
            chart1.Series["Municipal garbage"].Points.Clear();

            List<Garbage> temp = FileCore.Search(comboBox2.SelectedIndex);

            var j = 1;
            foreach (var item in temp)
            {
                this.chart1.Series["Industrial garbage"].Points.AddXY(j, item.AmountIndustrial);
                this.chart1.Series["Construction garbage"].Points.AddXY(j, item.AmountConstruction);
                this.chart1.Series["Municipal garbage"].Points.AddXY(j++, item.AmountMunicipal);
            }
        }
    }
}
