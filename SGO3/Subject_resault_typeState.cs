using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class Subject_resault_typeState : State
    {
        public DataBase db = new DataBase();
        public Subject_resault_typeState() { }

        public override void Create()
        {
            Subject_resault_typeCreateUpdate srtcu = new Subject_resault_typeCreateUpdate(null);
            srtcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.subject_Resault_typeRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.subject_Resault_typeRepository.Table();
        }

        public override void Update(List<string> values)
        {
            Subject_resault_typeCreateUpdate srtcu = new Subject_resault_typeCreateUpdate(values);
            srtcu.Show();
        }
    }
}
