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
    public partial class Form_MessageLog : Form
    {
        Form1 parent;
        ClientTipitakaDB clientTipitakaDB;
        ClientMessageLog clientMessageLog;
        ClientUserProfile clientUserProfile;
        List<MessageLog>? listMessageLog;
        public Form_MessageLog(Form1 parent)
        {
            InitializeComponent();
            checkBox_All.Checked = false;
            dateTimePicker_Start.Enabled = dateTimePicker_End.Enabled = !checkBox_All.Checked;
            this.parent = parent;
            label_Type.Text = "Type : "; label_Seen.Text = "Seen : ";
            clientTipitakaDB= parent.clientTipitakaDB as ClientTipitakaDB;
            clientMessageLog = parent.clientMessageLog as ClientMessageLog;
            clientUserProfile = parent.clientUserProfile as ClientUserProfile;
            listMessageLog = null;
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowHeadersWidth = dataGridView1.Width/2;
            //dataGridView1.RowHeadersWidth = dataGridView1.Width / 3;
            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows.
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.Columns[0].HeaderText = "DateTime";
            dataGridView1.Columns[1].HeaderText = "User ID";
            dataGridView1.Columns[0].Width = dataGridView1.Columns[1].Width = dataGridView1.Width / 2 - 2;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += dataGridView_CellClick!;
        }
        public void LoadInitialData()
        {
            List<UserProfile>? listUserProfile = parent.GetAllUserProfiles();
            if (listUserProfile == null) return;
            comboBox_Users.Items.Clear();
            foreach(UserProfile userProfile in listUserProfile)
            {
                if (userProfile != null)
                {
                    comboBox_Users.Items.Add(userProfile.RowKey);
                }
            }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1 && listMessageLog != null)
            {
                FillMessageDetails(e.RowIndex);
            }
        }
        private void checkBox_All_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_Start.Enabled = dateTimePicker_End.Enabled = !checkBox_All.Checked;
        }
        private void button_Find_Click(object sender, EventArgs e)
        {
            if (checkBox_All.Checked) { listMessageLog = clientMessageLog.GetMessages(comboBox_Users.Text); }
            else listMessageLog = clientMessageLog.GetMessages(comboBox_Users.Text, false, dateTimePicker_Start.Value, dateTimePicker_End.Value);
            dataGridView1.Rows.Clear();
            foreach(MessageLog messageLog in listMessageLog)
            {
                if (messageLog != null && messageLog.RowKey != null)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = messageLog.RowKey;
                    UserProfile? userProfile = parent.GetUserProfile(messageLog.From);
                    row.Cells[1].Value = (userProfile != null && userProfile.UserClass != "A")
                                        ? row.Cells[1].Value = messageLog.From : row.Cells[1].Value = messageLog.To;
                    dataGridView1.Rows.Add(row);
                }
            }
            if (dataGridView1.CurrentRow != null)
            {
                FillMessageDetails(dataGridView1.CurrentRow.Index);
            }
        }
        private void FillMessageDetails(int rowIndex)
        {
            if (listMessageLog != null && listMessageLog.Count> rowIndex && rowIndex >= 0) 
            {
                MessageLog messageLog = listMessageLog[rowIndex];
                textBox_DateTime.Text = clientTipitakaDB.GetLocalTime(messageLog.RowKey); // GetLocalTime
                textBox_From.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBox_Message.Text = string.Empty;
                string[] f = messageLog.Body.Split('|');
                foreach(string f2 in f) { textBox_Message.Text += f2 + "\r\n"; }
                textBox_Type.Text = (messageLog.MsgType == "modified" || messageLog.MsgType == "assigned") ? "Action required" : "Notification";
                textBox_Seen.Text = (messageLog.Read) ? "Yes" : "No";
            }
        }
    }
}
