using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Order
{
    public class OrderDeliveryAddress
    {
        public int InvoiceDeliveryAddressId { get; set; }
        public Nullable<int> AddressType { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public string SpecialInstruction { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public string Address4 { get; set; }
        public Nullable<int> ContactId { get; set; }
        public string BranchName { get; set; }
        public string ContactName { get; set; }
        public string PostalCode { get; set; }
        public string Department { get; set; }
        public string Phone1 { get; set; }
        public string Extension1 { get; set; }
        public string Extension2 { get; set; }
        public Nullable<int> Regionid { get; set; }
        public Nullable<int> Statenewid { get; set; }
        public string DeliveryNRICno { get; set; }
        public string Dlat { get; set; }
        public string Dlon { get; set; }
        public string CD { get; set; }
    }
}