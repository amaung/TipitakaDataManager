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
    public partial class Form_UpdateHistory : Form
    {
        Form1 parent;
        ClientUpdateHistory? clientUpdateHistory;
        Dictionary<string, List<UpdateHistory>> dictUpdateHistory = new Dictionary<string, List<UpdateHistory>>();
        List<string> selectedUserIDs = new List<string>();
        public Form_UpdateHistory(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            clientUpdateHistory = parent.clientTipitakaDB.GetClientUpdateHistory();
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 4;
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
            dataGridView1.Columns[0].HeaderText = "Sutta";
            dataGridView1.Columns[1].HeaderText = "Pg-Rec";
            dataGridView1.Columns[2].HeaderText = "Updated";
            dataGridView1.Columns[3].HeaderText = "Text";
            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 650;
            //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[3].Width = dataGridView1.Columns[4].Width = 135;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.MultiSelect = false;
            //dataGridView1.CellClick += dataGridView_CellClick!;
        }
        public void LoadInitialData()
        {
        }
        public void LoadInitialData1() // temporary disabled
        {
            comboBox_Suttas.Items.Clear();
            if (clientUpdateHistory == null) return;
            UpdateHistory updateHistory = clientUpdateHistory.GetUpdateHistory("UpdatedSuttaNo");
            if (updateHistory.Data == null) return;
            string[] updatedSuttas = updateHistory.Data.Split(",");
            Array.Sort(updatedSuttas);
            if (parent != null && clientUpdateHistory != null)
            {
                updateHistory = clientUpdateHistory.GetUpdateHistory("UpdatedSuttaNo");
                if (clientUpdateHistory.StatusCode != 404)
                {
                    // there is some UpdateHistory
                    string[] updatedHistory = updateHistory.Data.Split(',');
                    foreach (string s in updatedHistory) comboBox_Suttas.Items.Add("MN-" + s);
                }
                else
                {
                    comboBox_Suttas.Items.Add("<empty>");
                }
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = "MN-152";
                row.Cells[1].Value = "P625-R52";
                row.Cells[2].Value = "2022-12-22";
                row.Cells[3].Value = "*ဇီဝိတံ ^အသက်ကို";
                dataGridView1.Rows.Add(row);
            }
        }
        private List<UpdateHistory> SuttaUpdateHistory(string suttaNo)
        {
            List<UpdateHistory> listUpdateHistory = new List<UpdateHistory>();
            if (dictUpdateHistory == null) return listUpdateHistory;
            if (!dictUpdateHistory.ContainsKey(suttaNo))
            {
                listUpdateHistory = GetSuttaUpdateHistory(suttaNo);
                dictUpdateHistory.Add(suttaNo, listUpdateHistory);
            }
            else listUpdateHistory = dictUpdateHistory[suttaNo];
            return listUpdateHistory;
        }
        public List<UpdateHistory> GetSuttaUpdateHistory(string suttaNo)
        {
            string suttaNum = suttaNo;
            if (suttaNo.IndexOf("MN-") == 0) suttaNum = suttaNo.Substring(3);
            int suttaNo1 = Convert.ToInt32(suttaNum);
            int suttaNo2 = suttaNo1 + 1;
            List<UpdateHistory> result = new List<UpdateHistory>();
            string filter = String.Format("RowKey ge 'MN-{0}' and RowKey lt 'MN-{1}'", suttaNo1.ToString("D3"),
                suttaNo2.ToString("D3"));
            if (clientUpdateHistory== null) return result;
            clientUpdateHistory.QueryUpdateHistory(filter);
            if (clientUpdateHistory.StatusCode == 200)
            {
                List<UpdateHistory> updateHistory = (List<UpdateHistory>)clientUpdateHistory.objResult;
                result = updateHistory.OrderByDescending(x => x.RowKey).ToList();
            }
            return result;
        }
        private void button_Find_Click(object sender, EventArgs e)
        {
            if (comboBox_Suttas.Text.Length == 0) { MessageBox.Show("Sutta no. not selected."); return; }
            if (clientUpdateHistory == null) return;
            string suttaNo, pageNo, nisRec;
            comboBox_Pages.Items.Clear();
            selectedUserIDs.Clear();
            dataGridView1.Rows.Clear();
            List<UpdateHistory> listUpdateHistory = SuttaUpdateHistory(comboBox_Suttas.Text);
            foreach(UpdateHistory updateHistory in listUpdateHistory)
            {
                if (updateHistory == null) continue;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                GetSuttaInfo(updateHistory, out suttaNo, out pageNo, out nisRec);
                row.Cells[0].Value = suttaNo;
                row.Cells[1].Value = String.Format("{0}-{1}", pageNo, nisRec);
                row.Cells[2].Value = UpdatedDate(updateHistory.RowKey);
                row.Cells[3].Value = updateHistory.Data;
                dataGridView1.Rows.Add(row);
                selectedUserIDs.Add(updateHistory.UserID);
                if (!comboBox_Pages.Items.Contains(pageNo)) comboBox_Pages.Items.Add(pageNo);
            }
            textBox_UserID.Text = selectedUserIDs[0]; // first record
        }
        private void FillDataGridView(List<UpdateHistory> listUpdateHistory)
        {
            string suttaNo, pageNo, nisRec;
            dataGridView1.Rows.Clear();
            selectedUserIDs.Clear();
            foreach (UpdateHistory updateHistory in listUpdateHistory)
            {
                if (updateHistory == null) continue;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                GetSuttaInfo(updateHistory, out suttaNo, out pageNo, out nisRec);
                row.Cells[0].Value = suttaNo;
                row.Cells[1].Value = String.Format("{0}-{1}", pageNo, nisRec);
                row.Cells[2].Value = UpdatedDate(updateHistory.RowKey);
                row.Cells[3].Value = updateHistory.Data;
                dataGridView1.Rows.Add(row);
                selectedUserIDs.Add(updateHistory.UserID);
            }
            textBox_UserID.Text = selectedUserIDs[0]; // first record
        }
        private void GetSuttaInfo(UpdateHistory updateHistory, out string suttaNo, out string pageNo, out string nisRec)
        {
            suttaNo = pageNo = nisRec = string.Empty;
            if (updateHistory == null) return;
            string[] f = updateHistory.RowKey.Split('-');
            if (f.Length >= 3 )
            {
                suttaNo = f[0] + "-" + f[1];
                pageNo = f[2];
                nisRec= f[3].Split(':')[0];
            }
        }
        private string UpdatedDate(string dateTime)
        {
            string s = string.Empty;
            string[] f = dateTime.Split(":");
            if (f.Length >= 2 ) 
            {
                s = String.Format("{0}-{1}-{2}", f[1].Substring(0, 4), f[1].Substring(4, 2), f[1].Substring(6, 2));
            }
            return s;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (selectedUserIDs.Count > e.RowIndex)
            {
                textBox_UserID.Text = selectedUserIDs[e.RowIndex];
            }
            else textBox_UserID.Text = string.Empty;
        }

        private void comboBox_Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dictUpdateHistory == null) return;
            List<UpdateHistory> listUpdateHistory = dictUpdateHistory[comboBox_Suttas.Text];
            List<UpdateHistory> listSelectedUpdateHistory = listUpdateHistory.Where(x => x.RowKey.Contains(comboBox_Pages.Text)).ToList();
            FillDataGridView(listSelectedUpdateHistory);
        }
        
    }
}
