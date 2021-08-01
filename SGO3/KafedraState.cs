using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class KafedraState : State
    {
        public DataBase db = new DataBase();
        public KafedraState() { }
        public override void Create()
        {
            KafedraCreateUpdate kcu = new KafedraCreateUpdate(null);
            kcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.kafedraRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.kafedraRepository.Table();
        }

        public override void Update(List<string> values)
        {
            KafedraCreateUpdate kcu = new KafedraCreateUpdate(values);
            kcu.Show();
        }
    }
}
