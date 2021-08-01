using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class GruppaState : State
    {
        public DataBase db = new DataBase();
        public GruppaState() { }
        public override void Create()
        {
            GruppaCreateUpdate gcu = new GruppaCreateUpdate(null);
            gcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.gruppaRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.gruppaRepository.Table();
        }

        public override void Update(List<string> values)
        {
            GruppaCreateUpdate gcu = new GruppaCreateUpdate(values);
            gcu.Show();
        }
    }
}
