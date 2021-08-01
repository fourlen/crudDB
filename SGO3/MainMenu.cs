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
    public partial class MainMenu : Form
    {
        public State state;
        public List<string> values = new List<string>();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void FillValuesFromSelectedRow()
        {
            int rowindex = dataGridView1.SelectedRows[0].Index;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                values.Add(dataGridView1[i, rowindex].Value.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                state = new FacultyState();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                state = new Course_predmetState();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                state = new GruppaState();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                state = new KafedraState();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                state = new MarkState();
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                state = new SpecialityState();
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                state = new StudentState();
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                state = new SubjectState();
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                state = new Subject_resault_typeState();
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                state = new TeacherState();
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                state = new Teacher_gruppa_subjectState();
            }
            dataGridView1.DataSource = state.Read();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                state.Create();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            FillValuesFromSelectedRow();
            state.Update(values);
            values = new List<string>();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            FillValuesFromSelectedRow();
            state.Delete(values);
            values = new List<string>();
        }
    }
}
