using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class StudentState : State
    {
        public DataBase db = new DataBase();
        public StudentState() { }

        public override void Create()
        {
            StudentCreateUpdate scu = new StudentCreateUpdate(null);
            scu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.studentRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.studentRepository.Table();
        }

        public override void Update(List<string> values)
        {
            StudentCreateUpdate scu = new StudentCreateUpdate(values);
            scu.Show();
        }
    }
}
