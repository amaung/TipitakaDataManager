using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
    public class ClientSuttaInfo : TipitakaDB
    {
        const string _SuttaInfo_ = "SuttaInfo";
        public ClientSuttaInfo() : base(_SuttaInfo_)
        { }
        public void AddSuttaInfo(SuttaInfo suttaInfo)
        {
            InsertTableRec(suttaInfo).Wait();

        }
        public void UpdateSuttaInfo(SuttaInfo suttaInfo)
        {
            RetrieveTableRec(suttaInfo.RowKey).Wait();
            if (StatusCode == 200)
            {
                SuttaInfo newSuttaInfo = (SuttaInfo)objResult;
                newSuttaInfo.AssignedPages = suttaInfo.AssignedPages;
                newSuttaInfo.AssignedUsers = suttaInfo.AssignedUsers;
                UpdateTableRec(newSuttaInfo).Wait();
            }
        }
        public void GetSuttaInfo(string rowKey)
        {
            RetrieveTableRec(rowKey).Wait();
        }
        public void DeleteSuttaInfo(SuttaInfo suttaInfo) 
        {
            DeleteTableRec(suttaInfo).Wait();
        }
        public List<SuttaInfo> QuerySuttaInfo(string rowKey = "")
        {
            List<SuttaInfo> list = new List<SuttaInfo>();
            QueryTableRec(rowKey).Wait();
            list = (List<SuttaInfo>)objResult;
            return list;
        }
    }
}
