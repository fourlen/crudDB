using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
namespace SGO3
{
    class FacultyState : State
    {
        public DataBase db = new DataBase();
        public FacultyState() { }

        public override void Create()
        {
            FacultyCreateUpdate fcu = new FacultyCreateUpdate(null);
            fcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.facultyRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.facultyRepository.Table();
        }

        public override void Update(List<string> values)
        {
            FacultyCreateUpdate fcu = new FacultyCreateUpdate(values);
            fcu.Show();
        }
    }
}
