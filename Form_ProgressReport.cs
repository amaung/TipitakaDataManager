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
    public partial class Form_ProgressReport : Form
    {
        Form1 parent;
        ClientSuttaInfo? clientSuttaInfo;
        ClientMessageLog? clientMessageLog;
        public Form_ProgressReport(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            clientSuttaInfo = parent.clientSuttaInfo;
            clientMessageLog = parent.clientMessageLog;
        }
        public void LoadInitialData()
        {
            if (parent != null)
            {
                textBox_Users.Text = parent.GetAllUserProfiles()!.Count.ToString();
                textBox_Admins.Text = parent.GetAdmins()!.Count.ToString();
                LoadInitialDataBackground();
            }
        }
        public void LoadInitialDataBackground()
        {
            if (parent != null)
            {
                if (clientSuttaInfo!= null)
                {
                    clientSuttaInfo.QuerySuttaInfo();
                    if (clientSuttaInfo.StatusCode== 0)
                    {
                        List<SuttaInfo> listSuttaInfo = (List<SuttaInfo>)clientSuttaInfo.objResult;
                        int srcPages = 0;
                        int assignedPages = 0;
                        int submittedPages = 0;
                        int verifiedPages = 0;
                        listSuttaInfo.ForEach(suttaInfo => { 
                            srcPages += suttaInfo.Pages;
                            assignedPages += suttaInfo.AssignedPages;
                            submittedPages += suttaInfo.PagesSubmitted;
                            verifiedPages += suttaInfo.PagesVerified;
                        });
                        textBox_SourcePages.Text = String.Format("{0} ({1})", listSuttaInfo.Count.ToString(), srcPages.ToString());
                        textBox_AssignedPages.Text = assignedPages.ToString();
                        textBox_UnassignedPages.Text = (srcPages - assignedPages).ToString();
                        textBox_SubmittedPages.Text = submittedPages.ToString();
                        textBox_UnsubmittedPages.Text = (assignedPages- submittedPages).ToString();
                        textBox_VerifiedPages.Text = verifiedPages.ToString();
                        textBox_UnsubmittedPages.Text = (submittedPages - verifiedPages).ToString();
                        textBox_Messages.Text = clientMessageLog!.GetMessageCount().ToString();
                        textBox_ExpectedTime.SelectionStart = textBox_ExpectedTime.SelectionLength = 0;
                    }
                }
            }
        }
    }
}
