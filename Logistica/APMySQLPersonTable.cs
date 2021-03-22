using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Logistica
{
    class APMySQLPersonTable : APDBEngineAC
    {
        string PersonID;
        string FirstName;
        string LastName;
        string PhoneNumber;
        string Login;
        string Password;
        string Email;
        string Register;
        string LastLogin;
        string Ip;

        private MySqlConnection sqlConnection;
        private DataTable dataTable;
        private MySqlDataAdapter mySQLDataAdapter;

        //Getery i setery:
        public string _personID
        {
            get { return PersonID; }   // get method
            set { PersonID = value; }  // set method
        }
        public string _firstName
        {
            get { return FirstName; }   // get method
            set { FirstName = value; }  // set method
        }
        public string _lastName
        {
            get { return LastName; }   // get method
            set { LastName = value; }  // set method
        }
        public string _phoneNumber
        {
            get { return PhoneNumber; }   // get method
            set { PhoneNumber = value; }  // set method
        }
        public string _login
        {
            get { return Login; }   // get method
            set { Login = value; }  // set method
        }
        public string _password
        {
            get { return Password; }   // get method
            set { Password = value; }  // set method
        }
        public string _email
        {
            get { return Email; }   // get method
            set { Email = value; }  // set method
        }
        public string _register
        {
            get { return Register; }   // get method
            set { Register = value; }  // set method
        }
        public string _lastLogin
        {
            get { return LastLogin; }   // get method
            set { LastLogin = value; }  // set method
        }
        public string _ip
        {
            get { return Ip; }   // get method
            set { Ip = value; }  // set method
        }

        public APMySQLPersonTable()
        {
            dataTable = new DataTable();
            mySQLDataAdapter = new MySqlDataAdapter();
            
        }
         public void PassConnectionParamether(MySqlConnection mySqlConnection)
        {
            if(mySqlConnection!= null)
            {
                try
                {
                    sqlConnection = mySqlConnection;
                }
                catch
                {
                    System.Windows.MessageBox.Show("Internal error of passing the connection paramether!");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Connection paramether is empty!");
            }
            
        }

        public void Delete(string _querry)
        {
            DBDelete(_querry);
        }
        public void Insert(string _querry)
        {
            DBInsert(_querry);
        }
        public void Select(string _querry)
        {
            DBSelect(_querry);
        }
        public void Update(string _querry)
        {
            DBUpdate(_querry);
        }
        protected override void DBDelete(string Querry)
        {
            mySQLDataAdapter.SelectCommand = new MySqlCommand(Querry, sqlConnection);
        }

        protected override void DBInsert(string Querry)
        {
            mySQLDataAdapter.SelectCommand = new MySqlCommand(Querry, sqlConnection);
        }

        protected override void DBSelect(string Querry)
        {
            mySQLDataAdapter.SelectCommand = new MySqlCommand(Querry, sqlConnection);
            mySQLDataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                PersonID = row["PersonID"].ToString();
                FirstName = row["FirstName"].ToString();
                LastName = row["LastName"].ToString();
                PhoneNumber = row["PhoneNumber"].ToString();
                Login = row["login"].ToString();
                Password = row["password"].ToString();
                Email = row["email"].ToString();
                Register = row["register"].ToString();
                LastLogin = row["LastLogin"].ToString();
                Ip = row["ip"].ToString();
            }
        }

        protected override void DBUpdate(string Querry)
        {
            mySQLDataAdapter.SelectCommand = new MySqlCommand(Querry, sqlConnection);
        }
    }
}
