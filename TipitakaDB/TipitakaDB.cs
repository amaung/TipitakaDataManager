using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.Configuration;
using Tipitaka_DBTables;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Tipitaka_DB
{
#nullable enable
    public partial class TipitakaDB
    {
        string? connectionString = null; //"DefaultEndpointsProtocol=https;AccountName=dystorage2021;AccountKey=JopS1zXQXsvQNAAbAVRNIbY5qDzFeVyXzJgKwgpnYLsODtRfjIx5UDwr7J5EYit8aKMeCyPxdM12pz/6SYfBGQ==;TableEndpoint=https://dystorage2021.table.core.windows.net/;";
        //string connectionStringTipitaka = "DefaultEndpointsProtocol=https;AccountName=tipitakadata2023;AccountKey=XudohdFrs+d+cgZLY69sgzf7MUHQIlAfJey8yo8BFhP7Cgnnyq3kdcnE8gusj9fAV0JvMIsb/QUB+AStqcY2Kw==;EndpointSuffix=core.windows.net";
        string connectionStringTipitaka = "DefaultEndpointsProtocol=https;AccountName=tipitakadata2023;AccountKey=XudohdFrs+d+cgZLY69sgzf7MUHQIlAfJey8yo8BFhP7Cgnnyq3kdcnE8gusj9fAV0JvMIsb/QUB+AStqcY2Kw==;TableEndpoint=https://tipitakadata2023.table.core.windows.net/;";
        // https://tipitakadata2023.table.core.windows.net/UserProfile
        string PartitionKey = string.Empty;
        string SubPartitionKey = string.Empty;
        TableClient? tableClient;
        string runMode = "PROD";
        // public access
        public int StatusCode;
        public string DBErrMsg = string.Empty;
        public Object objResult = new object();

        public TipitakaDB(string partitionKey)
        {
            try
            {
                if (runMode == "DEV") connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                else connectionString = ConfigurationManager.AppSettings["ConnectionStringProd"];
            }
            catch (Exception) 
            {
                if (runMode == "DEV") connectionString = "DefaultEndpointsProtocol=https;AccountName=dystorage2021;AccountKey=JopS1zXQXsvQNAAbAVRNIbY5qDzFeVyXzJgKwgpnYLsODtRfjIx5UDwr7J5EYit8aKMeCyPxdM12pz/6SYfBGQ==;TableEndpoint=https://dystorage2021.table.core.windows.net/;";
                else connectionString = connectionStringTipitaka;
            }
            PartitionKey = partitionKey;
            if (connectionString is not null && connectionString.Length > 0)
            {
                // New instance of the TableClient class
                TableServiceClient tableServiceClient = new TableServiceClient(connectionString);
                tableClient = tableServiceClient.GetTableClient(tableName: partitionKey);
            }
        }
        public string GetCloudStorageName()
        {
            string s = string.Empty;
            if (connectionString != null)
            {
                int pos = connectionString.IndexOf("https:");
                if (pos != -1)
                {
                    string[] f = connectionString.Substring(pos + 8).Split('.');
                    s = f[0];
                }
            }
            return s;
        }
        public void SetSubPartitionKey(string partitionKey) { SubPartitionKey = partitionKey; }
        //public void SetPartitionKey(string partitionKey) {  PartitionKey = partitionKey; }
        //*******************************************************************
        //*** Retrieve a table rec
        //*******************************************************************
        public async Task<Object> RetrieveTableRec(string rowKey)
        {
            Object obj = new Object();
            try
            {
                switch (PartitionKey)
                {
                    case "UserProfile":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<UserProfile>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            } 
                        }
                        break;
                    case "SuttaPageData":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<SuttaPageData>(
                                rowKey: rowKey,
                                partitionKey: SubPartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                    case "SuttaPageAssignment":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<SuttaPageAssignment>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                    case "SuttaInfo":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<SuttaInfo>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                    case "UserPageActivity":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<UserPageActivity>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                    case "UpdateHistory":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<UpdateHistory>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                    case "KeyValueData":
                        if (tableClient != null)
                        {
                            var result = await tableClient.GetEntityAsync<KeyValueData>(
                                rowKey: rowKey,
                                partitionKey: PartitionKey
                            ).ConfigureAwait(false);

                            StatusCode = result.GetRawResponse().Status;
                            if (StatusCode == 200)
                            {
                                obj = objResult = (Object)result.Value;
                            }
                        }
                        break;
                }
            }
            catch(Exception e)
            {
                //await Task.Yield();
                if (e.Message.Contains("Status")) StatusCode = ProcessCatchErrorMessage(e.Message.Split('\n'));
                else StatusCode = -1;
            }
            return obj;
        }
        //*******************************************************************
        //*** Query table records
        //*******************************************************************
        public async Task<Object> QueryTableRec(string qualifier = "")
        {
            //    Object obj = new Object();
            List<string> listObj = new List<string>();
            List<UserProfile> listUserProfile = new List<UserProfile>();
            string? token = null;
            try
            {
                switch (PartitionKey)
                {
                    case "UserProfile":
                        //https://learn.microsoft.com/en-us/visualstudio/azure/vs-azure-tools-table-designer-construct-filter-strings?view=vs-2022
                        if (tableClient != null)
                        {
                            qualifier = String.Format("(PartitionKey eq '{0}')", PartitionKey) + qualifier;
                            var pages = tableClient.QueryAsync<UserProfile>(qualifier, maxPerPage: 1000).AsPages().ConfigureAwait(false);
                            await foreach (var page in pages)
                            {
                                listUserProfile.AddRange(page.Values.ToList());
                                token = page.ContinuationToken; // usage ?
                            }
                            objResult = (Object)listUserProfile;
                        }
                        break;
                    case "ActivityLog":
                        //https://learn.microsoft.com/en-us/visualstudio/azure/vs-azure-tools-table-designer-construct-filter-strings?view=vs-2022
                        if (tableClient != null)
                        {
                            string filter = String.Format("(PartitionKey eq '{0}')", PartitionKey);
                            if (qualifier!= null && qualifier.Length > 0) filter += qualifier;
                            token = null;
                            var pages = tableClient.QueryAsync<ActivityLog>(filter, maxPerPage: 1000).AsPages().ConfigureAwait(false);
                            await foreach(var page in  pages)
                            {
                                List<ActivityLog> listActivities = page.Values.ToList();
                                foreach (var activityLog in listActivities)
                                {
                                    listObj.Add(String.Format("{0}|{1}|{2}", GetLocalTime(activityLog.RowKey), activityLog.UserID, activityLog.Activity));
                                }
                                token = page.ContinuationToken; // usage ?
                            }
                            listObj.Reverse();
                            objResult = (Object)listObj;
                        }
                        break;
                    case "MessageLog":
                        List<MessageLog> listMessageLog = new List<MessageLog>();
                        if (tableClient != null)
                        {
                            string filter = String.Format("(PartitionKey eq '{0}')", PartitionKey);
                            if (qualifier.Length > 0)
                            {
                                filter += qualifier;
                            }
                            var pages = tableClient.QueryAsync<MessageLog>(filter, maxPerPage: 1000).AsPages().ConfigureAwait(false);

                            //var messageLog = tableClient.Query<MessageLog>(filter);
                            await foreach (var page in pages)
                            {
                                listMessageLog.AddRange(page.Values.ToList());
                                token = page.ContinuationToken; // usage ?
                            }
                            listMessageLog.Reverse();
                            objResult = (Object)listMessageLog;
                        }
                        break;
                    case "SuttaInfo":
                        List<SuttaInfo> listSuttaInfo = new List<SuttaInfo>();
                        if (tableClient != null)
                        {
                            string filter = String.Format("(PartitionKey eq '{0}')", PartitionKey);
                            if (qualifier.Length > 0)
                            {
                                filter += String.Format(" and RowKey eq '{0}'", qualifier);
                            }
                            var pages = tableClient.QueryAsync<SuttaInfo>(filter, maxPerPage: 1000).AsPages().ConfigureAwait(false);
                            await foreach (var page in pages)
                            {
                                listSuttaInfo.AddRange(page.Values.ToList());
                                token = page.ContinuationToken; // usage ?
                            }
                            objResult = (Object)listSuttaInfo;
                        }
                        break;
                    case "UserPageActivity":
                        List<UserPageActivity> listUserPageActivity = new List<UserPageActivity>();
                        if (tableClient != null)
                        {
                            string filter = String.Format("(PartitionKey eq '{0}')", PartitionKey);
                            if (qualifier.Length > 0)
                                filter += String.Format(" and (AssignedTo eq '{0}')", qualifier);

                            var pages = tableClient.QueryAsync<UserPageActivity>(filter, maxPerPage: 1000).AsPages().ConfigureAwait(false);
                            await foreach (var page in pages)
                            {
                                listUserPageActivity.AddRange(page.Values.ToList());
                                token = page.ContinuationToken; // usage ?
                            }
                            objResult = (Object)listUserPageActivity;
                        }
                        break;
                    case "SuttaPageAssignment":
                        List<SuttaPageAssignment> listSuttaPageAssignment = new List<SuttaPageAssignment>();
                        if (tableClient != null)
                        {
                            string filter = string.Empty;
                            filter = String.Format("(PartitionKey eq '{0}')", PartitionKey);
                            if (qualifier != null && qualifier.Length > 0)
                            {
                                if (qualifier.Length > 0) filter += " and " + qualifier;
                                //filter += String.Format("RowKey eq '{0}'", qualifier);
                            }
                            var suttaInfo = tableClient.Query<SuttaPageAssignment>(filter);
                            foreach (var sutta in suttaInfo)
                            {
                                listSuttaPageAssignment.Add(sutta);
                            }
                            objResult = (Object)listSuttaPageAssignment;
                        }
                        break;
                    case "SuttaPageData":
                        List<SuttaPageData> listSuttaPageData = new List<SuttaPageData>();
                        if (tableClient != null)
                        {
                            string filter = String.Empty;
                            if (SubPartitionKey.Length > 0) filter = String.Format("(PartitionKey eq '{0}')", SubPartitionKey);
                            if (qualifier != null && qualifier.Length > 0)
                            {
                                filter += String.Format(" and (RowKey eq '{0}')", qualifier);
                            }
                            var pages = tableClient.QueryAsync<SuttaPageData>(filter, maxPerPage: 1000).AsPages().ConfigureAwait(false);
                            await foreach (var page in pages)
                            {
                                listSuttaPageData.AddRange(page.Values.ToList());
                                token = page.ContinuationToken;
                            }
                            objResult = (Object)listSuttaPageData;
                        }
                        break;
                    case "UpdateHistory":
                        Dictionary<string, UpdateHistory> dictUpdateHistory = new Dictionary<string, UpdateHistory>();
                        List<UpdateHistory> listUpdateHistory = new List<UpdateHistory>();
                        if (tableClient != null)
                        {
                            string filter = String.Format("(PartitionKey eq '{0}')", SubPartitionKey);
                            if (qualifier.Length> 0) { filter += " and " + qualifier; }
                            var updateHistories = tableClient.Query<UpdateHistory>(filter);
                            listUpdateHistory = (List<UpdateHistory>)updateHistories.ToList();
                            //foreach (UpdateHistory updateHistory in updateHistories)
                            //{
                            //    dictUpdateHistory.Add(updateHistory.RowKey, updateHistory);
                            //}
                            objResult = (Object)listUpdateHistory;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                //await Task.Yield();
                StatusCode = ProcessCatchErrorMessage(e.Message.Split('\n'));
            }
            return (Object)listObj;
        }
        //*******************************************************************
        //*** Convert dt string into local DateTime
        //*******************************************************************
        public DateTime GetLocalDateTime(string s)
        {
            string[] f = s.Split('-');
            int year = Convert.ToInt16(f[0].Substring(0, 4));
            int mon = Convert.ToInt16(f[0].Substring(4, 2));
            int day = Convert.ToInt16(f[0].Substring(6, 2));
            f = f[1].Split(':');
            int hr = Convert.ToInt16(f[0]);
            int min = Convert.ToInt16(f[1]);
            int pos = f[2].IndexOf('.');
            if (pos >= 0)
                f[2] = f[2].Substring(0, pos);
            int sec = Convert.ToInt16(f[2]);
            DateTime dt = new DateTime(year, mon, day, hr, min, sec).ToLocalTime();
            return dt;
        }
        //*******************************************************************
        //*** Add a table rec
        //*******************************************************************
        public async Task<Object> InsertTableRec(Object obj)
        {
            try
            {
                switch (PartitionKey)
                {
                    case "UserProfile":
                        UserProfile userProfile = (UserProfile)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<UserProfile>(userProfile).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "ActivityLog":
                        ActivityLog activity = (ActivityLog)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<ActivityLog>(activity).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "MessageLog":
                        MessageLog message = (MessageLog)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<MessageLog>(message).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "SuttaPageData":
                        SuttaPageData pages = (SuttaPageData)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<SuttaPageData>(pages).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "SuttaInfo":
                        SuttaInfo suttaInfo = (SuttaInfo)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<SuttaInfo>(suttaInfo).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "SuttaPageAssignment":
                        SuttaPageAssignment suttaPageAssignment = (SuttaPageAssignment)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<SuttaPageAssignment>(suttaPageAssignment).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "UserPageActivity":
                        UserPageActivity userPageActivity = (UserPageActivity)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<UserPageActivity>(userPageActivity).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "UpdateHistory":
                        UpdateHistory updateHistory = (UpdateHistory)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<UpdateHistory>(updateHistory).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                    case "KeyValueData":
                        KeyValueData keyValueData = (KeyValueData)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.AddEntityAsync<KeyValueData>(keyValueData).ConfigureAwait(false);
                            StatusCode = result.Status;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                StatusCode = ProcessCatchErrorMessage(e.Message.Split('\n'));
            }
            return obj;
        }
        //*******************************************************************
        //*** Update a table rec
        //*******************************************************************
        public async Task UpdateTableRec(Object obj)
        {
            try
            {
                switch (PartitionKey)
                {
                    case "UserProfile":
                        UserProfile rec = (UserProfile)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync<UserProfile>(rec, rec.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "MessageLog":
                        MessageLog msg = (MessageLog)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync<MessageLog>(msg, msg.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "SuttaPageAssignment":
                        SuttaPageAssignment sutta = (SuttaPageAssignment)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync(sutta, sutta.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "SuttaInfo":
                        SuttaInfo suttaInfo = (SuttaInfo)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync(suttaInfo, suttaInfo.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "SuttaPageData":
                        SuttaPageData suttaPageData = (SuttaPageData)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync(suttaPageData, suttaPageData.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "UserPageActivity":
                        UserPageActivity userPageActivity = (UserPageActivity)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync(userPageActivity, userPageActivity.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }break;
                    case "KeyValueData":
                        KeyValueData keyValueData = (KeyValueData)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.UpdateEntityAsync(keyValueData, keyValueData.ETag).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                StatusCode = ProcessCatchErrorMessage(e.Message.Split('\n'));
            }
            return;
        }
        //*******************************************************************
        //*** Delete a table rec
        //*******************************************************************
        public async Task DeleteTableRec(Object obj)
        {
            try
            {
                switch (PartitionKey)
                {
                    case "UserProfile":
                        UserProfile rec = (UserProfile)obj;
                        rec.PartitionKey = PartitionKey;
                        if (tableClient != null)
                        {
                            var result = await tableClient.DeleteEntityAsync(rec.PartitionKey, rec.RowKey).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "SuttaPageAssignment":
                        SuttaPageAssignment sutta = (SuttaPageAssignment)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.DeleteEntityAsync(sutta.PartitionKey, sutta.RowKey).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                    case "UserPageActivity":
                        UserPageActivity userPageActivity = (UserPageActivity)obj;
                        if (tableClient != null)
                        {
                            var result = await tableClient.DeleteEntityAsync(userPageActivity.PartitionKey, userPageActivity.RowKey).ConfigureAwait(false);
                            StatusCode = result.Status;
                            DBErrMsg = String.Empty;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                StatusCode = ProcessCatchErrorMessage(e.Message.Split('\n'));
            }
            return;
        }
        //*******************************************************************
        //*** ProcessCatchErrorMessage
        //*******************************************************************
        private void ProcessCatchErrorMessage1(string[] msg)
        {
            DBErrMsg = string.Empty;
            StatusCode = -1;
            if (msg.Length == 0) return;
            DBErrMsg = msg[0];
            var s1 = msg.Where(x => x.Contains("Status"));
            if (s1 != null)
            {
                var s = s1.ToArray()[0];
                int start = s.IndexOf(" ") + 1;
                int end = s.IndexOf(" ", start);
                if (end != -1)
                    StatusCode = Convert.ToInt16(s.Substring(start, end - start));
            }
        }
    }
    public class TipitakaFileStorage
    {
#nullable enable
        //string connectionString = "DefaultEndpointsProtocol=https;AccountName=dystorage2021;AccountKey=JopS1zXQXsvQNAAbAVRNIbY5qDzFeVyXzJgKwgpnYLsODtRfjIx5UDwr7J5EYit8aKMeCyPxdM12pz/6SYfBGQ==;TableEndpoint=https://dystorage2021.table.core.windows.net/;";
        string? connectionString = string.Empty;
        //https://docs.microsoft.com/en-us/dotnet/api/overview/azure/storage.files.shares-readme
        public int StatusCode = 0;
        public string DBErrMsg = string.Empty;
        string sourceDir;
#nullable disable
        public TipitakaFileStorage(string sourceDir)
        {
            try
            {
                if (ConfigurationManager.AppSettings != null)
                {
                    connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                }
            }
            catch(Exception) 
            {
                connectionString = "DefaultEndpointsProtocol=https;AccountName=dystorage2021;AccountKey=JopS1zXQXsvQNAAbAVRNIbY5qDzFeVyXzJgKwgpnYLsODtRfjIx5UDwr7J5EYit8aKMeCyPxdM12pz/6SYfBGQ==;TableEndpoint=https://dystorage2021.table.core.windows.net/;";
            }
            this.sourceDir = sourceDir;
        }
        public bool FileDownload(string dataType, int fileNo, int pgNo)
        {
            string shareName = "tipitaka-nissaya-files";
            string subDirName = dataType + "-" + fileNo.ToString("D3");
            string dirName = dataType + "\\" + subDirName;
            string fileName = subDirName + "-" + pgNo.ToString("D3") + ".jpg";
            string localFilePath = sourceDir + "\\" + fileName;
            DBErrMsg = string.Empty;

            if (connectionString!.Length == 0)
            {
                DBErrMsg = "No connection string to connect.";
                return false;
            }
            try
            {
                // Get a reference to a share
                ShareClient share = new ShareClient(connectionString, shareName);
                // Get a reference to a directory
                ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
                ShareFileClient file = directory.GetFileClient(fileName);
                // Download the file
                ShareFileDownloadInfo download = file.Download();
                using (FileStream stream = System.IO.File.OpenWrite(localFilePath))
                {
                    download.Content.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                DBErrMsg = ex.Message;
                return false;
                //string s = TipitakaDB.ProcessCatchErrorMessageStr(ex.Message.Split('\n'));
                //string[] f = s.Split("|");
                //if (f.Length == 2)
                //{
                //    StatusCode = Convert.ToInt32(f[0]);
                //    DBErrMsg = f[1];
                //}
            }
            return true;
        }
        public void SourceFileDownload(string dataType, string fileName)
        {
            string shareName = "tipitaka-nissaya-files";
            string subDirName = String.Format("{0}\\{0}-PDF", dataType);
            string dirName = dataType + "\\" + subDirName;
            string localFilePath = sourceDir + "\\" + fileName;
            DBErrMsg = string.Empty;

            if (connectionString!.Length == 0)
            {
                DBErrMsg = "No connection string to connect.";
                return;
            }
            try
            {
                // Get a reference to a share
                ShareClient share = new ShareClient(connectionString, shareName);
                // Get a reference to a directory
                ShareDirectoryClient directory = share.GetDirectoryClient(subDirName);
                ShareFileClient file = directory.GetFileClient(fileName);
                // Download the file
                ShareFileDownloadInfo download = file.Download();
                using (FileStream stream = System.IO.File.OpenWrite(localFilePath))
                {
                    download.Content.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                DBErrMsg = ex.Message;
                return;
            }
        }
    }
#nullable disable
}
