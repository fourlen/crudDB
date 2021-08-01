using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGO3
{
    public partial class GruppaCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public GruppaCreateUpdate(List<string> _cellvalues)
        {
            cellvalues = _cellvalues;
            InitializeComponent();
        }
        private void GruppaCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox1.Text = cellvalues[0];
                textBox2.Text = cellvalues[1];
                textBox3.Text = cellvalues[2];
                textBox4.Text = cellvalues[3];
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            newvalues.Add(textBox1.Text);
            newvalues.Add(textBox2.Text);
            newvalues.Add(textBox3.Text);
            newvalues.Add(textBox4.Text);
            if (cellvalues != null)
            {
                db.gruppaRepository.UpdateString(cellvalues, newvalues);
            }
            else
            {
                db.gruppaRepository.AddNewString(newvalues);
            }
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
