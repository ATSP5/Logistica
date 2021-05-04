using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica
{
    public enum Role { THISDeveloper, Administrator, ProjectMenager, Programmist, HardwareDeveloper, TechnicalDeveloper, OfficeWorker, Unknown };
    public class UserState
    {
        private bool UserLogedIn;
        private uint UserDBID;
        private Role CurrentRole;

        private static UserState _instance;

        public static UserState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserState();
            }
            return _instance;
        }

        private UserState()
        {
            UserLogedIn = false;
            UserDBID = uint.MaxValue;
            CurrentRole = Role.Unknown;
        }

        public void UserLogIn(uint _dBId, Role role)
        {
            UserDBID = _dBId;
            CurrentRole = role;
            UserLogedIn = true;
        }

        public void UserLogOut()
        {
            UserLogedIn = false;
            UserDBID = uint.MaxValue;
            CurrentRole = Role.Unknown;
        }

        public bool IsUserLoggedIn()
        {
            return UserLogedIn;
        }
         public uint GetUserDBID()
        {
            return UserDBID;
        }
        public Role GetRole()
        {
            return CurrentRole;
        }
    }
}
