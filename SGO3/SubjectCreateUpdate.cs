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
    public partial class SubjectCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public SubjectCreateUpdate(List<string> _cellvalues)
        {
            cellvalues = _cellvalues;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubjectCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox1.Text = cellvalues[1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            newvalues.Add("-1");
            newvalues.Add(textBox1.Text);
            if (cellvalues != null)
            {
                db.subjectRepository.UpdateString(cellvalues, newvalues);
            }
            else
            {
                db.subjectRepository.AddNewString(newvalues[1]);
            }
            this.Close();
        }
    }
}
