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
    public partial class Subject_resault_typeCreateUpdate : Form
    {
        List<string> cellvalues;
        List<string> newvalues = new List<string>();
        public Subject_resault_typeCreateUpdate(List<string> _cellvalues)
        {
            cellvalues = _cellvalues;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Subject_resault_typeCreateUpdate_Load(object sender, EventArgs e)
        {
            if (cellvalues != null)
            {
                textBox1.Text = cellvalues[1];
                if (cellvalues[2] == "True")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (cellvalues[2] == "False")
                {
                    comboBox1.SelectedIndex = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            newvalues.Add("-1");
            newvalues.Add(textBox1.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                newvalues.Add("True");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                newvalues.Add("False");
            }
            if (cellvalues != null)
            {
                db.subject_Resault_typeRepository.UpdateString(cellvalues, newvalues);
            }
            else
            {
                db.subject_Resault_typeRepository.AddNewString(newvalues);
            }
            this.Close();
        }
    }
}