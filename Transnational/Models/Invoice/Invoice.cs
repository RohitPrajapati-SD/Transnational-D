using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models
{
    public class Invoices
    {
            internal string PostalCode;

        public int InvoiceId { get; set; }
        public Nullable<int> EnquiryId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> PrintDate { get; set; }
        public Nullable<int> CreditTermCode { get; set; }
        public Nullable<float> InvoiceAmount { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<float> BalanceAmount { get; set; }
        public Nullable<float> AmountReceived { get; set; }
        public string CompanyId { get; set; }
        public string Note { get; set; }
        public string OrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> SODate { get; set; }
        public string DRemark { get; set; }
        public Nullable<System.DateTime> BatchDate { get; set; }
        public Nullable<int> SalesPersonId { get; set; }
        public Nullable<int> OStatus { get; set; }
        public Nullable<bool> Submit { get; set; }
        public string ReceiptNo { get; set; }
        public string SosofNo { get; set; }
        public Nullable<System.DateTime> PickupDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string PickupTime { get; set; }
        public string DeliveryTime { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Volume1 { get; set; }
        public Nullable<double> Volume2 { get; set; }
        public Nullable<double> Volume3 { get; set; }
        public Nullable<double> EstimatedCost { get; set; }
        public Nullable<int> BillTo { get; set; }
        public string SpecialInstructions { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public string CreatedByType { get; set; }
        public string UpdatedByType { get; set; }
        public Nullable<int> ReturnOrderId { get; set; }
        public string BillToType { get; set; }
        public string approve { get; set; }
        public string OrderType { get; set; }
        public string OrderTypeNo { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public string ApprovedByType { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ApprovedDateTime { get; set; }
        public Nullable<bool> ReturnService { get; set; }
        public Nullable<int> CBranchId { get; set; }
        public string AlternateRefNo { get; set; }
        public string RequestorName { get; set; }
        public Nullable<int> QuantityUomId { get; set; }
        public string ContractCostCntrDprt { get; set; }
        public string receiptFile { get; set; }
        public string parentChild { get; set; }
        public string BillToVal { get; set; }
        public string WalkInFlag { get; set; }
        public Nullable<bool> PaidFlag { get; set; }
        public string CreatedFrom { get; set; }
        public string ContentFile { get; set; }
        public string ReferenceNumber { get; set; }
        public string RequestorContact { get; set; }
        public Nullable<int> BatchId { get; set; }
        public string ItemType { get; set; }
        public Nullable<bool> SwapAddress { get; set; }
        public string Record_Type { get; set; }
        public string LI { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public string Cust_Reference { get; set; }
        public string Aano { get; set; }
        public string Segment { get; set; }
        public string Segment1 { get; set; }
        public string OEmail { get; set; }
        public string OMobile { get; set; }
        public string OWeightUOM { get; set; }
        public string OVolumeUOM { get; set; }
        public Nullable<int> WinPeriodId { get; set; }
        public string BranchName { get; internal set; }
        public string Department { get; internal set; }
        public string ContactName { get; internal set; }
        public string Address { get; internal set; }
        public string Address2 { get; internal set; }
        public string Address3 { get; internal set; }
        public string Address4 { get; internal set; }
        public int CountryId { get; internal set; }
        public int StateId { get; internal set; }
        public int DistrictId { get; internal set; }
        public int CityId { get; internal set; }
        public int SpecialInstruction { get; internal set; }
        public string Phone { get; internal set; }
        public string Phone1 { get; internal set; }
        public string Extension1 { get; internal set; }
        public string Extension2 { get; internal set; }
    }
    public partial class InvoiceAddress
    {
        public int InvoiceAddressId { get; set; }
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
        public string CollectionNRICno { get; set; }

        public string Lat { get; set; }
        public string Lon { get; set; }




    }
    public partial class InvoiceDeliveryAddresses
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
        public string DLat { get; set; }
        public string DLon { get; set; }
    }
    public partial class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public string InvoiceId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> Qty { get; set; }
        public string ServiceType { get; set; }
    }

}
    
