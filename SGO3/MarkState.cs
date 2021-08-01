using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO3
{
    class MarkState : State
    {
        public DataBase db = new DataBase();
        public MarkState() { }
        public override void Create()
        {
            MarkCreateUpdate mcu = new MarkCreateUpdate(null);
            mcu.Show();
        }

        public override void Delete(List<string> values)
        {
            db.markRepository.DeleteString(values);
        }

        public override DataTable Read()
        {
            return db.markRepository.Table();
        }

        public override void Update(List<string> values)
        {
            MarkCreateUpdate mcu = new MarkCreateUpdate(values);
            mcu.Show();
        }
    }
}
