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
    
    public partial class tblTimeSheet
    {
        public int TimeSheetId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string TSDescription { get; set; }
        public Nullable<System.DateTime> TSDate { get; set; }
        public Nullable<System.DateTime> TimeFrom { get; set; }
        public Nullable<System.DateTime> TimeTo { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    }
}