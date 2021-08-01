using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class SubjectState : State
    {
        public DataBase db = new DataBase();
        public SubjectState() { }

        public override void Create()
        {
            SubjectCreateUpdate scu = new SubjectCreateUpdate(null);
            scu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.subjectRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.subjectRepository.Table();
        }

        public override void Update(List<string> values)
        {
            SubjectCreateUpdate scu = new SubjectCreateUpdate(values);
            scu.Show();
        }
    }
}
