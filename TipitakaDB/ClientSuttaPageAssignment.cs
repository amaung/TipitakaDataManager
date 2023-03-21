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
    public class ClientSuttaPageAssignment : TipitakaDB
    {
        const string _SuttaPageAssignment_ = "SuttaPageAssignment";
        public ClientSuttaPageAssignment() : base(_SuttaPageAssignment_)
        { }
        public void AddSuttaPageAssignment(SuttaPageAssignment suttaPageAssignment)
        {
            InsertTableRec(suttaPageAssignment).Wait();
        }
        public void QuerySuttaPageAssignment(string filter = "")
        {
            if (filter.Length > 0)
            {
                int suttaNo = Convert.ToInt16(filter.Substring(3, 3));
                string suttaNo2 = filter.Substring(0, 3) + (suttaNo+1).ToString("D3");
                filter = String.Format("(RowKey ge '{0}' and RowKey le '{1}')", filter, suttaNo2);
            }
            QueryTableRec(filter).Wait();
        }
        public List<SuttaPageAssignment> QuerySuttaPageAssignmentByUser(string userID = "")
        {
            List<SuttaPageAssignment> listSuttaPageAssignment = new List<SuttaPageAssignment>();
            QueryTableRec(String.Empty).Wait();
            List<SuttaPageAssignment> tmplistSuttaPageAssignment = (List<SuttaPageAssignment>)objResult;
            foreach(SuttaPageAssignment suttaPageAssignment in tmplistSuttaPageAssignment)
                if (suttaPageAssignment.AssignedTo.Contains(userID)) listSuttaPageAssignment.Add(suttaPageAssignment);
            return listSuttaPageAssignment;
        }
#nullable enable
        public SuttaPageAssignment? GetSuttaPageAssignment(string rowKey)
        {
            //SetSubPartitionKey(MNNo);
            RetrieveTableRec(rowKey).Wait();
            if (StatusCode == 200)
                return (SuttaPageAssignment)objResult;
            return null;
        }
#nullable disable
        public void UpdateSuttaPageAssignment(SuttaPageAssignment suttaPageAssignment)
        {
            UpdateTableRec(suttaPageAssignment).Wait();
        }
        public void DeleteSuttaPageAssignment(SuttaPageAssignment suttaPageAssignment)
        {
            DeleteTableRec(suttaPageAssignment).Wait();
        }
    }
}
