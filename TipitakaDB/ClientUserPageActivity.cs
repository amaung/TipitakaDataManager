using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
    public class ClientUserPageActivity : TipitakaDB
    {
        const string _UserPageActivity_ = "UserPageActivity";
        public ClientUserPageActivity() : base(_UserPageActivity_)
        { }
        public void AddUserPageActivity(UserPageActivity userPageActivity)
        {
            InsertTableRec(userPageActivity).Wait();
        }
        public List<UserPageActivity> QueryUserPageActivity(string filter = "")
        {
            List<UserPageActivity> listUserPageActivity = new List<UserPageActivity>();
            if (filter.Length > 0)
            {
                QueryTableRec(filter).Wait();
                listUserPageActivity = (List<UserPageActivity>) objResult;
            }
            else StatusCode = -1;
            return listUserPageActivity;
        }
        public UserPageActivity? GetUserPageActivity(string rowKey)
        {
            if (rowKey != null && rowKey.Length > 0)
            {
                RetrieveTableRec(rowKey).Wait();
                UserPageActivity userPageActivity = (UserPageActivity)objResult;
                return (StatusCode == 200) ? userPageActivity : null;
            }
            else StatusCode = -1;
            return null;
        }
        public void RemoveUserPageActivity(string rowKey)
        {
            RetrieveTableRec(rowKey).Wait();
            if (StatusCode == 200 || StatusCode == 204)
            {
                // record found
                DeleteTableRec(objResult).Wait();
            }
        }
        public void RemoveUserPageActivity(UserPageActivity userPageActivity)
        {
            DeleteTableRec(userPageActivity).Wait();
        }
        public void UpdateUserPageActivity(UserPageActivity userPageActivity)
        {
            UserPageActivity? userPageActivity0 = GetUserPageActivity(userPageActivity.RowKey);
            if (userPageActivity0!= null)
            {
                userPageActivity0.Status = userPageActivity.Status;
                userPageActivity0.StartDate = userPageActivity.StartDate;
                userPageActivity0.TimeSpent = userPageActivity.TimeSpent;
                userPageActivity0.TurnAroundTime = userPageActivity.TurnAroundTime;
                userPageActivity0.NIS = userPageActivity.NIS;
                UpdateTableRec(userPageActivity0).Wait();
            }
        }
    }
}
