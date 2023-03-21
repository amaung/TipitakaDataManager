using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
#nullable enable
    public class ClientTipitakaDBLogin : ClientUserProfile
    {
        public UserProfile? loggedinUser = null;
        string lastLogin = string.Empty;
        //*******************************************************************
        //*** TipitakaDBLogin constructor
        //*******************************************************************
        public ClientTipitakaDBLogin()
        {
        }
        //*******************************************************************
        //*** Login
        //*******************************************************************
#nullable enable
        public UserProfile? Login(string userID, string userPswd, string userType = "U")
        {
            loggedinUser = null;
            RetrieveTableRec(userID).Wait();
            if (StatusCode == 200)
            {
                if (objResult == null) return null;
                loggedinUser = new UserProfile((UserProfile)objResult);
                if (userType == "A")
                {
                    // the user must have admin status
                    if (loggedinUser.UserClass != "D" && loggedinUser.UserClass != "A") return loggedinUser;
                }

                loggedinUser.PartitionKey = _UserProfile_;
                loggedinUser.RowKey = userID;
                if (userPswd == Encrypt(loggedinUser.Password, loggedinUser.PID, false))
                {
                    int n = DateTime.Compare(loggedinUser.LastLogin.LocalDateTime, loggedinUser.JoinedDate.LocalDateTime);
                    if (n > 0)
                        lastLogin = loggedinUser.LastLogin.ToLocalTime().ToString() + loggedinUser.LastLogin.ToLocalTime().ToString();
                    DateTimeOffset dto = loggedinUser.LastLogin;
                    loggedinUser.LastLogin = DateTime.Now.ToUniversalTime();
                    loggedinUser.Password = userPswd;
                    UpdateUserProfile(loggedinUser);
                    loggedinUser.LastLogin = dto;
                    return loggedinUser;
                }
                loggedinUser.Status = "IncorrectPassword";
            }
            return loggedinUser;
        }
        public string RecoverPassword(string userID)
        {
            string pswd = string.Empty;
            RetrieveTableRec(userID).Wait();
            if (StatusCode == 200)
            {
                if (objResult == null) return null;
                loggedinUser = new UserProfile((UserProfile)objResult);

                loggedinUser.PartitionKey = _UserProfile_;
                loggedinUser.RowKey = userID;
                pswd = Encrypt(loggedinUser.Password, loggedinUser.PID, false);
            }
            return pswd;
        }
#nullable disable
        //*******************************************************************
        //*** Logout
        //*******************************************************************
        public void Logout()
        {
            loggedinUser = null; /* remove login user info */
            lastLogin = String.Empty;
        }
        //*******************************************************************
        //*** GetLastLogin
        //*******************************************************************
        public string GetLastLogin() { return lastLogin; }
        //*******************************************************************
        //*** UpdateUserProfile
        //*******************************************************************
        public void UpdateUserProfile(string usrName_E, string usrName_M, string usrPswd)
        {
            if (loggedinUser != null)
            {
                loggedinUser.Name_E = usrName_E;
                loggedinUser.Name_M = usrName_M;
                loggedinUser.Password = usrPswd;
                UpdateUserProfile(loggedinUser);
            }
        }
    }
#nullable disable
}
