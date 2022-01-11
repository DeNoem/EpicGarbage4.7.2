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
    public partial class EditData : Form
    {
        public EditData()
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
            List<Garbage> temp = FileCore.Read();
            dataGridView1.DataSource = temp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Garbage> result = new List<Garbage>();

            var temp = (List<Garbage>)dataGridView1.DataSource;

            FileCore.Add(FileCore.Serializer<Garbage>(temp));

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
