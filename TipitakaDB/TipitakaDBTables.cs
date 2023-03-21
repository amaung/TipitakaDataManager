using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace Tipitaka_DBTables
{
    public record UserProfile : ITableEntity
    {
        public string RowKey { get; set; } = default!;
        public string PartitionKey { get; set; } = default!;
        public string Name_E { get; set; } = default!;
        public string Name_M { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PID { get; set; } = default!;
        public string UserClass { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTimeOffset JoinedDate { get; init; } = default!;
        public string Remarks { get; set; } = default!;
        public DateTimeOffset LastLogin { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;

        public UserProfile()
        {
            RowKey = string.Empty;
            PartitionKey = string.Empty;
            Name_E = string.Empty;
            Name_M = string.Empty;
            Password = string.Empty;
            PID = string.Empty;
            UserClass = string.Empty;
            Status = string.Empty;
            Remarks = string.Empty;
        }
        public UserProfile(UserProfile u)
        {
            RowKey = u.RowKey;
            PartitionKey = u.PartitionKey;
            Name_E = u.Name_E;
            Name_M = u.Name_M;
            Password = u.Password;
            PID = u.PID;
            UserClass = u.UserClass;
            Status = u.Status;
            JoinedDate = u.JoinedDate;
            Remarks = u.Remarks;
            LastLogin = u.LastLogin;
            ETag = u.ETag;
            Timestamp = u.Timestamp;
        }
    }
    public record ActivityLog : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string UserID { get; init; } = default!;
        public string Activity { get; init; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record MessageLog : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string From { get; set; } = default!;
        public string To { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
        public string MsgType { get; set; } = default!;
        public bool Read { get; set; } = default;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record SuttaInfo : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public int StartPage { get; set; } = default!;
        public int EndPage { get; set; } = default!;
        public int Pages { get; set; } = default!;
        public string AssignedUsers { get; set; } = default!;
        public int AssignedPages { get; set; } = default!;
        public int PagesSubmitted { get; set; } = default!;
        public int PagesVerified { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record SuttaPageAssignment : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public int StartPage { get; set; } = default!;
        public int EndPage { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string AssignedTo { get; set; } = default!;
        public string AssignedBy { get; set; } = default!;
        public DateTime AssignedDate { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record SuttaPageData : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public int PageNo { get; set; } = default!;
        public string PageData { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string UserID { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record UpdateHistory : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string Data { get; set; } = default!;
        public string UserID { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record ProjectData : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string Category { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record UserPageActivity : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string AssignedTo { get; set; } = default!;
        public int NIS { get; set; } = default;
        public float TimeSpent { get; set; } = default!;
        public string Status { get; set; } = default!;
        public int TurnAroundTime { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime AssignedDate { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
    public record KeyValueData : ITableEntity
    {
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public string Value { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
}