using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Logistica
{
    public abstract class APDBEngineAC
    {

        protected virtual bool Connect(string ConnectionStr) { throw new NotImplementedException();  }
        protected virtual void Disconnect() { throw new NotImplementedException(); }
        protected virtual MySqlDataReader DBQExecute(string querry) { throw new NotImplementedException(); }
    }
}
