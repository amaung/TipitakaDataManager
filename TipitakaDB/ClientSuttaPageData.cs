using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tipitaka_DBTables;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Tipitaka_DB
{
#nullable enable
    public class ClientSuttaPageData : TipitakaDB
    {
        public const string _SuttaPageData_ = "SuttaPageData";
        ClientTipitakaDB? clientTipitakaDB;
        ClientUserPageActivity? clientUserPageActivity;
        ClientSuttaPageAssignment? clientSuttaAssignment;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;
        //ClientUpdateHistory? clientUpdateHistory;

        ClientSuttaInfo? clientSuttaInfo;

        //*******************************************************************
        //*** ClientSuttaPageData
        //*******************************************************************
        public ClientSuttaPageData(ClientTipitakaDB clientTipitakaDB) : base(_SuttaPageData_) 
        { 
            this.clientTipitakaDB = clientTipitakaDB;
            clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
            clientUserPageActivity = clientTipitakaDB.GetClientUserPageActivity();
        }
        //Dictionary<string, string>
        public void UploadSutta(string userID, string dataType, int suttaNo, Dictionary<string, string> dataPages)
        {
            int pgNo = 0, pagesSubmitted = 0;
            if (clientTipitakaDB == null) { return; }
            clientUserPageActivity = clientTipitakaDB.GetClientUserPageActivity();

            clientSuttaAssignment = clientTipitakaDB.GetClientSuttaAssignment();
            clientSuttaInfo = clientTipitakaDB.GetClientSuttaInfo();

            SuttaPageData suttaPageData = new SuttaPageData();
            string partitionKey, rowKey;
            partitionKey = rowKey = String.Format("{0}-{1}", dataType, suttaNo.ToString("D3"));
            SetSubPartitionKey(partitionKey);
            //// check if user has been assigned to this 
            //clientSuttaAssignment.GetSuttaPageAssignment(partitionKey, userID);
            clientSuttaAssignment.QuerySuttaPageAssignment(rowKey);
            List<SuttaPageAssignment> listSuttaPageAssignment = (List<SuttaPageAssignment>)clientSuttaAssignment.objResult;
            if (listSuttaPageAssignment.Count == 0 || listSuttaPageAssignment.Count(x => x.AssignedTo == userID) == 0)
            {
                MessageBox.Show(userID + " is not the assigned user for " + rowKey); return;
            }
            // get sutta page data from the server
            string MNno = String.Format("{0}-{1}", dataType, suttaNo.ToString("D3"));
            SetSubPartitionKey(MNno);
            SortedDictionary<int, SuttaPageData> dictSuttaDataPages = GetSuttaPageData();

            foreach (KeyValuePair<string, string> kv in dataPages)
            {
                pgNo = Convert.ToInt16(kv.Key); //listNissayaRecords = kv.Value;
                rowKey = String.Format("{0}-{1}-{2}", dataType, suttaNo.ToString("D3"), pgNo.ToString("D3"));
                // check for existing data record
                if (dictSuttaDataPages.Count > 0 && dictSuttaDataPages.ContainsKey(pgNo))
                {
                    // sutta already has some data on the server
                    // skip if the uploaded page and existing page are identical
                    if (dataPages[kv.Key] == dictSuttaDataPages[pgNo].PageData) { continue; }

                    // do UpdateHistory
                    SuttaPageData pageData = dictSuttaDataPages[pgNo];
                    List<NissayaRecord> existingNissayaRecords = ParseNissayaPage(pageData.PageData);
                    List<NissayaRecord> newNissayaRecords = ParseNissayaPage(dataPages[pgNo.ToString()]);
                    //Dictionary<int, NissayaRecord> newNissayaRecords = ParseNissayaPage(kv.Value.ToString());
                    switch (DoUpdateHistory(userID, MNno, pgNo, newNissayaRecords, DateTime.Now.ToUniversalTime(), existingNissayaRecords, pageData.Timestamp!.Value.UtcDateTime))
                    {
                        case 1:
                            // update required
                            pageData.PageData = kv.Value; // MakeNissayaPage(pgNo, kv.Value);
                            pageData.Status = "Updated";
                            UpdateTableRec(pageData).Wait();
                            if (StatusCode != 204)
                            {
                                MessageBox.Show("Page data update error." + pageData.RowKey); return;
                            }
                            // update UserPageActivity
                            UpdateUserPageActivity(rowKey, "Updated");
                            break;
                        default: break;
                    }
                }
                else
                {
                    // this is a new page
                    suttaPageData.PartitionKey = partitionKey;
                    suttaPageData.RowKey = rowKey;
                    suttaPageData.PageNo = pgNo;
                    suttaPageData.PageData = kv.Value; // MakeNissayaPage(pgNo, kv.Value);
                    suttaPageData.Status = "Submitted";
                    suttaPageData.UserID = userID;
                    InsertTableRec(suttaPageData).Wait();
                    if (StatusCode != 204)
                    {
                        MessageBox.Show("Data insert error."); return;
                    }
                    ++pagesSubmitted;

                    // UserPageActivity update
                    if (!UpdateUserPageActivity(rowKey, "Submitted")) return;
                }
            }
            if (pagesSubmitted > 0)
            {
                SuttaPageAssignment? suttaPageAssignment = listSuttaPageAssignment.Find(x => (x.StartPage <= pgNo && x.EndPage >= pgNo));
                // update SuttaPageAssignment
                if (suttaPageAssignment == null) return;
                suttaPageAssignment.Status = "Submitted";
                clientSuttaAssignment.UpdateTableRec(suttaPageAssignment).Wait();
                if (clientSuttaAssignment.StatusCode != 204)
                {
                    MessageBox.Show("SuttaPageAssignment update error at rowkey = " + suttaPageAssignment.PartitionKey
                        + "\\" + suttaPageAssignment.RowKey);
                    return;
                }

                // update SuttaInfo
                clientSuttaInfo.RetrieveTableRec(MNno).Wait();
                if (clientSuttaInfo.StatusCode == 200)
                {
                    SuttaInfo suttaInfo = (SuttaInfo)clientSuttaInfo.objResult;
                    suttaInfo.PagesSubmitted += pagesSubmitted;
                    if (suttaInfo.PagesSubmitted > suttaInfo.Pages) suttaInfo.PagesSubmitted = suttaInfo.Pages;
                    clientSuttaInfo.UpdateTableRec(suttaInfo).Wait();
                    if (clientSuttaInfo.StatusCode != 204)
                    {
                        MessageBox.Show("SuttaInfo update failed at " + MNno);
                    }
                }
            }
        }
        public void UploadSutta(string userID, string dataType, int suttaNo, Dictionary<int, List<NissayaRecord>> dictPages)
        {
            int pgNo = 0, pagesSubmitted = 0;
            if (clientTipitakaDB == null) { return; }
            clientUserPageActivity = clientTipitakaDB.GetClientUserPageActivity();
            clientSuttaAssignment = clientTipitakaDB.GetClientSuttaAssignment();
            clientSuttaInfo = clientTipitakaDB.GetClientSuttaInfo();

            SuttaPageData suttaPageData = new SuttaPageData();
            List<NissayaRecord> listNissayaRecords;
            string partitionKey, rowKey;
            partitionKey = rowKey = String.Format("{0}-{1}", dataType, suttaNo.ToString("D3"));
            //SetSubPartitionKey(partitionKey);
            // check if user has been assigned to this 
            //clientSuttaAssignment.GetSuttaPageAssignment(partitionKey, userID);
            clientSuttaAssignment.QuerySuttaPageAssignment(rowKey);
            List<SuttaPageAssignment> listSuttaPageAssignment= (List<SuttaPageAssignment>)clientSuttaAssignment.objResult;
            if (listSuttaPageAssignment.Count == 0 || listSuttaPageAssignment.Count(x => x.AssignedTo == userID) == 0)
            {
                MessageBox.Show(userID + " is not the assigned user for " + rowKey); return;
            }
            string MNno = String.Format("{0}-{1}", dataType, suttaNo.ToString("D3"));
            SetSubPartitionKey(MNno);
            SortedDictionary<int, SuttaPageData> dictSuttaDataPages = GetSuttaPageData();

            foreach (KeyValuePair<int, List<NissayaRecord>> kv in dictPages)
            {
                pgNo = kv.Key; listNissayaRecords = kv.Value;
                rowKey = String.Format("{0}-{1}-{2}", dataType, suttaNo.ToString("D3"), pgNo.ToString("D3"));
                // check for existing data record
                if (dictSuttaDataPages.Count > 0 && dictSuttaDataPages.ContainsKey(pgNo))
                {
                    //SuttaPageData? pageData = GetCurrentPageData(MNno, rowKey);
                    //if (dictSuttaDataPages.Count > 0 && dictSuttaDataPages.ContainsKey(pgNo)) //pageData != null)
                    //{
                    // do UpdateHistory
                    SuttaPageData pageData = dictSuttaDataPages[pgNo];
                    List<NissayaRecord> existingNissayaRecords = ParseNissayaPage(pageData.PageData);
                    //Dictionary<int, NissayaRecord> newNissayaRecords = ParseNissayaPage(kv.Value.ToString());
                    switch(DoUpdateHistory(userID, MNno, pgNo, listNissayaRecords, DateTime.Now.ToUniversalTime(), existingNissayaRecords, pageData.Timestamp!.Value.UtcDateTime))
                    {
                        case 1:
                            // update required
                            pageData.PageData = MakeNissayaPage(pgNo, kv.Value);
                            pageData.Status = "Updated";
                            UpdateTableRec(pageData).Wait();
                            if (StatusCode != 204)
                            {
                                MessageBox.Show("Page data update error." + pageData.RowKey); return;
                            }
                            // update UserPageActivity
                            UpdateUserPageActivity(rowKey, "Updated");
                            break;
                        default: break;
                    }
                }
                else
                {
                    // this is a new page
                    suttaPageData.PartitionKey = partitionKey;
                    suttaPageData.RowKey = rowKey;
                    suttaPageData.PageNo = pgNo;
                    suttaPageData.PageData = MakeNissayaPage(pgNo, kv.Value);
                    suttaPageData.Status = "Submitted";
                    suttaPageData.UserID = userID;
                    InsertTableRec(suttaPageData).Wait();
                    if (StatusCode != 204)
                    {
                        MessageBox.Show("Data insert error."); return;
                    }
                    ++pagesSubmitted;

                    // UserPageActivity update
                    if (!UpdateUserPageActivity(rowKey, "Submitted")) return;
                }
            }
            if (pagesSubmitted > 0)
            {
                SuttaPageAssignment? suttaPageAssignment = listSuttaPageAssignment.Find(x => (x.StartPage <= pgNo && x.EndPage >= pgNo));
                // update SuttaPageAssignment
                if (suttaPageAssignment == null) return;
                suttaPageAssignment.Status = "Submitted";
                clientSuttaAssignment.UpdateTableRec(suttaPageAssignment).Wait();
                if (clientSuttaAssignment.StatusCode != 204)
                {
                    MessageBox.Show("SuttaPageAssignment update error at rowkey = " + suttaPageAssignment.PartitionKey
                        + "\\" + suttaPageAssignment.RowKey);
                    return;
                }

                // update SuttaInfo
                clientSuttaInfo.RetrieveTableRec(MNno).Wait();
                if (clientSuttaInfo.StatusCode == 200) 
                {
                    SuttaInfo suttaInfo = (SuttaInfo)clientSuttaInfo.objResult;
                    suttaInfo.PagesSubmitted += pagesSubmitted;
                    if (suttaInfo.PagesSubmitted > suttaInfo.Pages) suttaInfo.PagesSubmitted = suttaInfo.Pages;
                    clientSuttaInfo.UpdateTableRec(suttaInfo).Wait();
                    if (clientSuttaInfo.StatusCode!= 204) 
                    {
                        MessageBox.Show("SuttaInfo update failed at " + MNno);
                    }
                }
            }
        }
        private bool UpdateUserPageActivity(string rowKey, string status)
        {
            clientUserPageActivity!.RetrieveTableRec(rowKey).Wait();
            if (clientUserPageActivity.StatusCode == 200)
            {
                UserPageActivity userPageActivity = (UserPageActivity)clientUserPageActivity.objResult;
                userPageActivity.Status = status;
                var turnAroundTime = DateTime.UtcNow - userPageActivity.AssignedDate;
                userPageActivity.TurnAroundTime = turnAroundTime!.Days;
                if (userPageActivity.TurnAroundTime <= 0) userPageActivity.TurnAroundTime = 1;
                clientUserPageActivity.UpdateTableRec(userPageActivity).Wait();
                if (clientUserPageActivity.StatusCode != 204)
                {
                    MessageBox.Show("UserPageActivity update error at rowkey = " + rowKey);
                    return false;
                }
            }
            return true;
        }
        private int DoUpdateHistory(string userID, string MNNo, int pgNo, List<NissayaRecord> newRecords, DateTime dt1, List<NissayaRecord> oldRecords, DateTime dt2)
        {
            string s; int rc = 0;
            string rkdt = string.Empty;
            UpdateHistory updateHistory = new UpdateHistory();
            ClientUpdateHistory clientUpdateHistory = clientTipitakaDB!.GetClientUpdateHistory();
            for (int i = 0; i < newRecords.Count; ++i)
            {
                // compare new and existing NIS record
                if (i >= oldRecords.Count) continue;
                s = newRecords[i].IsEqual(oldRecords[i]);
                if (s.Length > 0)
                {
                    // the record has been updated
                    // check if the MN-nnn-ddd NIS rec exists in the Update History
                    clientUpdateHistory.SetSubPartitionKey(MNNo);
                    string filter = String.Format("RowKey ge 'P{0}-R{1}'", pgNo.ToString("D3"), newRecords[i].recNo.ToString("D2"));
                    filter += String.Format(" and RowKey lt 'P{0}-R{1}'", pgNo.ToString("D3"), (newRecords[i].recNo+1).ToString("D2"));
                    List<UpdateHistory> listUpdateHistory = clientUpdateHistory.QueryUpdateHistory(filter);
                    if (listUpdateHistory.Count == 0)
                    {
                        // there is no existing rec, need to write the original rec
                        updateHistory.PartitionKey = MNNo;
                        rkdt = String.Format("{0}{1}{2}-{3}{4}{5}.{6}", dt2.Year, dt2.Month.ToString("D2"), dt2.Day.ToString("D2"),
                            dt2.Hour.ToString("D2"), dt2.Minute.ToString("D2"), dt2.Second.ToString("D2"), dt2.Millisecond.ToString("D4"));
                        updateHistory.RowKey = String.Format("P{0}-R{1}:{2}", pgNo.ToString("D3"), oldRecords[i].recNo.ToString("D2"), rkdt);
                        updateHistory.Data = oldRecords[i].ToString();
                        updateHistory.UserID = userID;
                        clientUpdateHistory.InsertUpdateHistory(updateHistory);
                        if (clientUpdateHistory.StatusCode != 204)
                        {
                            MessageBox.Show("UpdateHistory error in base NIS record " + updateHistory.RowKey); return -1;
                        }
                    }
                    // now, write the new NIS record
                    updateHistory.PartitionKey = MNNo;
                    DateTime utc = DateTime.UtcNow;
                    rkdt = String.Format("{0}{1}{2}-{3}{4}{5}.{6}", utc.Year, utc.Month.ToString("D2"), utc.Day.ToString("D2"),
                        utc.Hour.ToString("D2"), utc.Minute.ToString("D2"), utc.Second.ToString("D2"), utc.Millisecond.ToString("D4"));
                    updateHistory.RowKey = String.Format("P{0}-R{1}:{2}", pgNo.ToString("D3"), newRecords[i].recNo.ToString("D2"), rkdt);
                    string[] f = s.Split('|');
                    updateHistory.Data= newRecords[i].ToString();
                    updateHistory.UserID= userID;
                    clientUpdateHistory.InsertTableRec(updateHistory).Wait();
                    if (clientUpdateHistory.StatusCode != 204)
                    {
                        MessageBox.Show("UpdateHistory error in new NIS record " + updateHistory.RowKey); return -1;
                    }
                    rc = 1;
                }
            }
            return rc;
        }
        private SuttaPageData? GetCurrentPageData(string MNno, string rowKey)
        {
            SetSubPartitionKey(MNno);
            RetrieveTableRec(rowKey).Wait();
            if (StatusCode == 404) return null;
            SuttaPageData suttaPageData = (SuttaPageData)objResult;
            return suttaPageData;
        }
        //public bool IsAssignedUser(string MNNo, string userID)
        //{
        //    var clientSuttaAssignment = clientTipitakaDB!.GetClientSuttaAssignment();
        //    SuttaPageAssignment? suttaPageAssignment = clientSuttaAssignment.GetSuttaPageAssignment(MNNo);
        //    //clientSuttaAssignment.GetSuttaPageAssignment(MNNo, userID);
        //    if (suttaPageAssignment == null || clientSuttaAssignment.StatusCode == 404)
        //    {
        //        MessageBox.Show(userID + " is not the assigned user for " + MNNo); return false;
        //    }
        //    return true;
        //}
        public SortedDictionary<int, string> GetSutta(string rowKey = "")
        {
            SortedDictionary<int, string> dictSuttaPages = new SortedDictionary<int, string>();
            QueryTableRec(rowKey).Wait();
            List<SuttaPageData> listSuttaPageData = (List<SuttaPageData>)objResult;
            foreach(SuttaPageData suttaPageData in listSuttaPageData)
            {
                dictSuttaPages.Add(suttaPageData.PageNo, suttaPageData.PageData);
            }
            return dictSuttaPages;
        }
        public SortedDictionary<int, SuttaPageData> GetSuttaPageData(string rowKey = "")
        {
            SortedDictionary<int, SuttaPageData> dictSuttaPages = new SortedDictionary<int, SuttaPageData>();
            QueryTableRec(rowKey).Wait();
            List<SuttaPageData> listSuttaPageData = (List<SuttaPageData>)objResult;
            foreach (SuttaPageData suttaPageData in listSuttaPageData)
            {
                dictSuttaPages.Add(suttaPageData.PageNo, suttaPageData);
            }
            return dictSuttaPages;
        }
        public String[] GetAllPartitionKeys()
        {
            //    ConcurrentDictionary<string, byte> partitionKeys = new ConcurrentDictionary<string, byte>();
            //    Parallel.ForEach(this.ExecuteQuery(new TableQuery()), entity =>
            //    {
            //        partitionKeys.TryAdd(entity.PartitionKey, 0);
            //    });
            this.QueryTableRec("LoadedSuttas").Wait();
            List<SuttaPageData> listSuttaPageData = (List<SuttaPageData>)objResult;
            List<string> result = new List<string>();
            foreach(SuttaPageData suttaPageData in listSuttaPageData)
            {
                if (!result.Contains(suttaPageData.PartitionKey))
                    result.Add(suttaPageData.PartitionKey);
            }
            return result.ToArray();
        }
    }
#nullable disable
}
