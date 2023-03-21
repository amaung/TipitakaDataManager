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
    public partial class Form_SuttaInfo : Form
    {
        Form1 parent;
        ClientSuttaInfo? clientSuttaInfo;
        ClientSuttaPageData? clientSuttaPageData;
        ClientActivityLog? clientActivityLog;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;

        List<SuttaInfo>? suttaInfos;
        Dictionary<string, SuttaInfo> dictSuttaInfo = new Dictionary<string, SuttaInfo>();
        Form_ViewSource? form_ViewSource;
        public Form_SuttaInfo(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            InitDataGridView();
            clientSuttaInfo = parent.clientTipitakaDB.GetClientSuttaInfo();
            clientSuttaPageData = parent.clientTipitakaDB.GetClientSuttaPageData();
            clientActivityLog = parent.clientTipitakaDB.GetClientActivityLog();
            clientTipitakaDBLogin = parent.clientTipitakaDB.GetClientTipitakaDBLogin();
            form_ViewSource = new Form_ViewSource(parent);
            textBox_TotalSutta.ForeColor = Color.Black;
        }
        private void InitDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells | DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnCount = 6;
            dataGridView1.RowTemplate.Height = 30;
            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows.
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = parent.CellBackgroundColor;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = parent.HeaderBackGroundColor;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.Columns[0].HeaderText = "SuttaNo";
            dataGridView1.Columns[1].HeaderText = "Start-End";
            dataGridView1.Columns[2].HeaderText = "Assigned Users";
            dataGridView1.Columns[3].HeaderText = "Asgn.";
            dataGridView1.Columns[4].HeaderText = "Sub.";
            dataGridView1.Columns[5].HeaderText = "Ver.";
            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 270;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += dataGridView_CellClick!;
        }
        int totalPages = 0, totalAssigned = 0, totalSubmitted = 0, totalVerified = 0;
        public void LoadInitialData()
        {
            dataGridView1.Rows.Clear();
            dictSuttaInfo.Clear();
            totalPages = totalAssigned = totalSubmitted = totalVerified = 0;

            if (clientSuttaInfo == null) return;
            suttaInfos = clientSuttaInfo.QuerySuttaInfo();
            if (suttaInfos == null) return;
            //int noPages = 0, pagesAssigned, pagesSubmitted, pagesVerified;
            //int totalPages = 0, totalAssigned = 0, totalSubmitted = 0, totalVerified = 0;
            int rowIndex = -1;
            foreach (SuttaInfo suttaInfo in suttaInfos)
            {
                if (suttaInfo == null) continue;
                ++rowIndex;
                if (!dictSuttaInfo.ContainsKey(suttaInfo.RowKey))
                {
                    dictSuttaInfo.Add(suttaInfo.RowKey, suttaInfo);
                    dataGridView1.Rows.Insert(rowIndex, 1);
                    UpdateRowCells(rowIndex, suttaInfo);

                    //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[rowIndex];  //dataGridView1.Rows[0].Clone();
                    //row.Cells[0].Value = suttaInfo.RowKey;
                    //noPages = suttaInfo.Pages;
                    //totalPages += noPages;
                    //pagesAssigned = suttaInfo.AssignedPages; pagesSubmitted = suttaInfo.PagesSubmitted; pagesVerified = suttaInfo.PagesVerified;
                    //totalAssigned += pagesAssigned; totalSubmitted += pagesSubmitted; totalVerified += pagesVerified;
                    //row.Cells[1].Value = String.Format("{0}-{1}", suttaInfo.StartPage, suttaInfo.EndPage);
                    //row.Cells[2].Value = suttaInfo.AssignedUsers;
                    //row.Cells[3].Value = String.Format("{0}%", PercentInt(pagesAssigned, noPages));
                    //row.Cells[4].Value = String.Format("{0}%", PercentInt(pagesSubmitted, noPages));
                    //row.Cells[5].Value = String.Format("{0}%", PercentInt(pagesVerified, noPages));
                }
                else
                {
                    // there is existing row, just update
                    dictSuttaInfo[suttaInfo.RowKey] = suttaInfo;
                    UpdateRowCells(rowIndex, suttaInfo);
                }
            }
            textBox_TotalSutta.Text = suttaInfos.Count.ToString();
            textBox_TotalPages.Text = totalPages.ToString();
            textBox_TotalAssigned.Text = String.Format("{0} ({1}%)", totalAssigned, PercentInt(totalAssigned, totalPages));
            textBox_TotalSubmitted.Text = String.Format("{0} ({1}%)", totalSubmitted, PercentInt(totalSubmitted, totalPages));
            textBox_TotalVerified.Text = String.Format("{0} ({1}%)", totalVerified, PercentInt(totalVerified, totalPages));
            DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(0, 0);
            dataGridView_CellClick(dataGridView1, e);
            dataGridView1.Focus();
        }
        private void UpdateRowCells(int rowIndex, SuttaInfo suttaInfo)
        {
            int noPages = 0, pagesAssigned, pagesSubmitted, pagesVerified;
            //int totalPages = 0, totalAssigned = 0, totalSubmitted = 0, totalVerified = 0;

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[rowIndex];
            row.Cells[0].Value = suttaInfo.RowKey;
            noPages = suttaInfo.Pages;
            totalPages += noPages;
            pagesAssigned = suttaInfo.AssignedPages; pagesSubmitted = suttaInfo.PagesSubmitted; pagesVerified = suttaInfo.PagesVerified;
            totalAssigned += pagesAssigned; totalSubmitted += pagesSubmitted; totalVerified += pagesVerified;
            row.Cells[1].Value = String.Format("{0}-{1}", suttaInfo.StartPage, suttaInfo.EndPage);
            row.Cells[2].Value = suttaInfo.AssignedUsers;
            row.Cells[3].Value = String.Format("{0}%", PercentInt(pagesAssigned, noPages));
            row.Cells[4].Value = String.Format("{0}%", PercentInt(pagesSubmitted, noPages));
            row.Cells[5].Value = String.Format("{0}%", PercentInt(pagesVerified, noPages));
        }
        public SuttaInfo? GetSuttaInfo(int rowIndex)
        {
            if (suttaInfos == null) return null;
            if (rowIndex < 0 || rowIndex >= suttaInfos.Count) return null;
            return suttaInfos[rowIndex];
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1 && suttaInfos != null && suttaInfos.Count > 0)
            {
                textBox_SelSuttaNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_SelPages.Text = suttaInfos[e.RowIndex].Pages.ToString();
                textBox_SelAssigned.Text = String.Format("{0} ({1})", suttaInfos[e.RowIndex].AssignedPages, dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                textBox_SelSubmitted.Text = String.Format("{0} ({1})", suttaInfos[e.RowIndex].PagesSubmitted, dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                textBox_SelVerified.Text = String.Format("{0} ({1})", suttaInfos[e.RowIndex].PagesVerified, dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                button_Download.Enabled = button_View.Enabled = suttaInfos[e.RowIndex].PagesSubmitted > 0;
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        private int PercentInt(int value1, int value2)
        {
            double p = (float)value1 / (float)value2 * 100.0;
            return (int)p;
        }
        private void button_Download_Click(object sender, EventArgs e)
        {
            string fileFilters = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // get pages
            if (clientSuttaPageData != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = fileFilters;
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = textBox_SelSuttaNo.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                this.Cursor = Cursors.WaitCursor;
                clientSuttaPageData.SetSubPartitionKey(textBox_SelSuttaNo.Text);
                SortedDictionary<int, string> suttaData = clientSuttaPageData.GetSutta();
                string fileContent = "{MN:" + textBox_SelSuttaNo.Text.Substring(3) + "}";
                foreach (KeyValuePair<int, string> kv in suttaData)
                {
                    fileContent += System.Environment.NewLine + kv.Value.ToString() + System.Environment.NewLine;
                }
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.WriteLine(fileContent);
                    writer.Close();
                }
                if (clientActivityLog != null && clientTipitakaDBLogin != null && clientTipitakaDBLogin.loggedinUser != null)
                    clientActivityLog.AddActivityLog(clientTipitakaDBLogin.loggedinUser.RowKey, textBox_SelSuttaNo.Text + " downloaded.");
                this.Cursor = Cursors.Default;
                MessageBox.Show("Download complete.");
            }
        }
        private void button_View_Click(object sender, EventArgs e)
        {

        }
        private void button_ViewSource_Click(object sender, EventArgs e)
        {
            if (form_ViewSource != null && dataGridView1.CurrentRow != null)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                if (suttaInfos != null && suttaInfos.Count > rowIndex)
                {
                    form_ViewSource.Init(textBox_SelSuttaNo.Text, suttaInfos[rowIndex].StartPage, suttaInfos[rowIndex].EndPage);
                    form_ViewSource.Show();
                }
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            LoadInitialData();
        }
    }
}
