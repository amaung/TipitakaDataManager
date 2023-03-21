using System;
using System.Windows.Forms;
using Tipitaka_DB;
using Tipitaka_DBTables;

namespace TipitakaDataManager
{
    public partial class Form1 : Form
    {
        public ClientTipitakaDB clientTipitakaDB;
        public ClientTipitakaDBLogin clientTipitakaDBLogin;
        public ClientActivityLog clientActivityLog;
        public ClientUserProfile clientUserProfile;
        public ClientSuttaPageAssignment clientSuttaAssignment;
        public ClientSuttaInfo clientSuttaInfo;
        public ClientUserPageActivity clientUserPageActivity;
        public ClientMessageLog clientMessageLog;
        private Form_Home? form_Home;
        public Form_UserProfiles? form_UserProfiles;
        public Form_MessageLog? form_MessageLog;
        public Form_ActivityLog? form_ActivityLog;
        public Form_SuttaInfo? form_SuttaInfo;
        public Form_WorkAssignment? form_WorkAssignment;
        public Form_UserActivities? form_UserActivities;
        public Form_UpdateHistory? form_UpdateHistory;
        public Form_ProgressReport? form_ProgressReport;

        private List<Form> formList = new List<Form>();
        public List<string> listAdmins = new List<string>();
        private List<Button> buttonList = new List<Button>();
        private Button? currentButton = null;
        private Color currentBackColor = SystemColors.ControlDark;  //System.Drawing.Color.Tan; 
        private Color inactiveBackColor = SystemColors.Window;

        public Color CellBackgroundColor = SystemColors.Control;  //Color.FromArgb(250, 255, 236); OldLace olor.FromArgb(253, 245, 230);
        public Color HeaderBackGroundColor = SystemColors.ScrollBar; //.ActiveCaption;//.ControlDark;

