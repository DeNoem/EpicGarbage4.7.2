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
    public partial class _5_task : Form
    {
        public _5_task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            var tempList = FileCore.Search(comboBox2.SelectedIndex); 
            Garbage result = new Garbage();

            result = FileCore.MonthAddition(tempList)[0];

            chart1.Series["Series1"].Points.AddXY("Industrial", result.AmountIndustrial);
            chart1.Series["Series1"].Points.AddXY("Construction", result.AmountConstruction);
            chart1.Series["Series1"].Points.AddXY("Municipal", result.AmountMunicipal);
        }

    }

    
}
