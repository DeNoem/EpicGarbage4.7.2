﻿using System;
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
    public partial class _2_task : Form
    {
        public _2_task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Garbage> temp = FileCore.Search(comboBox2.SelectedIndex);
            dataGridView1.DataSource = temp.Select(g => new { g.DistrictType, g.AmountIndustrial, g.AmountConstruction, g.AmountMunicipal }).ToList();
           
        }
    }
}

