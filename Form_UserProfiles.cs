using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using Tipitaka_DB;
using Tipitaka_DBTables;
using TipitakaDataManager.Properties;
using static Azure.Core.HttpHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static Tipitaka_DB.TipitakaDB;

namespace TipitakaDataManager
{
    public partial class Form_UserProfiles : Form
    {
        Form1 parent;
        ClientUserProfile? clientUserProfile;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;
        ClientSuttaPageAssignment? clientSuttaPageAssignment;
        ClientSuttaInfo? clientSuttaInfo;
        ClientUserPageActivity? clientUserPageActivity;
        ClientMessageLog? clientMessageLog;
        ClientTipitakaDB? clientTipitakaDB;
        List<UserProfile>? listUserProfile;
        Dictionary<string, UserProfile>? dictUserProfile;
        bool showPassword = true;
        bool curProfileIsLoginUser = true;
        List<string> listAdmins = new List<string>();
        public List<string> GetAdmins() { return listAdmins; }
        public List<UserProfile>? GetAllUserProfiles() { return listUserProfile; }
        public Form_UserProfiles(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            clientUserProfile = parent.clientUserProfile as ClientUserProfile;
            clientTipitakaDBLogin = parent.clientTipitakaDBLogin as ClientTipitakaDBLogin;
            clientSuttaPageAssignment = parent.clientSuttaAssignment as ClientSuttaPageAssignment;
            clientSuttaInfo = parent.clientSuttaInfo as ClientSuttaInfo;
            clientUserPageActivity = parent.clientUserPageActivity as ClientUserPageActivity;
            clientMessageLog = parent.clientMessageLog as ClientMessageLog;
            clientTipitakaDB = parent.clientTipitakaDB as ClientTipitakaDB;
            InitDataGridView();
            button_ShowPswd.Image = Resources.showPasswordEye;
        }
        private void InitDataGridView()
        {
            dataGridView_Users.ReadOnly = true;
            dataGridView_Users.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView_Users.ColumnCount = 1;
            dataGridView_Users.RowTemplate.Height = 30;
            //dataGridView_Users.RowHeadersWidth = 25;
            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows.
            dataGridView_Users.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView_Users.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView_Users.EnableHeadersVisualStyles = false;
            dataGridView_Users.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView_Users.RowHeadersVisible = false;
            dataGridView_Users.ColumnHeadersHeight = 50;
            dataGridView_Users.Columns[0].HeaderText = "User ID";
            dataGridView_Users.Columns[0].Width = dataGridView_Users.Width - 3;
            dataGridView_Users.AllowUserToResizeColumns = false;
            dataGridView_Users.MultiSelect = false;
            dataGridView_Users.CellClick += dataGridView_CellClick!;
        }
        public void LoadInitialData()
        {
            if (dataGridView_Users.Rows.Count > 1) return;
            bool inclDev = clientTipitakaDBLogin?.loggedinUser?.UserClass == "D";
            if (clientUserProfile is not null) listUserProfile = clientUserProfile.GetAllUsers(inclDev);
            else listUserProfile = new List<UserProfile>();
            dictUserProfile = new Dictionary<string, UserProfile>();
            int count = -1;
            int r = 0;
            foreach (UserProfile userProfile in listUserProfile)
            {
                ++count;
                dictUserProfile.Add(userProfile.RowKey, userProfile);
                DataGridViewRow row = (DataGridViewRow)dataGridView_Users.Rows[0].Clone();
                row.Cells[0].Value = userProfile.RowKey;
                if (userProfile.RowKey == clientTipitakaDBLogin?.loggedinUser?.RowKey) r = count;
                dataGridView_Users.Rows.Add(row);
                if (userProfile.UserClass == "A") listAdmins.Add(userProfile.RowKey);
            }
            // select current user/row
            dataGridView_Users.CurrentCell = dataGridView_Users.Rows[r].Cells[0];
            FillUserProfile(listUserProfile[r]);
            //button_Add.Enabled = false;
        }
        private void FillUserProfile(UserProfile userProfile)
        {
            textBox_UserID.Text = userProfile.RowKey;
            textBox_NameE.Text = userProfile.Name_E;
            textBox_NameM.Text = userProfile.Name_M;
            if (clientUserProfile is not null && userProfile.RowKey != clientTipitakaDBLogin!.loggedinUser!.RowKey)
            {
                textBox_Password.Text = clientUserProfile.Encrypt(userProfile.Password, userProfile.PID, false);
                button_ShowPswd.Enabled = false;
            }
            else
            { textBox_Password.Text = string.Empty; button_ShowPswd.Enabled = true; }
            textBox_NewPswd.Text = textBox_RetypePswd.Text = string.Empty;
            if (clientUserProfile is not null) comboBox_UserClass.Text = clientUserProfile.GetUserClass(userProfile.UserClass);
            else comboBox_UserClass.Text = string.Empty;
            comboBox_UserStatus.Text = userProfile.Status;
            textBox_Remarks.Text = userProfile.Remarks;
            textBox_NewPswd.Text = textBox_RetypePswd.Text = string.Empty;
            curProfileIsLoginUser = (userProfile.RowKey == clientTipitakaDBLogin!.loggedinUser!.RowKey);
            EnableControls("UserProfile");
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_Users.Rows.Count - 1 && listUserProfile != null)
            {
                FillUserProfile(listUserProfile[e.RowIndex]);
            }
        }
        private void button_GenPassword_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            textBox_Password.Text = r.Next(10000, 99999).ToString();
        }
        private void button_New_Click(object sender, EventArgs e)
        {
            EnableControls("New");
            UserProfile userProfile = new UserProfile();
            dataGridView_Users.ClearSelection();
            //clear
            textBox_UserID.Text = textBox_NameE.Text = textBox_NameM.Text = textBox_Password.Text = string.Empty;
            textBox_Remarks.Text = comboBox_UserClass.Text = comboBox_UserStatus.Text = string.Empty;
            textBox_NewPswd.Text = textBox_RetypePswd.Text = string.Empty;
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_UserID.Text.Length == 0)
            {
                MessageBox.Show("The User ID field cannot be empty."); return;
            }
            if (textBox_NameE.Text.Length == 0 || comboBox_UserClass.Text.Length == 0 || comboBox_UserStatus.Text.Length == 0)
            {
                MessageBox.Show("Some required fields are not entered."); return;
            }
            if (textBox_Password.Text == string.Empty) button_GenPassword_Click(button_GenPassword, new EventArgs());

            string toEmail = textBox_UserID.Text.Trim();
            if (toEmail == "auzm2002@yahoo.com")
            {
                MessageBox.Show("This is a system reserved user account and cannot create it.");
                return;
            }
            string ccEmail = string.Empty;
            string body =
                "Subject: New user account created.\r\n\r\nUser ID: %email%\r\nUser Name (Eng): %NameE%\r\nUser Name (Mya): %NameM%\r\nUser Password: %Pswd%\r\nUser Class: %Class%\r\nUser Status: %Status%";
            //string bodyMsg = "Subject: New user account created.||User ID: %email%|User Name (Eng): %NameE%|User Name (Mya): %NameM%|User Password: *****|User Class: %Class%|User Status: %Status%";
            foreach (string email in listAdmins)
            {
                if (ccEmail.Length > 0) ccEmail += ", ";
                ccEmail += email;
            }
            body = body.Replace("%email%", textBox_UserID.Text);
            body = body.Replace("%NameE%", textBox_NameE.Text);
            body = body.Replace("%NameM%", textBox_NameM.Text);
            body = body.Replace("%Pswd%", textBox_Password.Text);
            body = body.Replace("%Class%", comboBox_UserClass.Text);
            body = body.Replace("%Status%", comboBox_UserStatus.Text);
            this.Cursor = Cursors.WaitCursor;

            // create new user profile
            UserProfile userProfile = clientUserProfile!.AddUserProfile(textBox_UserID.Text, textBox_NameE.Text, textBox_NameM.Text, textBox_Password.Text, GetUserClassCode(comboBox_UserClass.Text), textBox_Remarks.Text);
            if (clientUserProfile.StatusCode != 204)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error in creating " + userProfile.RowKey + " user profile.");
                return;
            }
            if (dictUserProfile != null)
            {
                dictUserProfile.Add(userProfile.RowKey, userProfile);
                DataGridViewRow row = (DataGridViewRow)dataGridView_Users.Rows[0].Clone();
                row.Cells[0].Value = userProfile.RowKey;
                dataGridView_Users.Rows.Add(row);
                if (userProfile.UserClass == "A") listAdmins.Add(userProfile.RowKey);
                dataGridView_Users.Rows[dataGridView_Users.Rows.Count - 2].Selected = true;
            }
            // send email to the new user
            //parent.clientTipitakaDB.SendMultipleViaMailTrapSMTP(toEmail, listAdmins.ToArray(), subject, body);
            // update MessageLog
            AutoClosingMessageBox.Show(userProfile.RowKey + " UserProfile created.", "New User", 1000);
            clientTipitakaDB!.MessageCenter(clientTipitakaDB, userProfile, "UserProfile created", GetAdmins());
            if (listUserProfile != null) listUserProfile.Add(userProfile);
            // update new user in the user list in various forms
            if (parent.form_WorkAssignment != null) parent.form_WorkAssignment.UpdateUserList();
            if (parent.form_UserActivities != null) parent.form_UserActivities.LoadInitialData();
            if (parent.form_MessageLog != null) parent.form_MessageLog.LoadInitialData();
            if (parent.form_ActivityLog != null) parent.form_ActivityLog.LoadInitialData();
            this.Cursor = Cursors.Default;
            EnableControls("UserProfile");
        }
        private void EnableControls(string sender)
        {
            switch (sender)
            {
                case "Add":
                    button_Add.Enabled = false;
                    button_New.Enabled = true;
                    button_Remove.Enabled = false;
                    button_Update.Enabled = false;
                    button_ShowPswd.Enabled = false;
                    break;
                case "New":
                    button_Add.Enabled = true;
                    button_New.Enabled = false;
                    button_Remove.Enabled = false;
                    button_Update.Enabled = false;
                    button_ShowPswd.Enabled = textBox_Password.Enabled = textBox_NewPswd.Enabled = textBox_RetypePswd.Enabled = false;
                    button_GenPassword.Enabled = true;
                    break;
                case "UserProfile":
                    button_Add.Enabled = false;
                    button_New.Enabled = true;
                    button_Remove.Enabled = true;
                    button_Update.Enabled = true;
                    button_ShowPswd.Enabled = textBox_NewPswd.Enabled = textBox_RetypePswd.Enabled = curProfileIsLoginUser;
                    button_GenPassword.Enabled = !textBox_NewPswd.Enabled;
                    break;
                case "All":
                    button_Add.Enabled = button_New.Enabled = button_Remove.Enabled = button_Update.Enabled = true;
                    textBox_NewPswd.Enabled = textBox_RetypePswd.Enabled = button_ShowPswd.Enabled = button_GenPassword.Enabled = true;
                    break;
            }
            button_Remove.Enabled = button_Update.Enabled = false;
        }
        private void button_Update_Click(object sender, EventArgs e)
        {
            string curPswd = textBox_Password.Text;
            string newPswd = textBox_NewPswd.Text;
            string conPswd = textBox_RetypePswd.Text;
            if (clientTipitakaDBLogin!.loggedinUser!.Password != curPswd)
            {
                MessageBox.Show("Your current password is not correct."); return;
            }
            if (newPswd != conPswd)
            {
                MessageBox.Show("Your new and retyped passwords don't match."); return;
            }
            if (curPswd == newPswd)
            {
                MessageBox.Show("Your current and new passwords are the same."); return;
            }
            clientTipitakaDBLogin.loggedinUser.Name_E = textBox_NameE.Text;
            clientTipitakaDBLogin.loggedinUser.Name_M = textBox_NameM.Text;
            clientTipitakaDBLogin.loggedinUser.Password = textBox_NewPswd.Text.Trim();
            clientTipitakaDBLogin.loggedinUser.UserClass = GetUserClassCode(comboBox_UserClass.Text);
            clientTipitakaDBLogin.loggedinUser.Status = comboBox_UserStatus.Text;
            clientTipitakaDBLogin.loggedinUser.Remarks = textBox_Remarks.Text;
            clientUserProfile!.GetUserProfile(textBox_UserID.Text);
            if (clientUserProfile.StatusCode != 200)
            {
                MessageBox.Show("Internal error: " + textBox_UserID.Text + " user not found."); return;
            }
            UserProfile userProfile = (UserProfile)clientUserProfile.objResult;
            userProfile.Name_E = textBox_NameE.Text;
            userProfile.Name_M = textBox_NameM.Text;
            userProfile.Password = textBox_NewPswd.Text.Trim();
            userProfile.UserClass = GetUserClassCode(comboBox_UserClass.Text);
            userProfile.Status = comboBox_UserStatus.Text;
            userProfile.Remarks = textBox_Remarks.Text;
            clientUserProfile!.UpdateUserProfile(userProfile);
            if (clientUserProfile.StatusCode != 204)
            {
                MessageBox.Show(textBox_UserID.Text + " profile update error.");
            }
        }
        private string GetUserClassCode(string userClass)
        {
            string code = string.Empty;
            if (userClass.Length == 0) return code;
            switch (userClass)
            {
                case "Developer": code = "D"; break;
                case "Data Entry User": code = "U"; break;
                case "Administrator": code = "A"; break;
                case "Proof Reader": code = "R"; break;
            }
            return code;
        }
        private void button_Remove_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(textBox_UserID.Text + " and all assigned work will be removed. Confirm Yes/No?", "Remove User", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) { return; }
            if (clientSuttaPageAssignment != null)
            {
                clientSuttaPageAssignment.SetSubPartitionKey("");
                List<SuttaPageAssignment> listSuttaAssignment = clientSuttaPageAssignment.QuerySuttaPageAssignmentByUser(textBox_UserID.Text);
                //List<SuttaPageAssignment> listSuttaAssignment = (List<SuttaPageAssignment>)clientSuttaPageAssignment.objResult;
                var numSubmitted = listSuttaAssignment.Count(n => n.Status == "Submitted");
                if (numSubmitted > 0)
                {
                    string msg = textBox_UserID.Text + " already has some work submitted and cannot be removed.";
                    if (comboBox_UserStatus.Text == "Active") msg += " You can only block or suspend this user.";
                    MessageBox.Show(msg); return;
                }
                // the user can be removed from SuttaInfo, SuttaPageAssignment, UserPageActivity
                string MNno = string.Empty;
                string userID = textBox_UserID.Text;
                int noPg;
                this.Cursor = Cursors.WaitCursor;
                foreach (SuttaPageAssignment suttaPageAssignment in listSuttaAssignment)
                {
                    MNno = suttaPageAssignment.PartitionKey;
                    noPg = suttaPageAssignment.EndPage - suttaPageAssignment.StartPage + 1;

                    clientSuttaPageAssignment.DeleteSuttaPageAssignment(suttaPageAssignment);
                    if (clientSuttaPageAssignment.StatusCode != 204)
                    {
                        MessageBox.Show("Error in removing " + textBox_UserID.Text + "'s user assignments.");
                        return;
                    }
                    if (clientSuttaInfo != null)
                    {
                        UpdateSuttaInfo(textBox_UserID.Text, MNno, noPg);
                        RemoveUserPageActivityRecords(userID, MNno, suttaPageAssignment.StartPage, suttaPageAssignment.EndPage);
                    }
                }
                if (clientUserProfile != null && userID != null)
                {
                    clientUserProfile.DeleteUserProfile(userID);
                    // remove from the list
                    int rowIndex = dataGridView_Users.CurrentRow.Index;
                    dataGridView_Users.Rows.RemoveAt(rowIndex);
                    if (listUserProfile != null && listUserProfile.Count > 0)
                        listUserProfile.RemoveAt(rowIndex);
                    if (dataGridView_Users.Rows.Count > 1)
                    {
                        if (rowIndex < dataGridView_Users.Rows.Count)
                        {
                            dataGridView_Users.Rows[rowIndex].Selected = true;
                        }
                        else dataGridView_Users.Rows[0].Selected = true;
                    }
                    // do activity message && email
                    DataGridViewCellEventArgs eargs = new DataGridViewCellEventArgs(0, rowIndex);
                    dataGridView_CellClick(this, eargs);
                    if (clientTipitakaDB != null)
                        clientTipitakaDB.MessageCenter(clientTipitakaDB, "UserProfile removed", parent.GetAdmins(), userID);
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void RemoveUserPageActivityRecords(string userID, string MNno, int startPage, int endPage)
        {
            string rowKeyStart = String.Format("{0}-{1}", MNno, startPage.ToString("D3"));
            string rowKeyEnd = String.Format("{0}-{1}", MNno, endPage.ToString("D3"));
            string qualifier = String.Format("AssignedTo eq '{0}' and RowKey ge '{1}' and RowKey le '{2}'",
                userID, rowKeyStart, rowKeyEnd);
            clientUserPageActivity!.QueryUserPageActivity(qualifier);
            List<UserPageActivity> userPageActivities = (List<UserPageActivity>)clientUserPageActivity.objResult;
            if (userPageActivities.Count > 0)
            {
                foreach (UserPageActivity userPageActivity in userPageActivities)
                {
                    clientUserPageActivity.RemoveUserPageActivity(userPageActivity);
                }
            }
        }
        private void UpdateSuttaInfo(string userID, string MNno, int noPg)
        {
            clientSuttaInfo!.QuerySuttaInfo(MNno);
            List<SuttaInfo> listSuttaInfo = (List<SuttaInfo>)clientSuttaInfo.objResult;
            if (listSuttaInfo.Count > 0)
            {
                SuttaInfo suttaInfo = listSuttaInfo[0];
                suttaInfo.AssignedPages -= noPg;
                if (suttaInfo.AssignedPages < 0) suttaInfo.AssignedPages = 0;
                string pattern = userID + "|," + userID;
                suttaInfo.AssignedUsers = Regex.Replace(suttaInfo.AssignedUsers, pattern, string.Empty);
                clientSuttaInfo.UpdateSuttaInfo(suttaInfo);
                if (clientSuttaInfo.StatusCode != 204)
                {
                    MessageBox.Show("SuttaInfo update error.");
                }
            }
        }
        private void button_ShowPswd_Click(object sender, EventArgs e)
        {
            if (showPassword)
            {
                textBox_Password.PasswordChar = textBox_NewPswd.PasswordChar = textBox_RetypePswd.PasswordChar = '\0';
                button_ShowPswd.Image = Resources.hidePasswordEye;
            }
            else
            {
                textBox_Password.PasswordChar = textBox_NewPswd.PasswordChar = textBox_RetypePswd.PasswordChar = '*';
                button_ShowPswd.Image = Resources.showPasswordEye;
            }
            showPassword = !showPassword;
        }
        private void textBox_UserID_Leave(object sender, EventArgs e)
        {
            if (textBox_UserID.Text.Length == 0) return;
            foreach (DataGridViewRow r in dataGridView_Users.Rows)
            {
                if (r.Cells[0].Value != null && r.Cells[0].Value.ToString() == textBox_UserID.Text)
                {
                    MessageBox.Show(textBox_UserID.Text + " user ID already exists.");
                    textBox_UserID.Focus();
                    textBox_UserID.SelectAll();
                    return;
                }
            }
        }
        public UserProfile? GetUserProfile(string userID)
        {
            if (dictUserProfile != null && dictUserProfile.ContainsKey(userID)) return dictUserProfile[userID];
            return null;
        }
    }
}
