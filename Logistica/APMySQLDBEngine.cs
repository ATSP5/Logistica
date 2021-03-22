using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Logistica
{
    class APMySQLDBEngine : APDBEngineAC
    {
        private string connectionString;
        private MySqlConnection mySqlConnection;
        public APMySQLPersonTable apMySQLPersonTable;

        public APMySQLDBEngine(string ConnectionStr) //Default constructor
        {
            connectionString = ConnectionStr;
            apMySQLPersonTable = new APMySQLPersonTable();
        }
        public void MySQLConnect()
        {
            Connect();
        }
        public void MySQLDisconnect()
        {
            Disconnect();
        }
        protected override void Disconnect()
        {
            mySqlConnection.Close();
        }
        protected override void Connect()
        {
             mySqlConnection = new MySqlConnection(connectionString);
            apMySQLPersonTable.PassConnectionParamether(mySqlConnection);
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
