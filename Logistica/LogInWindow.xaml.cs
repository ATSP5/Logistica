using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Logistica
{
    /// <summary>
    /// Logika interakcji dla klasy LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        enum LoginMethod{Login, Firstname, Lastname };
        private string MySQLQuerry;
        private string password;
        private string loginstr;
        private APMySQLDBEngine SQLEngine;
        MySqlDataReader dread;
        UserState _userstate;
        public LogInWindow(ref APMySQLDBEngine aPMySQL, ref UserState userState)
        {
            InitializeComponent();
            //MySQLQuerry = "select * from person p where p.login = "Admin" and p.password = "admin"; ";
            MySQLQuerry = "";
            SQLEngine = aPMySQL;
            _userstate = userState;
        }

        private void cBLoginMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void bTLogInWindowLogin_Click(object sender, RoutedEventArgs e)
        {
            switch (cBLoginMethod.SelectedIndex)
            {
                case 1:
                    loginstr = "p.login =";
                    break;
                case 2:
                    loginstr = "p.email = ";
                    break;
                default:
                    loginstr = "p.login =";
                    break;
            }
            loginstr += (char)34 + tBLogin.Text + (char)34; //Znak" (char)34
            password = (char)34 + pBPassword.Password.ToString() + (char)34;
            MySQLQuerry = "select * from person p where " + loginstr + "and p.password = " + password + "; ";
            dread = SQLEngine.Execute(MySQLQuerry);
            dread.Read();
            if(((string)dread["login"]==tBLogin.Text || (string)dread["email"] == tBLogin.Text) && (string)dread["password"] == pBPassword.Password.ToString())
            {
                switch (cBLoginMethod.SelectedIndex)
                {
                    case 1:
                        MessageBox.Show("Logged in as: " + (string)dread["login"]);
                        break;
                    case 2:
                        MessageBox.Show("Logged in as: " + (string)dread["email"]);
                        break;
                    default:
                        MessageBox.Show("Logged in as: " + (string)dread["login"]);
                        break;
                }
               //Role { THISDeveloper, Administrator, ProjectMenager, Programmist, HardwareDeveloper, TechnicalDeveloper, OfficeWorker, Unknown };
                _userstate.UserLogIn(uint.Parse((string)dread["PersonID"].ToString()), (Role)Enum.Parse(typeof(Role), (string)dread["CompanyRole"]));
                SQLEngine.MySQLDisconnect();
                string connectionString= "";
                switch (_userstate.GetRole()) ///////////////////////////////////////////////////////////////////////////////////////TO BE READ FROM CONFIG FILE!!!!
                {
                    case Role.THISDeveloper:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.Administrator:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.ProjectMenager:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.Programmist:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.HardwareDeveloper:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.TechnicalDeveloper:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.OfficeWorker:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                    case Role.Unknown:
                    default:
                        connectionString = "Server=localhost;Uid=LogisticaBasic;Pwd=Prukalaapx25;database=inventory";
                        break;
                }
                SQLEngine.MySQLConnect(connectionString);
            }
            dread.Close();
            this.Close();
        }

        private void bTLogInWindowCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
