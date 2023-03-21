using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tipitaka_DBTables;

namespace Tipitaka_DB
{
    public class ClientKeyValueData : TipitakaDB
    {
        public const string _KeyValueData_ = "KeyValueData";
        ClientTipitakaDB? clientTipitakaDB;
        ClientUserPageActivity? clientUserPageActivity;
        ClientSuttaPageAssignment? clientSuttaAssignment;
        ClientTipitakaDBLogin? clientTipitakaDBLogin;

        ClientSuttaInfo? clientSuttaInfo;

        //*******************************************************************
        //*** ClientSuttaPageData
        //*******************************************************************
        public ClientKeyValueData(ClientTipitakaDB clientTipitakaDB) : base(_KeyValueData_)
        {
            this.clientTipitakaDB = clientTipitakaDB;
            clientTipitakaDBLogin = clientTipitakaDB.GetClientTipitakaDBLogin();
        }
        public KeyValueData? GetKeyValueData(string rowKey)
        {
            RetrieveTableRec(rowKey).Wait();
            if (StatusCode == 404) return null;
            KeyValueData keyValueData = (KeyValueData)objResult;
            return keyValueData;
        }
        public void UpdateKeyValueData(KeyValueData keyValueData)
        {
            RetrieveTableRec(keyValueData.RowKey).Wait();
            if (StatusCode == 200 || StatusCode == 204)
            {
                KeyValueData keyValueData1 = (KeyValueData)objResult;
                keyValueData.Value = keyValueData.Value;
                UpdateTableRec(keyValueData1).Wait();
                return;
            }
            if (StatusCode == 404) // record not found
            {
                // add new record
                InsertTableRec(keyValueData).Wait();
                if (StatusCode != 204)
                    MessageBox.Show(String.Format("KeyValueData insert error.RowKey = {0}, Value = {1}", keyValueData.RowKey, keyValueData.Value));
            }
        }
    }
}
