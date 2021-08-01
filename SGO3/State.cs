using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SGO3
{
    public abstract class State
    {
        protected MainMenu main;
        public State() { }
        abstract public void Create();
        abstract public DataTable Read();
        abstract public void Update(List<string> values);
        abstract public void Delete(List<string> values);
    }
}
