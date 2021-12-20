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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FileCore.DeleteFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FileCore.Add(FileCore.Serializer<Garbage>(FileCore.RandomList()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _1_task newForm = new _1_task();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _2_task newForm = new _2_task();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _3_task newForm = new _3_task();
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _4_task newForm = new _4_task();
            newForm.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            _5_task newForm = new _5_task();
            newForm.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _6_task newForm = new _6_task();
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EditData newForm = new EditData();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

