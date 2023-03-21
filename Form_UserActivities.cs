using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tipitaka_DB;
using Tipitaka_DBTables;

namespace TipitakaDataManager
{
    public partial class Form_UserActivities : Form
    {
        Form1 parent;
        ClientUserPageActivity? clientUserPageActivity;
        public Form_UserActivities(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            clientUserPageActivity = parent.clientTipitakaDB.GetClientUserPageActivity();
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowHeadersWidth = dataGridView1.Width / 2;
            //dataGridView1.RowHeadersWidth = dataGridView1.Width / 3;
            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows.
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.Columns[0].HeaderText = "Sutta-Page";
            dataGridView1.Columns[1].HeaderText = "Status";
            dataGridView1.Columns[2].HeaderText = "NIS";
            dataGridView1.Columns[3].HeaderText = "Hrs";
            dataGridView1.Columns[4].HeaderText = "Days";
            dataGridView1.Columns[5].HeaderText = "Started";
            dataGridView1.Columns[6].HeaderText = "Assigned";
            dataGridView1.Columns[0].Width = 100; // dataGridView1.Columns[1].Width = dataGridView1.Width / 5 - 2;
            dataGridView1.Columns[0].Width = 100; // dataGridView1.Columns[1].Width = dataGridView1.Width / 5 - 2;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.MultiSelect = false;
            //dataGridView1.CellClick += dataGridView_CellClick!;
            //dataGridView1.Rows[0].Cells[0].Value = "MN-152-049";
            //dataGridView1.Rows[0].Cells[1].Value = "In progress";
            //dataGridView1.Rows[0].Cells[2].Value = "49";
            //dataGridView1.Rows[0].Cells[3].Value = "2.5";
            //dataGridView1.Rows[0].Cells[4].Value = "3";
            //dataGridView1.Rows[0].Cells[5].Value = "2023-02-04";
            //dataGridView1.Rows[0].Cells[6].Value = "2023-01-05";
        }

        public void LoadInitialData()
        {
            if (parent != null)
            {
                List<UserProfile>? list = parent.GetAllUserProfiles();
                comboBox_AllUsers.Items.Clear();
                if (list != null)
                {
                    foreach(UserProfile profile in list)
                    {
                        if (profile != null)
                        {
                            comboBox_AllUsers.Items.Add(profile.RowKey);
                        }
                    }
                }
            }
        }
        public void AllClear()
        {
            dataGridView1.Rows.Clear();
            comboBox_AllUsers.Text = string.Empty;
            comboBox_AllUsers.SelectedIndex = -1;
            textBox_Total.Text = textBox_Downloaded.Text = textBox_Submitted.Text = textBox_SubmittedPercent.Text = String.Empty;
            textBox_Assigned.Text = textBox_Updated.Text = textBox_Verified.Text = textBox_VerifiedPercent.Text = String.Empty;
        }
        private void comboBox_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FillDataGridView(List<UserPageActivity> users)
        {
            dataGridView1.Rows.Clear();
            if (users != null && users.Count> 0)
            {
                bool dateOnly = true;
                foreach (var user in users)
                {
                    if (user == null) continue;
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = user.RowKey;
                    row.Cells[1].Value = user.Status;
                    row.Cells[2].Value = user.NIS.ToString();
                    row.Cells[3].Value = user.TimeSpent.ToString();
                    row.Cells[4].Value = user.TurnAroundTime.ToString();
                    row.Cells[5].Value = user.StartDate;
                    row.Cells[6].Value = parent.clientTipitakaDB.GetFormattedDateTimeString(((DateTime)user.AssignedDate).ToLocalTime(), dateOnly);
                    //if (user.Timestamp != null) row.Cells[3].Value = parent.clientTipitakaDB.GetFormattedDateTimeString(((DateTimeOffset)user.Timestamp).DateTime.ToLocalTime(), dateOnly);
                    //row.Cells[4].Value = user.AssignedDate;
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if (clientUserPageActivity != null && comboBox_AllUsers.SelectedIndex != -1)
            {
                clientUserPageActivity.QueryUserPageActivity(comboBox_AllUsers.Text);
                if (clientUserPageActivity.StatusCode == 0 || clientUserPageActivity.StatusCode == 204)
                {
                    int nAssigned, nSubmitted, nUpdated, nVerified, nCount;
                    nAssigned = nSubmitted = nUpdated = nVerified = nCount = 0;
                    List<UserPageActivity> users = (List<UserPageActivity>)clientUserPageActivity.objResult;
                    if (users != null && users.Count > 0)
                    {
                        nAssigned = users.Count(n => n.Status == "Assigned");
                        nSubmitted = users.Count(n => n.Status == "Submitted");
                        nUpdated = users.Count(n => n.Status == "Updated");
                        nVerified = users.Count(n => n.Status == "Verified");
                        nCount = users.Count;
                    }
                    textBox_Total.Text = nCount.ToString();
                    textBox_Assigned.Text = nAssigned.ToString();
                    textBox_Downloaded.Text = (nSubmitted + nUpdated).ToString();
                    textBox_Submitted.Text = nSubmitted.ToString();
                    textBox_Verified.Text = nVerified.ToString();
                    textBox_Updated.Text = nUpdated.ToString();
                    if (users != null && nCount > 0)
                    {
                        textBox_SubmittedPercent.Text = String.Format("{0}%", ((int)((nSubmitted + nUpdated + nVerified) / nCount)));
                        textBox_VerifiedPercent.Text = String.Format("{0}%", ((int)((nVerified) / nCount)));
                        FillDataGridView(users);
                    }
                }
                else MessageBox.Show("UserPageActivity return code = " + clientUserPageActivity.StatusCode.ToString());
            }

        }
    }
}
