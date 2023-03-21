using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
    public class ClientActivityLog : TipitakaDB
    {
        const string _ActivityLog_ = "ActivityLog";
        //*******************************************************************
        //*** ClientActivityLog
        //*******************************************************************
        public ClientActivityLog() : base(_ActivityLog_) { }
        //*******************************************************************
        //*** Add Activity Log
        //*******************************************************************
        public void AddActivityLog(string userID, string activity)
        {
            DateTime dt = DateTime.UtcNow;
            //string rowKey = dt.Year.ToString() + dt.Month.ToString("D2") + dt.Day.ToString("D2");
            //rowKey += "-" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
            //rowKey += "." + dt.Millisecond.ToString();
            string rowKey = GetFormattedDateTimeString(dt);

            ActivityLog activityLog = new ActivityLog()
            {
                PartitionKey = "ActivityLog",
                RowKey = rowKey,
                UserID = userID,
                Activity = activity,
            };
            InsertTableRec(activityLog).Wait();
        }
        //*******************************************************************
        //*** GetActivities
        //*******************************************************************
        public List<string> GetActivities(string userID = "", DateTime? date1 = null, DateTime? date2 = null)
        {
            List<string> activities = new List<string>();
            string query = string.Empty;
            if (userID.Length > 0)
            {
                query += String.Format(" and (UserID eq '{0}')", userID);
            }
            if (date1 != null && date2 != null) 
            { 
                string s = MakeDateTimeQualifier(date1.Value, date2.Value);
                string[] f = s.Split('|');
                if (f.Length >= 2)
                {
                    query += String.Format(" and (RowKey ge '{0}') and (RowKey lt '{1}')", f[0], f[1]);
                }
            }
            QueryTableRec(query).Wait();
            activities = (List<string>)objResult;
            return activities;
        }
    }
    public class ClientMessageLog : TipitakaDB
    {
        const string _MessageLog_ = "MessageLog";
        //*******************************************************************
        //*** ClientMessageLog
        //*******************************************************************
        public ClientMessageLog() : base(_MessageLog_) { }
        public void AddMessageLog(string from, string to, string subject, string body, string type, bool read = false)
        {
            DateTime dt = DateTime.UtcNow;
            //string rowKey = dt.Year.ToString() + dt.Month.ToString("D2") + dt.Day.ToString("D2");
            //rowKey += "-" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
            //rowKey += "." + dt.Millisecond.ToString();
            string rowKey = GetFormattedDateTimeString(dt);

            MessageLog messageLog = new MessageLog()
            {
                PartitionKey = "MessageLog",
                RowKey = rowKey,
                From = from,
                To = to,
                Subject = subject,
                Body = body,
                MsgType = type,
                Read = read,
            };
            InsertTableRec(messageLog).Wait();
        }
        //*******************************************************************
        //*** GetMessages
        //*******************************************************************
        public List<MessageLog> GetMessages(string userID, bool newMsg = false, DateTime? date1 = null, DateTime? date2 = null)
        {
            List<MessageLog> messages = new List<MessageLog>();
            string filter = string.Empty;
            if (userID.Length > 0)
            {
                filter = String.Format(" and (From eq '{0}' or To eq '{0}')", userID);
            }
            if (newMsg)
            {
                filter += " and Read eq false";
            }
            if (date1 != null && date2 != null)
            {
                string s = MakeDateTimeQualifier(date1.Value, date2.Value);
                string[] f = s.Split('|');
                if (f.Length >= 2)
                {
                    filter += String.Format(" and (RowKey ge '{0}') and (RowKey lt '{1}')", f[0], f[1]);
                }
            }
            QueryTableRec(filter).Wait();
            messages = (List<MessageLog>)objResult;
            return messages;
        }
        //*******************************************************************
        //*** UpdateMessage
        //*******************************************************************
        public void UpdateMessage(MessageLog msg)
        {
            UpdateTableRec(msg).Wait();
            return;
        }
        //*******************************************************************
        //*** GetMessageCount
        //*******************************************************************
        public int GetMessageCount()
        {
            QueryTableRec().Wait();

            return ((List<MessageLog>)objResult).Count;
        }
        //*******************************************************************
        //*** Parse Message
        //*******************************************************************
        public string[] Parse(MessageLog msg)
        {
            List<string> list = new List<string>();
            list.Add("Date : " + GetLocalDateTime(msg.RowKey));
            list.Add("Subject : " + msg.Subject);
            string[] f = msg.Body.Split('|');
            foreach (string s in f)
            {
                list.Add(s.Replace(":", " : "));
            }
            list.Add("Type : " + msg.MsgType);
            return list.ToArray();
        }
    }
}
