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
    public partial class Course_predmetCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public Course_predmetCreateUpdate(List<string> _cellvalues)
        {
            cellvalues = _cellvalues;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            newvalues.Add(textBox1.Text);
            newvalues.Add(textBox2.Text);
            newvalues.Add(textBox3.Text);
            newvalues.Add(textBox4.Text);
            if (cellvalues != null)
            {
                db.course_PredmetRepository.UpdateString(cellvalues, newvalues);
            }   
            else
            {
                db.course_PredmetRepository.AddNewString(newvalues);
            }
            this.Close();
        }

        private void Course_predmetCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox1.Text = cellvalues[0];
                textBox2.Text = cellvalues[1];
                textBox3.Text = cellvalues[2];
                textBox4.Text = cellvalues[3];
            }
        }
    }
}
