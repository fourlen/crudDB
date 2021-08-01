using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class TeacherState : State
    {
        public DataBase db = new DataBase();
        public TeacherState() { }

        public override void Create()
        {
            TeacherCreateUpdate tcu = new TeacherCreateUpdate(null);
            tcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.teacherRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.teacherRepository.Table();
        }

        public override void Update(List<string> values)
        {
            TeacherCreateUpdate tcu = new TeacherCreateUpdate(values);
            tcu.Show();
        }
    }
}