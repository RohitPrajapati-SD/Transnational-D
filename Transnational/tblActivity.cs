//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokenAuthenticationInWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblActivity
    {
        public int ActivityId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SalesCycleId { get; set; }
        public string ActivityDesc { get; set; }
        public Nullable<System.DateTime> ActivityStartDate { get; set; }
        public Nullable<System.DateTime> ActivityStartTime { get; set; }
        public Nullable<System.DateTime> ActivityEndDate { get; set; }
        public Nullable<System.DateTime> ActivityEndTime { get; set; }
        public string MemberComm { get; set; }
        public string LeaderComm { get; set; }
        public string TaskClose { get; set; }
        public string MemberAlert { get; set; }
        public string LeaderAlert { get; set; }
        public Nullable<int> AlertForId { get; set; }
        public Nullable<bool> NewActivity { get; set; }
        public string Status { get; set; }
        public Nullable<int> PActivityId { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    }
}