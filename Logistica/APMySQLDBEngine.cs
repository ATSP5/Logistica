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
    public class APMySQLDBEngine : APDBEngineAC
    {
        private MySqlConnection mySqlConnection;
        MySqlCommand cmd;

        private static APMySQLDBEngine _instance; // Instancja klasy

        public static APMySQLDBEngine GetInstance() // Metoda zwracająca instancję singletonu!!!
        {
            if(_instance == null)
            {
                _instance = new APMySQLDBEngine();
            }
            return _instance;
        }

        private APMySQLDBEngine() //Default constructor
        {
            cmd = new MySqlCommand();
        }
        public bool MySQLConnect(string _connectionStr)
        {
           return Connect(_connectionStr);
        }
        public void MySQLDisconnect()
        {
            Disconnect();
        }
        public MySqlDataReader Execute(string Querry)
        {
            return DBQExecute(Querry);
        }
        protected override void Disconnect()
        {
            if(mySqlConnection!= null)
            {
                mySqlConnection.Close();
            }
            
        }
        protected override bool Connect(string ConnectionStr)
        {
             mySqlConnection = new MySqlConnection(ConnectionStr);
          
            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + " Check ''help'' panel for more details!","Error!");
                return false;
            }
        }
        protected override MySqlDataReader DBQExecute(string querry)
        {
            cmd.CommandText = querry;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = mySqlConnection;

            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Contact your developer!");
                return null;
            }
        }
    }
}
