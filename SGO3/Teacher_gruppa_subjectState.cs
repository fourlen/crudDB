using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class Teacher_gruppa_subjectState : State
    {
        public DataBase db = new DataBase();
        public Teacher_gruppa_subjectState() { }

        public override void Create()
        {
            Teacher_gruppa_subjectCreateUpdate tgscu = new Teacher_gruppa_subjectCreateUpdate(null);
            tgscu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.teacher_Gruppa_SubjectRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.teacher_Gruppa_SubjectRepository.Table();
        }

        public override void Update(List<string> values)
        {
            Teacher_gruppa_subjectCreateUpdate tgscu = new Teacher_gruppa_subjectCreateUpdate(values);
            tgscu.Show();
        }
    }
}
