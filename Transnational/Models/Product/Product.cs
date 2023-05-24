using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Products
{
    public class Products
    {
        public int SeqNo { get; set; }
        public string ServiceName { get; set; }
    
    }


    public partial class ProductPrices
    {
        public int SeqNo { get; set; }
        public string InventoryId { get; set; }
        public string ServiceName { get; set; }
        public Nullable<float> BranchId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<double> PurchasePrice { get; set; }
        public Nullable<double> NewPrice { get; set; }
        public Nullable<double> ProfitFactor { get; set; }
        public Nullable<double> ReniewalPrice { get; set; }
        public Nullable<double> Price3 { get; set; }
        public Nullable<double> Price4 { get; set; }
        public Nullable<double> Price5 { get; set; }
        public Nullable<float> CustomerTypeId { get; set; }
        public Nullable<float> CurrencyId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EstStartDate1 { get; set; }
        public Nullable<int> PPeriod { get; set; }
        public string Term { get; set; }
        public string Issue { get; set; }
        public string OrdType { get; set; }
        public string SpecialCode1 { get; set; }
        public string SpecialCode2 { get; set; }
        public string FGID { get; set; }
        public string OldFGID { get; set; }
        public string PRQ1 { get; set; }
        public string PRQ2 { get; set; }
        public string PRQ3 { get; set; }
        public int LanguageId { get; set; }
        public string ServiceImage { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> MinOrder { get; set; }
        public Nullable<bool> ClientOrderScreen { get; set; }
        public Nullable<bool> InclusiveTax { get; set; }
        public Nullable<bool> ApplyRateMatrix { get; set; }
        public Nullable<bool> PublicHoliday { get; set; }
        public Nullable<bool> Weekday { get; set; }
        public Nullable<bool> Weekend { get; set; }
        public Nullable<bool> Miscellaneous { get; set; }
        public Nullable<bool> ReturnService { get; set; }
        public string UOM { get; set; }
        public Nullable<bool> Eprocurment { get; set; }
        public Nullable<int> availqty { get; set; }
        public string ServiceUniqueId { get; set; }
        public Nullable<double> Weight { get; set; }
        public string WeightUOM { get; set; }
        public Nullable<double> Volume1 { get; set; }
        public Nullable<double> Volume2 { get; set; }
        public Nullable<double> Volume3 { get; set; }
        public string VolumeUOM { get; set; }
        public Nullable<int> ReOrderQuantity { get; set; }
        public string OrderType { get; set; }
        public string CNTypeNO { get; set; }
        public Nullable<double> Deliveryduration { get; set; }
        public Nullable<System.DateTime> CutOffTime { get; set; }
        public Nullable<bool> AfterOfzHour { get; set; }
        public Nullable<int> BusinessUnit { get; set; }
        public Nullable<bool> CasePayment { get; set; }
        public Nullable<bool> InputPContent { get; set; }
        public Nullable<int> tax { get; set; }
        public string priorityType { get; set; }
        public string itemType { get; set; }
        public string orderFormType { get; set; }
        public Nullable<bool> clientOScreen { get; set; }
        public Nullable<bool> after_office_hours { get; set; }
        public Nullable<bool> cashpayment { get; set; }
        public Nullable<bool> InputPContant { get; set; }
        public Nullable<int> ReturnServiceType { get; set; }
    }
}

