using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tipitaka_DB;
using Tipitaka_DBTables;
using static Azure.Core.HttpHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TipitakaDataManager
{
    public partial class Form_WorkAssignment : Form
    {
        Form1 parent;
        ClientTipitakaDB? clientTipitakaDB;
        ClientSuttaInfo? clientSuttaInfo;
        ClientUserPageActivity? clientUserPageActivity;
        ClientSuttaPageAssignment? clientSuttaPageAssignment;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;
        ClientActivityLog? clientActivityLog;
        ClientMessageLog? clientMessageLog;

        Dictionary<string, SuttaInfo> dictSuttaInfo = new Dictionary<string, SuttaInfo>();
        Dictionary<string, List<SuttaPageAssignment>> dictSuttaPageAssignment = new Dictionary<string, List<SuttaPageAssignment>>();
        //        Dictionary<string, List<SuttaPageAssignment>> dictSutta
        private List<UserProfile>? listUserProfile = null;
        string SuttaNo = string.Empty;
        public Form_WorkAssignment(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            InitDataGridView();
            clientTipitakaDB = parent.clientTipitakaDB;
            clientSuttaInfo = clientTipitakaDB.GetClientSuttaInfo();
            clientSuttaPageAssignment = clientTipitakaDB.GetClientSuttaAssignment();
            clientUserPageActivity = clientTipitakaDB.GetClientUserPageActivity();
            clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
            clientActivityLog = clientTipitakaDB.GetClientActivityLog();
            clientMessageLog= clientTipitakaDB.GetClientMessageLog();

            groupBox2.Text = "Sutta Page Assignments : ";
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowHeadersWidth = 25;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Width = 128;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 86;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 90;

            // set column header text and font
            dataGridView1.Columns[0].HeaderText = "Sutta";
            dataGridView1.Columns[1].HeaderText = "StartPage";
            dataGridView1.Columns[2].HeaderText = "EndPage";
            dataGridView1.Columns[3].HeaderText = "Pages";
            dataGridView1.Columns[4].HeaderText = "Assigned";
            dataGridView1.Columns[5].HeaderText = "Submitted";
            dataGridView1.Columns[6].HeaderText = "Verified";

            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToOrderColumns = false;

            dataGridView2.ReadOnly = true;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView2.ColumnCount = 5;
            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.RowHeadersWidth = 25;
            dataGridView2.ColumnHeadersHeight = 50;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 105;
            //dataGridView2.Columns[2].Width = 50;
            dataGridView2.Columns[2].Width = 50;
            dataGridView2.Columns[3].Width = 200;
            dataGridView2.Columns[4].Width = 150;

            dataGridView2.Columns[0].HeaderText = "User ID";
            dataGridView2.Columns[1].HeaderText = "Pages";
            dataGridView2.Columns[2].HeaderText = "Status";
            dataGridView2.Columns[3].HeaderText = "Assigned By";
            dataGridView2.Columns[4].HeaderText = "Assigned Date";
            // centering
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public void LoadInitialData()
        {
            if (clientSuttaInfo == null) return;
            clientSuttaInfo!.QueryTableRec(string.Empty).Wait();
            if (clientSuttaInfo.objResult is not null)
            {
                dictSuttaInfo.Clear();
                List<SuttaInfo> list = (List<SuttaInfo>)clientSuttaInfo.objResult;
                foreach (SuttaInfo sinfo in list)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = sinfo.RowKey;
                    row.Cells[1].Value = sinfo.StartPage.ToString();
                    row.Cells[2].Value = sinfo.EndPage.ToString();
                    row.Cells[3].Value = sinfo.Pages.ToString();
                    row.Cells[4].Value = sinfo.AssignedPages.ToString();
                    row.Cells[5].Value = sinfo.PagesSubmitted.ToString();
                    row.Cells[6].Value = sinfo.PagesVerified.ToString();
                    dataGridView1.Rows.Add(row);
                    dictSuttaInfo.Add(sinfo.RowKey, sinfo);
                }
                // fill current MN Assignments
                if (dataGridView1.Rows != null && dataGridView1.Rows.Count > 1 &&
                    dataGridView1.Rows[0].Cells[0].Value != null)
                {
                    SuttaNo = dataGridView1.Rows[0].Cells[0].Value.ToString()!;
                    FillCurrentMNAssignments(SuttaNo);
                }
                // fill user profiles
                UpdateUserList();
                //if (clientTipitakaDB != null)
                //{
                //    listUserProfile = clientTipitakaDB.GetClientUserProfile().GetAllUsers();
                //    comboBox_AllUsers.Items.Clear();
                //    foreach (UserProfile userProfile in listUserProfile)
                //    {
                //        comboBox_AllUsers.Items.Add(String.Format("{0} - {1}", userProfile.RowKey, userProfile.Name_E));
                //    }
                //    button_Remove.Enabled = button_Modify.Enabled = true;
                //}
            }
        }
        public void UpdateUserList()
        {
            // fill user profiles
            if (clientTipitakaDB != null)
            {
                listUserProfile = clientTipitakaDB.GetClientUserProfile().GetAllUsers();
                comboBox_AllUsers.Items.Clear();
                foreach (UserProfile userProfile in listUserProfile)
                {
                    comboBox_AllUsers.Items.Add(String.Format("{0} - {1}", userProfile.RowKey, userProfile.Name_E));
                }
                button_Remove.Enabled = button_Modify.Enabled = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dataGridView1 != null && dataGridView1.Rows != null &&
                dataGridView1.Rows[e.RowIndex] != null && dataGridView1.Rows[e.RowIndex].Cells != null &&
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] != null &&
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                SuttaNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()!;
                groupBox2.Text = String.Format("Sutta Page Assignments : [{0}]", SuttaNo);
                // if current MN already has assignments fill dgvAssignPage
                FillCurrentMNAssignments(SuttaNo);
            };
            string value = string.Empty;
            DataGridView dgv = (DataGridView)sender;
            if (dgv != null && dgv.CurrentCell != null && dgv.CurrentCell.Value != null &&
                (e.ColumnIndex == 1 || e.ColumnIndex == 2) && comboBox_AllUsers.Text.Length > 0)
            {
                value = dgv.CurrentCell.Value.ToString()!;
                bool err = false;
                switch (e.ColumnIndex)
                {
                    case 1:
                        if (CheckPageNumberValid(value)) textBox_Start.Text = value;
                        else err = true;
                        break;
                    case 2:
                        if (CheckPageNumberValid(value)) textBox_End.Text = value;
                        else err = true;
                        break;
                }
                if (err) MessageBox.Show("Page number " + value + " is already assigned.");
            }
            comboBox_AllUsers_SelectedIndexChanged(dataGridView2, new EventArgs());
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_AllUsers.Text = "";
            if (dataGridView2.Rows != null)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                if (row != null && row.Cells[e.ColumnIndex].Value != null)
                {
                    comboBox_AllUsers.SelectedIndex = LocateUserID(row.Cells[e.ColumnIndex].Value.ToString()!);
                    comboBox_AllUsers.Text = comboBox_AllUsers.Text;
                    int[] listPgNo = ParseStartEndPages(row.Cells[1].Value.ToString()!);
                    textBox_Start.Text = listPgNo[0].ToString();
                    textBox_End.Text = listPgNo[1].ToString();
                    button_Remove.Enabled = button_Modify.Enabled = true;
                }
            }
        }
        private void FillCurrentMNAssignments(string mn)
        {
            dataGridView2.Rows.Clear();
            comboBox_AllUsers.SelectedIndex = -1;
            textBox_Start.Text = textBox_End.Text = string.Empty;
            if (clientSuttaPageAssignment == null) return;

            List<SuttaPageAssignment> pageAssignments = GetCurrentSuttaPageAssignments(); // new List<SuttaPageAssignment>();
            if (pageAssignments.Count == 0) return;

            bool dateOnly = true;
            foreach (SuttaPageAssignment pageAssignment in pageAssignments)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = pageAssignment.AssignedTo;//.RowKey.Split('-')[0];
                row.Cells[1].Value = String.Format("{0}-{1} ({2})", pageAssignment.StartPage, pageAssignment.EndPage,
                                     pageAssignment.EndPage - pageAssignment.StartPage + 1);
                //row.Cells[2].Value = pageAssignment.EndPage.ToString();
                row.Cells[2].Value = (pageAssignment.Status.Length > 0) ?
                    pageAssignment.Status[0].ToString() : string.Empty;
                row.Cells[3].Value = pageAssignment.AssignedBy;
                //DateTime dt = pageAssignment.AssignedDate;
                row.Cells[4].Value = parent.clientTipitakaDB.GetFormattedDateTimeString(((DateTime)pageAssignment.AssignedDate).ToLocalTime(), dateOnly);
                //row.Cells[4].Value = dt.ToLocalTime().ToString();
                dataGridView2.Rows.Add(row);
            }
            // fill first assigned user
            comboBox_AllUsers.SelectedIndex = LocateUserID(pageAssignments[0].AssignedTo);
            textBox_Start.Text = pageAssignments[0].StartPage.ToString();
            textBox_End.Text = pageAssignments[0].EndPage.ToString();
        }
        private List<SuttaPageAssignment> GetCurrentSuttaPageAssignments()
        {
            List<SuttaPageAssignment> pageAssignments = new List<SuttaPageAssignment>();
            if (clientSuttaPageAssignment == null) return pageAssignments;
            if (dictSuttaPageAssignment.ContainsKey(SuttaNo)) pageAssignments = dictSuttaPageAssignment[SuttaNo];
            else
            {
                //clientSuttaPageAssignment.SetSubPartitionKey(SuttaNo);
                clientSuttaPageAssignment.QuerySuttaPageAssignment(SuttaNo);
                if (clientSuttaPageAssignment.objResult != null)
                {
                    pageAssignments = (List<SuttaPageAssignment>)clientSuttaPageAssignment.objResult;
                    dictSuttaPageAssignment.Add(SuttaNo, pageAssignments);
                }
            }
            return pageAssignments;
        }
        // Find userID in the combo list
        private int LocateUserID(string userID)
        {
            int index = -1;
            string[] f = userID.Split('-');
            foreach (var item in comboBox_AllUsers.Items)
            {
                index++;
                if (item.ToString()!.Contains(f[0]))
                {
                    return index;
                }
            }
            return -1;
        }
        private int[] ParseStartEndPages(string value)
        {
            int[] ints = new int[2];
            List<int> list = new List<int>();
            string[] f = value!.Split('-');
            if (f != null && f.Length > 0)
            {
                ints[0] = Convert.ToInt16(f[0]);
                list.Add(Convert.ToInt16(f[0]));
                string[] ff = f[1].Split(" ");
                if (ff != null && ff.Length > 0) ints[1] = Convert.ToInt16(ff[0]);
            }
            return ints;
        }
        private bool CheckPageNumberValid(string value)
        {
            if (dataGridView2.Rows.Count <= 1) return true; // can use the data
            int val = Convert.ToInt16(value);
            int n1, n2;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                n1 = n2 = -1;
                if (row.Cells[1].Value != null)
                {
                    int[] list = ParseStartEndPages(row.Cells[1].Value.ToString()!);
                    n1 = list[0]; n2 = list[1];
                    if (val >= n1 && val <= n2) return false;
                }
            }
            return true;
        }
        private void button_Assign_Click(object sender, EventArgs e)
        {
            // validate page numbers
            if (!ValidatePageNumbersWithErrorMsg(SuttaNo)) return;
            int rowIndex1 = dataGridView1.SelectedCells[0].RowIndex;

            string userID = comboBox_AllUsers.Text.Substring(0, comboBox_AllUsers.Text.IndexOf(" - "));
            string assignedBy = string.Empty;
            if (clientTipitakaDBLogin != null)
            {
                assignedBy = (clientTipitakaDBLogin.loggedinUser != null) ?
                                clientTipitakaDBLogin.loggedinUser.RowKey : String.Empty;
            }
            DateTime dt = DateTime.Now;
            DateTime dtUTC= dt.ToUniversalTime();
            DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            row.Cells[0].Value = userID;
            row.Cells[1].Value = String.Format("{0}-{1} ({2})", textBox_Start.Text, textBox_End.Text,
                    Convert.ToInt16(textBox_End.Text) - Convert.ToInt16(textBox_Start.Text) + 1);
            row.Cells[2].Value = "A"; // Assigned;
            row.Cells[3].Value = assignedBy;
            row.Cells[4].Value = dt;
            dataGridView2.Rows.Add(row);

            // Add to SuttaPageAssignment
            SuttaPageAssignment suttaPageAssignment;
            if (clientSuttaPageAssignment != null)
            {
                int startPage = Convert.ToInt16(textBox_Start.Text);
                int endPage = Convert.ToInt16(textBox_End.Text);
                int nPages = endPage - startPage + 1;
                suttaPageAssignment = new SuttaPageAssignment()
                {
                    PartitionKey = "SuttaPageAssignment",
                    RowKey = String.Format("{0}-{1}-{2}", SuttaNo, startPage.ToString("D3"), endPage.ToString("D3")),
                    StartPage = startPage,
                    EndPage = endPage,
                    Status = "Assigned",
                    AssignedTo = userID,
                    AssignedBy = assignedBy,
                    AssignedDate = dtUTC
                };
                clientSuttaPageAssignment.AddSuttaPageAssignment(suttaPageAssignment);
                if (clientSuttaPageAssignment.StatusCode == 204)
                {
                    // successfully added to SuttaPageAssignment
                    this.Cursor = Cursors.WaitCursor;
                    // save the current SuttaPageAssignment in dictionary
                    if (dictSuttaPageAssignment.ContainsKey(SuttaNo))
                    {
                        // add to the current list
                        dictSuttaPageAssignment[SuttaNo].Add(suttaPageAssignment);
                    }
                    else
                    {
                        List<SuttaPageAssignment> list = new List<SuttaPageAssignment>();
                        list.Add(suttaPageAssignment);
                        dictSuttaPageAssignment.Add(SuttaNo, list);
                    }
                    // update UserPageActivity
                    nPages = UpdateUserPageActivity(userID, startPage, endPage, 0, 0);
                    // update SuttaInfo
                    AdjustAssignedPagesInSuttaInfo(userID, nPages, (startPage == 0) && (endPage == 0));
                    // display message
                    this.Cursor = Cursors.Default;
                    TipitakaDB.AutoClosingMessageBox.Show("User work assignment added.", "Work Assignment", 1000);
                    //MessageBox.Show("User work assignment added.");
                    this.Cursor = Cursors.WaitCursor;
                    // do activity message && email
                    if (clientTipitakaDB != null)
                    {
                        clientTipitakaDB.MessageCenter(clientTipitakaDB, "assigned", parent.GetAdmins(), userID,
                            SuttaNo, startPage, endPage, nPages);
                    }
                    this.Cursor = Cursors.Default;

                    // update SuttaInfo
                    parent.form_SuttaInfo!.LoadInitialData();
                    //if (clientSuttaInfo != null)
                    //{
                    //    SuttaInfo suttaInfo = parent.form_SuttaInfo!.GetSuttaInfo(rowIndex1);
                    //    if (suttaInfo != null)
                    //    {
                    //        if (suttaInfo.AssignedUsers.Length > 0) suttaInfo.AssignedUsers += ",";
                    //        suttaInfo.AssignedUsers += userID;
                    //        suttaInfo.AssignedPages = nPages; // pages added
                    //        parent.form_SuttaInfo!.LoadInitialData();
                    //    }
                    //}
                }
                else MessageBox.Show("Adding user assignment into Tipitaka database failed.");
                button_Assign.Enabled = false;
                button_Modify.Enabled = button_Remove.Enabled = true;
            }
        }
        private void button_Modify_Click(object sender, EventArgs e)
        {
            //string userID;
            //int startPage, endPage, nPages;

            if (dataGridView2.CurrentCell == null)
            {
                MessageBox.Show("No assigned task selected.");
                return;
            }
            // validate page numbers
            if (!ValidatePageNumbersWithErrorMsg(SuttaNo, true)) return;

            if (dataGridView2.Rows != null && dataGridView2.Rows.Count > 0
                && dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Cells != null)
            {
                // check if the pages have changed
                string pages = dataGridView2.CurrentRow.Cells[1].Value.ToString()!;
                int[] pgs = ParseStartEndPages(pages);
                if (pgs[0] == Convert.ToInt16(textBox_Start.Text) && pgs[1] == Convert.ToInt16(textBox_End.Text))
                {
                    MessageBox.Show("No pages to modify."); return;
                }
                int nPages = pgs[1] - pgs[0] + 1;
                string userID = dataGridView2.CurrentRow.Cells[0].Value.ToString()!;
                DialogResult result = MessageBox.Show(userID + " page assignment will be modified. Confirm Yes/No?", "Confirm",
                MessageBoxButtons.YesNo);
                if (result.Equals(DialogResult.No)) return;
                List<SuttaPageAssignment> suttaPageAssignments = dictSuttaPageAssignment[SuttaNo];
                //if (key != null && key.Length > 0 && suttaPageAssignments.IndexOf(key))
                //{
                this.Cursor = Cursors.WaitCursor;
                int newStart, newEnd, oldStart, oldEnd;
                string key = SuttaNo + "-" + pgs[0].ToString("D3") + "-" + pgs[1].ToString("D3");    
                foreach (SuttaPageAssignment suttaPageAssignment in suttaPageAssignments)
                {
                    if (suttaPageAssignment.RowKey == key)
                    {

                        oldStart = suttaPageAssignment.StartPage; oldEnd = suttaPageAssignment.EndPage;
                        suttaPageAssignment.StartPage = Convert.ToInt16(textBox_Start.Text);
                        suttaPageAssignment.EndPage = Convert.ToInt16(textBox_End.Text);
                        nPages = suttaPageAssignment.EndPage - suttaPageAssignment.StartPage + 1;
                        newStart = suttaPageAssignment.StartPage; newEnd = suttaPageAssignment.EndPage;
                        dataGridView2.CurrentRow.Cells[1].Value = String.Format("{0}-{1} ({2})", textBox_Start.Text, textBox_End.Text, nPages);
                        if (clientSuttaPageAssignment != null)
                        {
                            clientSuttaPageAssignment.DeleteSuttaPageAssignment(suttaPageAssignment);
                            suttaPageAssignment.RowKey = String.Format("{0}-{1}-{2}", SuttaNo, textBox_Start.Text.PadLeft(3, '0'),
                                textBox_End.Text.PadLeft(3, '0'));
                            clientSuttaPageAssignment.AddSuttaPageAssignment(suttaPageAssignment);
                            if (clientSuttaPageAssignment.StatusCode != 204)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("DBError in modifying user page assignment."); return;
                            }
                            else
                            {
                                //int n = AddUserActivityPaagesInSuttaInfo(n);
                                //UpdateUserPageActivity(key, newStart, newEnd, oldStart, oldEnd);
                                nPages = UpdateUserPageActivity(userID, newStart, newEnd, oldStart, oldEnd);
                                // update SuttaInfo
                                AdjustAssignedPagesInSuttaInfo(userID, nPages, (newStart == 0) && (newEnd == 0));
                                this.Cursor = Cursors.Default;
                                TipitakaDB.AutoClosingMessageBox.Show("User work assignment modified.", "Work Modification", 1000);
                                //MessageBox.Show("User work assignment added.");
                                this.Cursor = Cursors.WaitCursor;
                                //MessageBox.Show("User page assignment modified.");
                            }
                        }
                        break;
                    }
                }
                // update SuttaInfo
                parent.form_SuttaInfo!.LoadInitialData();
                this.Cursor = Cursors.WaitCursor;
                // do activity message && email
                if (clientTipitakaDB != null)
                {
                    clientTipitakaDB.MessageCenter(clientTipitakaDB, "modified", parent.GetAdmins(), userID,
                        SuttaNo, pgs[0], pgs[1], nPages);
                }
                this.Cursor = Cursors.Default;

                //int n = AddUserActivityPaagesInSuttaInfo(n);
                //UpdateUserPageActivity(key, newStart, newEnd, oldStart, oldEnd);
                //this.Cursor = Cursors.Default;
                //MessageBox.Show("User page assignment modified.");
                // do activity message && email
                //if (clientActivityLog != null && clientTipitakaDBLogin != null && clientTipitakaDBLogin.loggedinUser != null)
                //{
                //    string activity = String.Format("{0}: {1} pages {2]-{3} assignment removed.", userID, SuttaNo, startPage, endPage, nPages);
                //    clientActivityLog.AddActivityLog(clientTipitakaDBLogin.loggedinUser.RowKey, activity);
                //}
                //// email
                //List<string> admins = parent.GetAdmins();
                //string subject = "Page assignments.";
                //string ccEmail = string.Empty;
                //string body = String.Format("Subject : {0}", subject);
                //body += String.Format("||UserID : {0}", userID);
                //body += String.Format("|Sutta # : {0}", SuttaNo);
                //body += String.Format("|Pages : {0}-{1} ({2})", endPage, startPage, nPages);
                //if (clientTipitakaDBLogin != null && clientTipitakaDBLogin.loggedinUser != null)
                //    body += String.Format("|Issued by : {0})", clientTipitakaDBLogin.loggedinUser.RowKey);
                //if (clientTipitakaDB != null)
                //    clientTipitakaDB.SendViaMailTrapSMTP(userID, string.Empty, String.Join(',', admins), subject, body);
                //}
                //}
            }

        }
        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null)
            {
                MessageBox.Show("No assigned task selected.");
                return;
            }
            List<SuttaPageAssignment> suttaPageAssignments = new List<SuttaPageAssignment>();
            // check if the user has already submiited assigned pages
            string userID = string.Empty;
            if (dataGridView2 != null && dataGridView2.CurrentRow != null && 
                dataGridView2.CurrentRow.Cells != null && dataGridView2.CurrentRow.Cells[0].Value != null)
            {
                userID = dataGridView2.CurrentRow.Cells[0].Value.ToString()!;
            }
            if (clientSuttaPageAssignment != null)
            {
                string rowKey = String.Format("{0}-{1}-{2}", SuttaNo, textBox_Start.Text.PadLeft(3, '0'),
                    textBox_End.Text.PadLeft(3, '0'));
                SuttaPageAssignment? suttaPageAssignment = clientSuttaPageAssignment.GetSuttaPageAssignment(rowKey);
                if (suttaPageAssignment == null)
                {
                    MessageBox.Show("Err: " + rowKey + " suttaPageAssignment not found");
                    return;
                }

                if (suttaPageAssignment.Status != "Assigned")
                {
                    MessageBox.Show(userID + " already has started working on the pages. Page assignments cannot be removed anymore.");
                    return;
                }
            }

            // remove the assigned task
            if (dataGridView2!.Rows != null && dataGridView2.Rows.Count > 0
                && dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Cells != null && suttaPageAssignments.Count > 0)
            {
                int oldStart = Convert.ToInt16(textBox_Start.Text);
                int oldEnd = Convert.ToInt16(textBox_End.Text);
                int nPages = oldEnd - oldStart + 1;
                DialogResult res = MessageBox.Show(String.Format("{0} {1}-page assignment will be removed. Confirm Yes/No?", userID, nPages), "Confirm",
                MessageBoxButtons.YesNo);
                if (res.Equals(DialogResult.No)) return;
                if (userID != null && userID.Length > 0 && dictSuttaPageAssignment.ContainsKey(SuttaNo))
                {
                    var suttaPageAssignment = from item in suttaPageAssignments
                                              where item.RowKey.Contains(userID)
                                              select item;
                    List<SuttaPageAssignment> list = (List<SuttaPageAssignment>)dictSuttaPageAssignment[SuttaNo];
                    foreach(SuttaPageAssignment item in list) 
                    {
                        if (item.RowKey.Split('-')[0] == userID && oldStart == item.StartPage && oldEnd == item.EndPage)
                        {
                            parent.Cursor = Cursors.WaitCursor;
                            clientSuttaPageAssignment!.DeleteTableRec(item).Wait();
                            if (clientSuttaPageAssignment.StatusCode != 204)
                            {
                                parent.Cursor = Cursors.Default;
                                MessageBox.Show("DBError in removing user page assignment.");
                                return;
                            }
                            else
                            {
                                // update UserPageActivity
                                nPages = UpdateUserPageActivity(userID, 0, 0, oldStart, oldEnd);
                                // update SuttaInfo
                                AdjustAssignedPagesInSuttaInfo(userID, nPages, true);
                                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                                dictSuttaPageAssignment.Remove(userID);
                            }
                        }
                    }
                    parent.Cursor = Cursors.Default;
                    TipitakaDB.AutoClosingMessageBox.Show("User work assignment removed.", "Work Removal", 1000);
                    // do activity message && email
                    this.Cursor = Cursors.WaitCursor;
                    // do activity message && email
                    if (clientTipitakaDB != null)
                    {
                        clientTipitakaDB.MessageCenter(clientTipitakaDB, "removed", parent.GetAdmins(), userID,
                            SuttaNo, oldStart, oldEnd, nPages);
                    }
                    this.Cursor = Cursors.Default;
                    // update SuttaInfo
                    parent.form_SuttaInfo!.LoadInitialData();
                    button_Assign.Enabled = button_Modify.Enabled = button_Remove.Enabled = false;
                    parent.form_UserActivities!.AllClear();
                }
            }
        }
        private void AdjustAssignedPagesInSuttaInfo(string userID, int nPages, bool flagUserRemove = false)
        {
            if (nPages == 0) return;
            // update SuttaInfo
            var row = dataGridView1.CurrentRow;
            int pages = Convert.ToInt16(row.Cells[4].Value) + nPages;
            row.Cells[4].Value = pages.ToString();
            if (!dictSuttaInfo.ContainsKey(SuttaNo)) return;
            SuttaInfo suttaInfo = dictSuttaInfo[SuttaNo];
            //suttaInfo.AssignedPages = pages;
            if (flagUserRemove)
            {
                string pattern = String.Format("{0}|,{0}", userID);
                Match match = Regex.Match(suttaInfo.AssignedUsers, pattern);
                if (match.Success)
                {
                    suttaInfo.AssignedUsers = suttaInfo.AssignedUsers.Replace(match.Value, string.Empty);
                    suttaInfo.AssignedPages = pages;
                }
            }
            else
            {
                suttaInfo.AssignedPages = pages;
                if (suttaInfo.AssignedUsers == null) suttaInfo.AssignedUsers = string.Empty;
                if (!suttaInfo.AssignedUsers.Contains(userID))
                {
                    if (suttaInfo.AssignedUsers.Length > 0) suttaInfo.AssignedUsers += ",";
                    suttaInfo.AssignedUsers += userID;
                }
                dictSuttaInfo[SuttaNo] = suttaInfo;
            }
            if (clientSuttaInfo!= null)
            {
                clientSuttaInfo.UpdateSuttaInfo(suttaInfo);
                if (clientSuttaInfo.StatusCode != 204)
                    MessageBox.Show("AddUserActivityPages update error.");
            }
        }
        private int UpdateUserPageActivity(string userID, int newStart, int newEnd, int oldStart, int oldEnd)
        {
            int n = 0;
            DateTime dtUTC = DateTime.Now.ToUniversalTime();
            // added pages
            UserPageActivity userPageActivity = new UserPageActivity()
            {
                PartitionKey = "UserPageActivity",
                AssignedTo = userID,
                AssignedDate = dtUTC,
                Status = "Assigned",
                NIS = 0,
                TimeSpent = 0F,
                StartDate = dtUTC,
                TurnAroundTime = 0,
            };
            for (int page = newStart; page > 0 && page <= newEnd; page++)
            {
                if ((page < oldStart || page > oldEnd) && clientUserPageActivity != null)
                {
                    // remove UserPageActivity
                    string rowKey = string.Format("{0}-{1}", SuttaNo, page.ToString("D3"));
                    userPageActivity.RowKey = rowKey;
                    clientUserPageActivity.AddUserPageActivity(userPageActivity);
                    if (clientUserPageActivity.StatusCode != 204)
                    { MessageBox.Show("Error inserting UserPageActivity"); }
                    ++n;
                }
            }

            // pages that are removed
            for (int page = oldStart; page > 0 && page <= oldEnd; page++)
            {
                if ((page < newStart || page > newEnd) && clientUserPageActivity != null)
                {
                    // remove UserPageActivity
                    string rowKey = string.Format("{0}-{1}", SuttaNo, page.ToString("D3"));
                    clientUserPageActivity.RemoveUserPageActivity(rowKey);
                    --n;
                }
            }
            return n;
        }
        private bool ValidatePageNumbersWithErrorMsg(string MNNo, bool flagModify = false)
        {
            bool flag = false;
            int res = ValidatePageNumbers(MNNo, flagModify);
            switch (res)
            {
                case 1:
                    MessageBox.Show("Page assignment out of range.");
                    break;
                case 2:
                    MessageBox.Show("Page(s) already assigned.");
                    break;
                case 3:
                    MessageBox.Show("End page must be greater than start page.");
                    break;
                default: flag = true; break;
            }
            return flag;
        }
        private int ValidatePageNumbers(string MNNo, bool flagModify = false)
        {
            SuttaInfo suttaInfo;
            int page1, page2;
            int pageAssigned1 = Convert.ToInt16(textBox_Start.Text);
            int pageAssigned2 = Convert.ToInt16(textBox_End.Text);
            if (pageAssigned2 < pageAssigned1) return 3;
            if (dictSuttaInfo != null && dictSuttaInfo.ContainsKey(MNNo))
            {
                suttaInfo = dictSuttaInfo[MNNo];
                page1 = Convert.ToInt16(suttaInfo.StartPage);
                page2 = Convert.ToInt16(suttaInfo.EndPage);
                if (pageAssigned1 < page1 || pageAssigned1 > page2 ||
                    pageAssigned2 < page1 || pageAssigned2 > page2) return 1;
            }
            if (!flagModify && (!CheckPageNumberValid(textBox_Start.Text) ||
                !CheckPageNumberValid(textBox_End.Text))) return 2;
            return 0;
        }
        private void comboBox_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (dataGridView2.CurrentRow != null && comboBox_AllUsers.Text.Length > 0 &&
                textBox_Start.Text.Length > 0 && textBox_End.Text.Length > 0)
            {
                int[] pgs = ParseStartEndPages(dataGridView2.CurrentRow.Cells[1].Value.ToString()!);
                string userID = comboBox_AllUsers.Text.Split(" - ")[0];
                flag = dataGridView2.CurrentRow.Cells[0].Value.ToString() == userID &&
                    pgs[0] == Convert.ToInt16(textBox_Start.Text) && pgs[1] == Convert.ToInt16(textBox_End.Text);
                if (!flag) textBox_Start.Text = textBox_End.Text = string.Empty;
            }
            button_Modify.Enabled = button_Remove.Enabled = flag;
        }
    }
}
