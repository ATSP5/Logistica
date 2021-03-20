using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Logistica
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mIConnect_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=localhost;Uid=root;Pwd=Prukalaapx25;database=inventory";
            string ZapytanieSQL = "select * from person;";
            MySqlConnection Polaczenie = new MySqlConnection(connectionString);
            DataTable dane = new DataTable();
            try 
            {
                Polaczenie.Open();
                MessageBox.Show("Sukces! Zalogowano się do bazy.");
                MySqlDataAdapter AdapterSQL = new MySqlDataAdapter();
                AdapterSQL.SelectCommand = new MySqlCommand(ZapytanieSQL, Polaczenie);
                AdapterSQL.Fill(dane);
                PokazTuDane.ItemsSource = dane.DefaultView;
                string PersonID;
                string FirstName;
                string LastName;
                string PhoneNumber;
                string login;
                string password;
                string email;
                string register;
                string LastLogin;
                string ip;
                foreach (DataRow row in dane.Rows)
                {
                    PersonID = row["PersonID"].ToString();
                    FirstName = row["FirstName"].ToString();
                    LastName = row["LastName"].ToString();
                    PhoneNumber = row["PhoneNumber"].ToString();
                    login = row["login"].ToString();
                    password = row["password"].ToString();
                    email = row["email"].ToString();
                    register = row["register"].ToString();
                    LastLogin = row["LastLogin"].ToString();
                    ip = row["ip"].ToString();
                }
                Polaczenie.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }
        }

        private void mIExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
