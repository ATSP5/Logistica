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
            string SQLQuerry = "select * from person;";
            APMySQLDBEngine aPMySQLDBEngine = new APMySQLDBEngine(connectionString);
            aPMySQLDBEngine.MySQLConnect();
            aPMySQLDBEngine.apMySQLPersonTable.Select(SQLQuerry);
            MessageBox.Show(aPMySQLDBEngine.apMySQLPersonTable._firstName);
            aPMySQLDBEngine.MySQLDisconnect();
        }

        private void mIExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
