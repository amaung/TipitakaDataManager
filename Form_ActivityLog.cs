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
    public partial class Form_ActivityLog : Form
    {
        Form1 parent;
        ClientActivityLog? clientActivityLog;
        ClientTipitakaDB? clientTipitakaDB;
        public Form_ActivityLog(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            InitDataGridView();
            clientActivityLog = parent.clientTipitakaDB.GetClientActivityLog();
            clientTipitakaDB = parent.clientTipitakaDB;
            checkBox_All.Checked = false;
            dateTimePicker_Start.Enabled = dateTimePicker_End.Enabled = !checkBox_All.Checked;
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowTemplate.Height = 30;
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
            dataGridView1.Columns[2].HeaderText = "Activity";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 162;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.MultiSelect = false;
            //dataGridView1.CellClick += dataGridView_CellClick!;
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if (clientActivityLog!= null)
            {
                if (checkBox_All.Checked) clientActivityLog.GetActivities(comboBox_Users.Text);
                else clientActivityLog.GetActivities(comboBox_Users.Text, dateTimePicker_Start.Value, dateTimePicker_End.Value);
                if (clientActivityLog.StatusCode== 204)
                {
                    List<string> list = (List<string>)clientActivityLog.objResult;
                    dataGridView1.Rows.Clear();
                    foreach (var item in list)
                    {
                        string[] f = item.Split('|');
                        if (f.Length == 3)
                        {
                            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                            row.Cells[0].Value = f[0];
                            row.Cells[1].Value = f[1];
                            row.Cells[2].Value = f[2];
                            dataGridView1.Rows.Add(row);
                        }
                    }
                    label_ActivityCount.Text = String.Format("{0}", list.Count);
                }
            }
        }
        public void LoadInitialData()
        {
            List<UserProfile>? listUserProfile = parent.GetAllUserProfiles();
            if (listUserProfile == null) return;
            comboBox_Users.Items.Clear();
            foreach (UserProfile userProfile in listUserProfile)
            {
                if (userProfile != null)
                {
                    comboBox_Users.Items.Add(userProfile.RowKey);
                }
            }
        }
        private void checkBox_All_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_Start.Enabled = dateTimePicker_End.Enabled = !checkBox_All.Checked;
        }
    }
}
