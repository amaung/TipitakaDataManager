using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
    public class ClientUpdateHistory : TipitakaDB
    {
        const string _UpdateHistory_ = "UpdateHistory";
        ClientTipitakaDB clientTipitakaDB;
        List<UpdateHistory> listUpdateHistory= new List<UpdateHistory>();
        public ClientUpdateHistory(ClientTipitakaDB clientTipitakaDB) : base(_UpdateHistory_) { this.clientTipitakaDB = clientTipitakaDB; }
        public List<UpdateHistory> RetrieveUpdateHistory(string MNNo)
        {
            listUpdateHistory.Clear();
            SetSubPartitionKey(MNNo);
            QueryTableRec().Wait();
            if (StatusCode == 404)
            if (objResult != null) listUpdateHistory = (List<UpdateHistory>)objResult;
            return listUpdateHistory;
        }
        public UpdateHistory GetUpdateHistory(string rowKey)
        {
            UpdateHistory updateHistory = new UpdateHistory();
            if (rowKey == null || rowKey.Length == 0) return updateHistory;
            RetrieveTableRec(rowKey).Wait();
            if (StatusCode != 404) return (UpdateHistory)objResult;
            return updateHistory; ;
        }
        public List<UpdateHistory> QueryUpdateHistory(string filter = "")
        {
            List<UpdateHistory> updateHistory = new List<UpdateHistory>();
            QueryTableRec(filter).Wait();
            if (StatusCode == 0)
            {
                listUpdateHistory.Clear();
                updateHistory= (List<UpdateHistory>)objResult;
            }
            return updateHistory;
        }
        public List<UpdateHistory> QueryUpdateHistory(string MNno, int pageNo, int nisNo)
        {
            string rowKey1 = String.Format("{0}-P{1}-R{2}", MNno, pageNo.ToString("D3"), nisNo.ToString("D2"));
            string rowKey2 = String.Format("{0}-P{1}-R{2}", MNno, pageNo.ToString("D3"), (++nisNo).ToString("D2"));
            string filter = String.Format(" (RowKey ge '{0}' and RowKey lt '{1}')", rowKey1, rowKey2);

            return QueryUpdateHistory(filter);
        }
        public void InsertUpdateHistory(UpdateHistory updateHistory)
        {
            if (updateHistory != null)
            {
                InsertTableRec(updateHistory).Wait();
            }
            return;
        }
        public void Update_UpdateHistory(UpdateHistory updateHistory)
        {
            if (updateHistory != null)
            {
                UpdateTableRec(updateHistory).Wait();
            }
        }
    }
}