        private const string Version = "Version Alpha 0.1.1";
        public Form1()
        {
            InitializeComponent();
            clientTipitakaDB = new ClientTipitakaDB();
            clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
            clientActivityLog = clientTipitakaDB.GetClientActivityLog();
            clientUserProfile = clientTipitakaDB.GetClientUserProfile();
            clientSuttaAssignment = clientTipitakaDB.GetClientSuttaAssignment();
            clientSuttaInfo = clientTipitakaDB.GetClientSuttaInfo();
            clientUserPageActivity = clientTipitakaDB.GetClientUserPageActivity();
            clientMessageLog = clientTipitakaDB.GetClientMessageLog();
            currentButton = button_Home;
            currentButton.BackColor = currentBackColor;
            //currentButton.ForeColor = SystemColors.HighlightText;
            this.Text += ", " + Version;
        }
        private void button_Quit_Click(object sender, EventArgs e)
        {
            if (clientTipitakaDBLogin!.loggedinUser != null && clientTipitakaDBLogin!.loggedinUser.UserClass != "D")
            {
                clientActivityLog.AddActivityLog(clientTipitakaDBLogin.loggedinUser.RowKey, "Logged out.");
            }
            Application.Exit();
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            // create Home form
            form_Home = new Form_Home(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_Home.Text = button_Home.Text;
            formList.Add(form_Home);
            panel_Login.Controls.Add(form_Home);
            form_Home.Visible = true;
            // create UserProfiles form
            form_UserProfiles = new Form_UserProfiles(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_UserProfiles.Text = button_UserProfiles.Text;
            button_UserProfiles.Enabled = false;
            formList.Add(form_UserProfiles);
            panel_Login.Controls.Add(form_UserProfiles);
            buttonList.Add(button_UserProfiles);
            // create MessageLog form
            form_MessageLog = new Form_MessageLog(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_MessageLog.Text = button_MessageLog.Text;
            button_MessageLog.Enabled = false;
            formList.Add(form_MessageLog);
            panel_Login.Controls.Add(form_MessageLog);
            buttonList.Add(button_MessageLog);
            // create ActivityLog form
            form_ActivityLog = new Form_ActivityLog(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_ActivityLog.Text = button_ActivityLog.Text;
            button_ActivityLog.Enabled = false;
            formList.Add(form_ActivityLog);
            panel_Login.Controls.Add(form_ActivityLog);
            buttonList.Add(button_ActivityLog);
            // create SuttaInfo form
            form_SuttaInfo = new Form_SuttaInfo(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_SuttaInfo.Text = button_SuttaInfo.Text;
            button_SuttaInfo.Enabled = false;
            formList.Add(form_SuttaInfo);
            panel_Login.Controls.Add(form_SuttaInfo);
            buttonList.Add(button_SuttaInfo);
            // create Work Assignment
            form_WorkAssignment = new Form_WorkAssignment(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_WorkAssignment.Text = button_WorkAssignment.Text;
            button_WorkAssignment.Enabled = false;
            formList.Add(form_WorkAssignment);
            panel_Login.Controls.Add(form_WorkAssignment);
            buttonList.Add(button_WorkAssignment);
            // create User Activities
            form_UserActivities = new Form_UserActivities(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_UserActivities.Text = button_UserActivities.Text;
            button_UserActivities.Enabled = false;
            formList.Add(form_UserActivities);
            panel_Login.Controls.Add(form_UserActivities);
            buttonList.Add(button_UserActivities);
            // create Update History
            form_UpdateHistory = new Form_UpdateHistory(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_UpdateHistory.Text = button_UpdateHistory.Text;
            button_UpdateHistory.Enabled = false;
            formList.Add(form_UpdateHistory);
            panel_Login.Controls.Add(form_UpdateHistory);
            buttonList.Add(button_UpdateHistory);
            // create Progress Report
            form_ProgressReport = new Form_ProgressReport(this)
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_ProgressReport.Text = button_ProgressReport.Text;
            button_ProgressReport.Enabled = false;
            formList.Add(form_ProgressReport);
            panel_Login.Controls.Add(form_ProgressReport);
            buttonList.Add(button_ProgressReport);
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == currentButton) return;

            if (currentButton != null) 
            {
                currentButton.BackColor = SystemColors.ControlLight;
                //currentButton.ForeColor = SystemColors.ControlText;
            }
            btn.BackColor = currentBackColor;
            //btn.ForeColor = SystemColors.HighlightText;
            currentButton = btn;

            foreach (Form form in formList)
            {
                form.Visible = (form.Text == btn.Text);
            }
        }
        public void EnableButtons()
        {
            foreach (Button btn in buttonList)
            {
                btn.Enabled = true;
                btn.BackColor = System.Drawing.SystemColors.ControlLight;
            }
        }
        public void LoadInitialData()
        {
            if (form_UserProfiles != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_UserProfiles.LoadInitialData(); }

            if (form_MessageLog != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_MessageLog.LoadInitialData(); }

            if (form_ActivityLog != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_ActivityLog.LoadInitialData(); }

            if (form_SuttaInfo != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_SuttaInfo.LoadInitialData(); }

            if (form_WorkAssignment != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_WorkAssignment.LoadInitialData(); }

            if (form_UserActivities != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_UserActivities.LoadInitialData(); }

            if (form_UpdateHistory != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_UpdateHistory.LoadInitialData(); }

            if (form_ProgressReport != null && clientTipitakaDBLogin.loggedinUser != null)
            { form_ProgressReport.LoadInitialData(); }

            listAdmins.Clear();
            listAdmins.AddRange(form_UserProfiles!.GetAdmins());
        }
        public UserProfile? GetUserProfile(string userID)
        {
            UserProfile? userProfile = null;
            if (form_UserProfiles != null) return form_UserProfiles!.GetUserProfile(userID);
            return userProfile;
        }
        public List<UserProfile>? GetAllUserProfiles()
        {
            if (form_UserProfiles != null) return form_UserProfiles.GetAllUserProfiles();
            return null;
        }
        public List<string> GetAdmins()
        {
            if (form_UserProfiles != null) return form_UserProfiles.GetAdmins();
            return new List<string>();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientTipitakaDBLogin!.loggedinUser != null && clientTipitakaDBLogin!.loggedinUser.UserClass != "D")
            {
                clientActivityLog.AddActivityLog(clientTipitakaDBLogin.loggedinUser.RowKey, "Logged out.");
            }
        }
    }
}