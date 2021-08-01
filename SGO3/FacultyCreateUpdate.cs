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
    public partial class FacultyCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public FacultyCreateUpdate(List<string> _cellvalues)
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
            if (cellvalues != null)
            {
                newvalues.Add(cellvalues[0]);
                newvalues.Add(textBox2.Text);
                db.facultyRepository.UpdateString(cellvalues, newvalues);
            }
            else
            {
                newvalues.Add("-1");
                newvalues.Add(textBox2.Text);
                db.facultyRepository.AddNewString(newvalues[1]);
            }
            this.Close();
        }
        private void FacultyCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox2.Text = cellvalues[1];
            }
        }
    }
}
