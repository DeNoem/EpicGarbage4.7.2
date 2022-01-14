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
    public partial class _4_task : Form
    {
        public _4_task()
        {
            InitializeComponent();

            var mainList = FileCore.Read();

            List<Garbage> result = FileCore.MonthAddition(mainList);

            foreach (var item in result)
            {
                this.chart1.Series["Industrial"].Points.AddXY(item.Month, item.AmountIndustrial);
                this.chart1.Series["Construction"].Points.AddXY(item.Month, item.AmountConstruction);
                this.chart1.Series["Municipal"].Points.AddXY(item.Month, item.AmountMunicipal);
            }
        }
    }
}
