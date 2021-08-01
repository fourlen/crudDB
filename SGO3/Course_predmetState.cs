using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class Course_predmetState : State
    {
        public DataBase db = new DataBase();
        public Course_predmetState() { }
        public override void Create()
        {
            Course_predmetCreateUpdate cpcu = new Course_predmetCreateUpdate(null);
            cpcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.course_PredmetRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.course_PredmetRepository.Table();
        }

        public override void Update(List<string> values)
        {
            Course_predmetCreateUpdate cpcu = new Course_predmetCreateUpdate(values);
            cpcu.Show();
        }
    }
}
