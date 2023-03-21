using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tipitaka_DBTables;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Diagnostics;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Tipitaka_DB
{
    public partial class TipitakaDB
    {
        public struct NissayaRecord
        {
            public int recNo;
            public string pali;
            public string trans;
            public string footnote;
            public NissayaRecord() { recNo = 0; pali = trans = footnote = String.Empty; }
            public string IsEqual(NissayaRecord nis)
            {
                string s1, s2;
                s1 = s2 = string.Empty;
                if (recNo != nis.recNo) { s1 = "# " + recNo.ToString(); s2 = "# " + nis.recNo.ToString(); }
                if (pali != nis.pali) { s1 += " *" + pali; s2 += " *" + nis.pali; }
                if (trans != nis.trans) { s1 += " ^" + trans; s2 = " ^" + nis.trans; }
                if (footnote != nis.footnote) { s1 += " @" + footnote; s2 = " @" + nis.footnote; }
                return (s1.Length > 0) ? s1.Trim() + "|" + s2.Trim() : string.Empty;
            }
            public override string ToString()
            {
                string s = String.Format("{0}{1} {2}{3}", "*", pali, "^", trans);
                if (footnote.Length > 0)
                {
                    s += " @" + footnote;
                }
                return s;
            }
        };
        //*******************************************************************
        //*** Parse Nissaya page
        //*******************************************************************
        public List<NissayaRecord> ParsePage(string page)
        {
            List<NissayaRecord> pageRecords = new List<NissayaRecord>();
            if (page.Trim().Length == 0) return pageRecords;
            string[] nissayaRecords = page.Split('*');
            //int pgno = Convert.ToInt16(nissayaRecords[0]);
            int recCount = 0;
            foreach (string nissayaRecord in nissayaRecords)
            {
                if (nissayaRecord.Trim().Length == 0) continue;
                ++recCount;
                NissayaRecord nissayaRec = new NissayaRecord();
                nissayaRec.recNo = recCount;
                string[] f = nissayaRecord.Split('^');
                nissayaRec.pali = f[0].Trim();
                // check if there is footnote
                if (f.Length > 1)
                {
                    string[] ff = f[1].Split('@');
                    nissayaRec.trans = ff[0].Trim();
                    if (ff.Length == 2) nissayaRec.footnote = ff[1].Trim();
                }
                pageRecords.Add(nissayaRec);
            }
            return pageRecords;
        }
        //*******************************************************************
        //*** Make into Nissaya page
        //*******************************************************************
        public string MakeNissayaPage(int pgNo, List<NissayaRecord> pageRecords)
        {
            string nisRecord = String.Format("#{0}", pgNo);
            foreach (NissayaRecord rec in pageRecords)
            {
                nisRecord += " *" + rec.pali;
                nisRecord += " ^" + rec.trans;
                if (rec.footnote.Length > 0) nisRecord += " @" + rec.footnote;
            }
            return nisRecord;
        }
        public List<NissayaRecord> ParseNissayaPage(string nisPage)
        {
            if (nisPage.Length == 0) return new List<NissayaRecord> { };
            int pgno;
            if (nisPage[0] == '#') nisPage = nisPage.Substring(1);
            int pos = nisPage.IndexOfAny(new char[] { ' ', '*' });
            if (pos != -1) pgno = int.Parse(nisPage.Substring(0, pos).Trim());
            if (nisPage[pos] == ' ') pos = nisPage.IndexOf('*');
            string pg = nisPage.Substring(pos);
            List<NissayaRecord> records = ParsePage(pg);
            return records;
        }
        //*******************************************************************
        //*** Email a message to a user
        //*******************************************************************
        public void SendViaMailTrapSMTP(string toEmail, string ccEmail, string bccEmail, string subject, string body)
        {
            MailAddress to = new MailAddress(toEmail);
            MailAddress from = new MailAddress("tipitaka.manager@dhammayaungchi.net");
            MailMessage message = new MailMessage(from, to);
            if (ccEmail != null && ccEmail.Length > 0)
            {
                string[] ccList = ccEmail.Split(',');
                foreach (string cc in ccList) { message.CC.Add(new MailAddress(cc.Trim())); }
            }
            if (bccEmail != null && bccEmail.Length > 0)
            {
                string[] bccList = bccEmail.Split(',');
                foreach (string bcc in bccList) { message.Bcc.Add(new MailAddress(bcc.Trim())); }
            }
            message.Subject = subject;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            string[] arrBody = body.Split("|");
            foreach(string item in arrBody)
                message.Body += item + "\r\n";

            //SmtpClient client = new SmtpClient("smtp.server.address", 2525);
            var client = new System.Net.Mail.SmtpClient("send.smtp.mailtrap.io", 587)
            {
                Credentials = new NetworkCredential("api", "f20abd03659726c3f7516aeb624b80ca"),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string MakeDateTimeQualifier(DateTime? date1, DateTime? date2)
        {
            if (date1 == null && date2 == null) return string.Empty;
            date1 = new DateTime(date1!.Value.Year, date1.Value.Month, date1.Value.Day, 0, 0, 0);
            date2 = date2!.Value.AddDays(1);
            date2 = new DateTime(date2!.Value.Year, date2.Value.Month, date2.Value.Day, 0, 0, 0);
            if (DateTime.Compare(date1.Value, date2.Value) > 0)
            {
                DateTime dateTmp = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day, 0, 0, 0);
                date2 = date1; date1 = dateTmp;
            }
            date1 = date1.Value.ToUniversalTime();
            date2 = date2.Value.ToUniversalTime();
            string qualifier = string.Empty;
            qualifier = String.Format("{0}{1}{2}", date1.Value.Year.ToString("D4"), date1.Value.Month.ToString("D2"), date1.Value.Day.ToString("D2"));
            qualifier += String.Format("-{0}:{1}:{2}|", date1.Value.Hour.ToString("D2"), date1.Value.Minute.ToString("D2"), date1.Value.Second.ToString("D2"));
            qualifier += String.Format("{0}{1}{2}", date2.Value.Year.ToString("D4"), date2.Value.Month.ToString("D2"), date2.Value.Day.ToString("D2"));
            qualifier += String.Format("-{0}:{1}:{2}|", date2.Value.Hour.ToString("D2"), date2.Value.Minute.ToString("D2"), date2.Value.Second.ToString("D2"));

            return qualifier;
        }
        //*******************************************************************
        //*** Email a message to multiple recipients
        //*******************************************************************
        public void SendMultipleViaMailTrapSMTP(string toEmail, string[] bccEmail, string subject, string body)
        {
            string tipitakaManager = "tipitaka.manager@dhammayaungchi.net";
            MailAddress to = new MailAddress(toEmail);
            MailAddress from = new MailAddress(tipitakaManager);
            MailMessage message = new MailMessage(from, to);
            message.Bcc.Add(new MailAddress(tipitakaManager));
            foreach (string email in bccEmail)
            {
                message.Bcc.Add(new MailAddress(email));
            }
            message.Subject = subject;
            message.Body = body;
            //SmtpClient client = new SmtpClient("smtp.server.address", 2525);
            var client = new System.Net.Mail.SmtpClient("send.smtp.mailtrap.io", 587)
            {
                Credentials = new NetworkCredential("api", "f20abd03659726c3f7516aeb624b80ca"),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Message sent to " + toEmail);
        }
        //*******************************************************************
        //*** Get local time from universal time code.
        //*******************************************************************
        public string GetLocalTime(string dt)
        {
            string s = string.Empty;
            if (dt.Length == 0) return s;
            int yr, mon, day, hr, min, sec;
            string[] f = dt.Split('-');
            yr = Convert.ToInt16(dt.Substring(0, 4));
            mon = Convert.ToInt16(dt.Substring(4, 2));
            day = Convert.ToInt16(dt.Substring(6, 2));
            if (f.Length >= 2)
            {
                if (f[1].IndexOf(':') != -1) f[1] = f[1].Replace(":", string.Empty);
                hr = Convert.ToInt16(f[1].Substring(0, 2));
                min = Convert.ToInt16(f[1].Substring(2, 2));
                sec = Convert.ToInt16(f[1].Substring(4, 2));
            }
            else hr = min = sec = 0;
            s = new DateTime(yr, mon, day, hr, min, sec).ToLocalTime().ToString("yyyy'-'MM'-'dd' 'HH':'mm");
            return s;
        }
        //*******************************************************************
        //*** Get formatted datetime string.
        //*******************************************************************
        public string GetFormattedDateTimeString(DateTime dt, bool dateOnly = false)
        {
            if (dateOnly)
            {
                return String.Format("{0}-{1}-{2}", dt.Year, dt.Month.ToString("D2"), dt.Day.ToString("D2"));
            }
            string dtStr = dt.Year.ToString() + dt.Month.ToString("D2") + dt.Day.ToString("D2");
            dtStr += "-" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
            dtStr += "." + dt.Millisecond.ToString();
            return dtStr;
        }
        //*******************************************************************
        //*** Get formatted datetime string.
        //*******************************************************************
        public string GetFormattedDateTimeString1(DateTime dt, bool dateOnly = false)
        {
            if (dateOnly)
            {
                return String.Format("{0}-{1}-{2}", dt.Year, dt.Month.ToString("D2"), dt.Day.ToString("D2"));
            }
            string dtStr = String.Format("{0}-{1}-{2} | ", dt.Year.ToString(), dt.Month.ToString("D2"), dt.Day.ToString("D2"));
            dtStr += String.Format("{0}:{1}:{2}", dt.Hour.ToString("D2"), dt.Minute.ToString("D2"), dt.Second.ToString("D2"));
            //dtStr += "." + dt.Millisecond.ToString();
            return dtStr;
        }
        //*******************************************************************
        //*** ProcessCatchErrorMessage
        //*******************************************************************
        static public int ProcessCatchErrorMessage(string[] msg)
        {
            string DBErrMsg = string.Empty;
            int StatusCode = -1;
            if (msg.Length == 0) return -1;
            DBErrMsg = msg[0];
            var s1 = msg.Where(x => x.Contains("Status"));
            if (s1 != null)
            {
                var s = s1.ToArray()[0];
                int start = s.IndexOf(" ") + 1;
                int end = s.IndexOf(" ", start);
                if (end != -1)
                    StatusCode = Convert.ToInt16(s.Substring(start, end - start));
            }
            return StatusCode;
        }
        static public string ProcessCatchErrorMessageStr(string[] msg)
        {
            string DBErrMsg = string.Empty;
            int StatusCode = ProcessCatchErrorMessage(msg);
            return StatusCode.ToString() + "|" + msg[0];
        }
        //*******************************************************************
        //*** MessageCenter
        //*******************************************************************
#nullable enable
        public void MessageCenter(ClientTipitakaDB? clientTipitakaDB, string action, List<string> admins, string userID,
            string SuttaNo = "", int startPage = 0, int endPage = 0, int nPages = 0)
        {
            if (clientTipitakaDB == null) return;

            ClientTipitakaDBLogin? clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
            ClientActivityLog? clientActivityLog = clientTipitakaDB.GetClientActivityLog();
            ClientUserProfile? clientUserProfile = clientTipitakaDB.GetClientUserProfile();
            ClientMessageLog? clientMessageLog = clientTipitakaDB?.GetClientMessageLog();

            const string UserProfile = "UserProfile";
            const string SuttaPageAssignment = "SuttaPageAssignment";
            if (clientTipitakaDB != null && clientActivityLog != null && clientTipitakaDBLogin != null && clientTipitakaDBLogin.loggedinUser != null)
            {
                string MsgType = action.Contains(UserProfile) ? UserProfile : SuttaPageAssignment;
                string activity = string.Empty;
                string subject = string.Empty;
                string cc = string.Empty;
                string body = string.Empty;
                string bcc = String.Join(',', admins);
                switch(MsgType)
                {
                    case UserProfile:
                        activity = String.Format("{0} : {1}.", userID, action);
                        // email
                        subject = String.Format("{0}", action);
                        body = String.Format("Subject : {0}", subject);
                        body += String.Format("||UserID : {0}", userID);
                        body += String.Format("|Issued by : {0}", clientTipitakaDBLogin.loggedinUser.RowKey);
                        break;
                    case SuttaPageAssignment:
                        // activity
                        activity = String.Format("{0} : {1} pages {2}-{3} ({4}) {5}.", userID, SuttaNo, startPage, endPage, nPages, action);
                        // email
                        subject = String.Format("Pages {0}", action);
                        body = String.Format("Subject : {0}", subject);
                        body += String.Format("||UserID : {0}", userID);
                        body += String.Format("|Sutta # : {0}", SuttaNo);
                        body += String.Format("|Pages : {0}-{1} ({2})", startPage, endPage, nPages);
                        body += String.Format("|Issued by : {0}", clientTipitakaDBLogin.loggedinUser.RowKey);
                        break;
                }
                clientActivityLog.AddActivityLog(clientTipitakaDBLogin!.loggedinUser!.RowKey, activity);
                clientTipitakaDB.SendViaMailTrapSMTP(userID, cc, bcc, subject, body);
                AutoClosingMessageBox.Show("Message sent to " + userID + ".", "Message", 1500);
                // Message log
                if (clientMessageLog != null)
                {
                    clientMessageLog.AddMessageLog(clientTipitakaDBLogin!.loggedinUser!.RowKey, userID,
                        subject, body, action);
                }
            }
        }
        public void MessageCenter(ClientTipitakaDB? clientTipitakaDB, UserProfile userProfile, string action, List<string> admins)
        {
            if (clientTipitakaDB == null) return;
            const string tipitakaAdmin = "tipitaka.manager@gmail.com";
            ClientTipitakaDBLogin? clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
            ClientActivityLog? clientActivityLog = clientTipitakaDB.GetClientActivityLog();
            ClientMessageLog? clientMessageLog = clientTipitakaDB?.GetClientMessageLog();
            string password = string.Empty;
            string activity = String.Format("{0} : {1}.", userProfile.RowKey, action);
            // email
            string subject = String.Format("{0}", action);
            string body = String.Format("Subject : {0}", subject);
            body += String.Format("||UserID : {0}", userProfile.RowKey);
            body += String.Format("|Name (Eng) : {0}", userProfile.Name_E);
            body += String.Format("|Name (Mya) : {0}", userProfile.Name_M);
            body += String.Format("|User Class : {0}", userProfile.UserClass);
            body += "|Password : *****";
            if (clientTipitakaDBLogin != null && clientTipitakaDBLogin.loggedinUser != null)
            {
                body += String.Format("|Issued by : {0}", clientTipitakaDBLogin.loggedinUser.RowKey);
                clientActivityLog.AddActivityLog(clientTipitakaDBLogin!.loggedinUser!.RowKey,  activity);

            }
            string cc = string.Empty; string bcc = string.Empty; string admin0 = string.Empty;
            if (action.Contains("created"))
            {
                foreach(string admin in admins)
                {
                    if (admin != tipitakaAdmin)
                    {
                        if (cc.Length > 0) cc += ",";
                        cc += admin;
                    }
                }
                clientTipitakaDB!.SendViaMailTrapSMTP(tipitakaAdmin, cc, bcc, subject, body);
                if (clientMessageLog != null)
                {
                    clientMessageLog.AddMessageLog(clientTipitakaDBLogin!.loggedinUser!.RowKey, userProfile.RowKey,
                    subject, body, activity);
                }
            }
            // Message log
            body = body.Replace("*****", userProfile.Password);
            cc = string.Empty;
            clientTipitakaDB!.SendViaMailTrapSMTP(userProfile.RowKey, cc, bcc, subject, body);
            AutoClosingMessageBox.Show("Message sent to " + userProfile.RowKey + ".", "Message", 1500);
        }
        //*******************************************************************
        //*** Class: AutoClosingMessageBox
        //*******************************************************************
        // Credit: https://stackoverflow.com/questions/14522540/close-a-messagebox-after-several-seconds
#nullable disable
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed!,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout = 500)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}

