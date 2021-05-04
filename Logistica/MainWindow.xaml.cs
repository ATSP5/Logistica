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
    /// Querring MySQL Database info: //SQLQuerry = "select * from person;";
    ///                               //aPMySQLDBEngine.Execute(SQLQuerry, DBTable.PersonsTable);
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory"; //connectionString = "Server=localhost;Uid=root;Pwd=Prukalaapx25;database=inventory";
            aPMySQLDBEngine = APMySQLDBEngine.GetInstance();
            DBConnectedState = false;
            userState = UserState.GetInstance();
        }
        APMySQLDBEngine aPMySQLDBEngine;
        UserState userState;
        string connectionString;
        bool DBConnectedState;
        LogInWindow logInWindow;

        private void mIExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mILogIn_Click(object sender, RoutedEventArgs e)
        {
            logInWindow = new LogInWindow(ref aPMySQLDBEngine, ref userState);
            logInWindow.Show();
        }

        private void mILogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mIRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mIUnregister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(aPMySQLDBEngine != null)
            {
                aPMySQLDBEngine.MySQLDisconnect();
            }
        }

        private void mIConnectionStateButton_Click(object sender, RoutedEventArgs e)
        {
             if(DBConnectedState==false)
            {
               
                if (aPMySQLDBEngine.MySQLConnect(connectionString) == true)
                {
                    mIConnectionStateButtonImage.Source = new BitmapImage(new Uri("VisualResources/stop-button.png", UriKind.Relative));
                    DBConnectedState = true;
                }
            }
             else
            {
                aPMySQLDBEngine.MySQLDisconnect();
                mIConnectionStateButtonImage.Source = new BitmapImage(new Uri("VisualResources/play-button.png", UriKind.Relative));
                MessageBox.Show("Database server disconnected!","Information");
                DBConnectedState = false;
            }
           
        }
    }
}
