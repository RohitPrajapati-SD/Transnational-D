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
    
    public partial class tblContractServiceRateMatrix
    {
        public int ContractrateMatrixId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> SeqNo { get; set; }
        public Nullable<int> CityIdFrom { get; set; }
        public Nullable<int> CityIdTo { get; set; }
        public Nullable<double> rate { get; set; }
        public string WeightFrom { get; set; }
        public string WeightTo { get; set; }
        public string FlatRate { get; set; }
        public string RType { get; set; }
        public string ItemType { get; set; }
        public string chargeType { get; set; }
        public Nullable<double> SubsequentWeight { get; set; }
        public Nullable<double> SubsequentRate { get; set; }
    }
}