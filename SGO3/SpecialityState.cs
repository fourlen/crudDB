using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class SpecialityState : State
    {
        DataBase db = new DataBase();
        public SpecialityState() { }
        public override void Create()
        {
            SpecialityCreateUpdate scu = new SpecialityCreateUpdate(null);
            scu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.specialityRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.specialityRepository.Table();
        }

        public override void Update(List<string> values)
        {
            SpecialityCreateUpdate scu = new SpecialityCreateUpdate(values);
            scu.Show();
        }
    }
}
