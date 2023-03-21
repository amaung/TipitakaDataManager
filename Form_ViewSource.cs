using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tipitaka_DB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TipitakaDataManager
{
    public partial class Form_ViewSource : Form
    {
        Form1 parent;
        ClientTipitakaDB? clientTipitakaDB;
        TipitakaFileStorage tipitakaFileStorage = new TipitakaFileStorage(".\\SourcePages");
        string SuttaNo = string.Empty;
        int startPage = 0, endPage = 0;
        public Form_ViewSource(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            clientTipitakaDB = parent.clientTipitakaDB;
        }
        public void Init(string suttaNo, int start, int end)
        {
            if (suttaNo == textBox_SuttaNo.Text && start == startPage && end == endPage) return;
            
            textBox_SuttaNo.Text = suttaNo;
            SuttaNo = suttaNo;
            comboBox_PageNos.Items.Clear();
            for (int i = start; i <= end; i++)
                comboBox_PageNos.Items.Add(i.ToString("D3"));
            button_Right.Enabled = button_Left.Enabled = false;
        }
        private void button_Done_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button_Left_Click(object sender, EventArgs e)
        {
            if (comboBox_PageNos.SelectedIndex - 1 >= 0) comboBox_PageNos.SelectedIndex--;
            else comboBox_PageNos.SelectedIndex = comboBox_PageNos.Items.Count- 1;
        }

        private void button_Right_Click(object sender, EventArgs e)
        {
            if (comboBox_PageNos.SelectedIndex + 1 < comboBox_PageNos.Items.Count) comboBox_PageNos.SelectedIndex++;
            else comboBox_PageNos.SelectedIndex = 0;
        }

        private void comboBox_PageNos_SelectedIndexChanged(object sender, EventArgs e)
        {
            const string dirName = "Source";
            string path;
            Cursor.Current = Cursors.WaitCursor;
            string fname = String.Format("{0}-{1}.jpg", textBox_SuttaNo.Text, comboBox_PageNos.Text);
            if (!Directory.Exists(dirName))
            {
                // create dir
                Directory.CreateDirectory(dirName);
            }
            path = dirName+ "//" + fname;
            if (!File.Exists(path))
            {
                // download file
                // open the file
                string dataType = textBox_SuttaNo.Text.Substring(0, 2);
                int fileNo = Convert.ToInt16(textBox_SuttaNo.Text.Substring(3));
                int pgNo = comboBox_PageNos.Text.Length > 0 ? Convert.ToInt16(comboBox_PageNos.Text) : 0;
                if (tipitakaFileStorage != null && pgNo > 0)
                {
                    tipitakaFileStorage.FileDownload(dataType, fileNo, pgNo);
                    if (tipitakaFileStorage.StatusCode == 404)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(String.Format("'{0}' {1}", path, tipitakaFileStorage.DBErrMsg));
                    }
                }
            }
            // file downloaded or already exists
            Bitmap orgBitmap = new Bitmap(new Bitmap(path));//, 990, 1275);
            double scale = 0.495;
            Bitmap resized = new Bitmap(orgBitmap, new Size((int)(orgBitmap.Width * scale), (int)(orgBitmap.Height * scale)));
            //RectangleF rect = new RectangleF(40, 10, resized.Width - 40, resized.Height - 10);
            //this.Size = new Size((int)resized.Width, (int)resized.Height + 100);
            this.Size = new Size(550, 730);
            //Bitmap curImage = orgBitmap.Clone(rect, orgBitmap.PixelFormat);
            panel1.BackgroundImage = resized; // curImage;
            button_Right.Enabled = button_Left.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
    }
}
