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
            List<Garbage> result = new List<Garbage>();

            for (int i = 0; i < 12; i++)
            {
                Garbage temp = new Garbage();
                var tempList = mainList.Where(Garbage => Garbage.Month == i);

                foreach (var item in tempList)
                {
                    temp.AmountIndustrial += item.AmountIndustrial;
                    temp.AmountConstruction += item.AmountConstruction;
                    temp.AmountMunicipal += item.AmountMunicipal;
                }
                result.Add(temp);
            }

            var j = 1;
            foreach (var item in result)
            {
                this.chart1.Series["Industrial"].Points.AddXY(j, item.AmountIndustrial);
                this.chart1.Series["Construction"].Points.AddXY(j, item.AmountConstruction);
                this.chart1.Series["Municipal"].Points.AddXY(j++, item.AmountMunicipal);
            }
        }
    }
}
