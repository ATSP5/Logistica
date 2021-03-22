using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logistica
{
    public abstract class APDBEngineAC
    {

        protected virtual void Connect() { throw new NotImplementedException();  }
        protected virtual void Disconnect() { throw new NotImplementedException(); }
        protected virtual void DBInsert(string Querry) { throw new NotImplementedException(); }
        protected virtual void DBDelete(string Querry) { throw new NotImplementedException(); }
        protected virtual void DBSelect(string Querry) { throw new NotImplementedException(); }
        protected virtual void DBUpdate(string Querry) { throw new NotImplementedException(); }
    }
}
