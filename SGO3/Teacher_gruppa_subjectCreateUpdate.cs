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
    public partial class Teacher_gruppa_subjectCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public Teacher_gruppa_subjectCreateUpdate(List<string> _cellvalues)
        {
            cellvalues = _cellvalues;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Teacher_gruppa_subjectCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox1.Text = cellvalues[0];
                textBox2.Text = cellvalues[1];
                textBox3.Text = cellvalues[2];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            newvalues.Add(textBox1.Text);
            newvalues.Add(textBox2.Text);
            newvalues.Add(textBox3.Text);
            if (cellvalues != null)
            {
                db.teacher_Gruppa_SubjectRepository.UpdateString(cellvalues, newvalues);
            }
            else
            {
                db.teacher_Gruppa_SubjectRepository.AddNewString(newvalues);
            }
            this.Close();
        }
    }
}
