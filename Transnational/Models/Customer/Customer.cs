using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models
{
    public class Customers
    {
        public int CompanyId { get; set; }
        public Nullable<int> ContactTypeId { get; set; }
        public string CompanyName { get; set; }
        public string NickName { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Tel4 { get; set; }
        public string Fax { get; set; }
        public string Fax2 { get; set; }
        public string Fax3 { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> CustomerGroupId { get; set; }
        public Nullable<int> CustomerCategoryId { get; set; }
        public Nullable<int> CustomerTypeId { get; set; }
        public Nullable<int> KeyAccountManager { get; set; }
        public Nullable<int> AccessRightsId { get; set; }
        public Nullable<int> EnquirySourceId { get; set; }
        public string EnquirySourceName { get; set; }
        public Nullable<int> CustomerStatusId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Portfolio { get; set; }
        public Nullable<float> BankId { get; set; }
        public Nullable<float> BankBranchId { get; set; }
        public string BankAcctId { get; set; }
        public string NricNo { get; set; }
        public string Employeeof { get; set; }
        public string Remark { get; set; }
        public string Gender { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Mobile3 { get; set; }
        public string Mobile4 { get; set; }
        public string Office1 { get; set; }
        public string Office2 { get; set; }
        public string Office3 { get; set; }
        public string CustNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string Phone2 { get; set; }
        public string Extension1 { get; set; }
        public string Extension2 { get; set; }
        public Nullable<System.DateTime> LUDate { get; set; }
        public Nullable<int> LUBy { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<System.DateTime> ActiveSince { get; set; }
        public string ASReason { get; set; }
        public Nullable<System.DateTime> UnFreezeSince { get; set; }
        public string UFReason { get; set; }
        public Nullable<bool> ICompanySales { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Freeze { get; set; }
        public string CompanyLogo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string Abbreviation { get; set; }
        public Nullable<double> CreditAmount { get; set; }
        public Nullable<double> DepositAmount { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<bool> SendSms { get; set; }
        public Nullable<bool> SendEmail { get; set; }
        public Nullable<bool> CCenter_on_orderPage { get; set; }

    }


    public class Department
    {
        public int ContractId { get; set; }

        public int ContactId { get; set; }
        public int CBranchId { get; set; }
        public string BranchName { get; set; }

    }
    //==============================CompanyBranch======================================================


    public class CompanyBranch
    {
        public int CBranchId { get; set; }

        public Nullable<int> CompanyId { get; set; }
        public string BranchName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public Nullable<int> CityId { get; set; }
        public string PinCode { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string BranchHead { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string Address4 { get; set; }
        public string NickName { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public string NewBranchId { get; set; }
        public string Phone1 { get; set; }
        public string Extension1 { get; set; }
        public string Extension2 { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<bool> Billable { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> LUDate { get; set; }
        public Nullable<int> LUBy { get; set; }
        public Nullable<System.DateTime> ActiveSince { get; set; }
        public string ASReason { get; set; }
        public Nullable<System.DateTime> UnFreezeSince { get; set; }
        public string UFReason { get; set; }
        public Nullable<int> HigherLevel { get; set; }
        public string CCNo { get; set; }
        public string LevelNo { get; set; }
        public Nullable<bool> DActive { get; set; }
        public Nullable<bool> DFreeze { get; set; }
        public string LoginQPin { get; set; }
        public string DLUByType { get; set; }
        public Nullable<int> ApprovalLevel1 { get; set; }
        public Nullable<int> ApprovalLevel2 { get; set; }
        public Nullable<int> ApprovalLevel3 { get; set; }
        public string DCreatedByType { get; set; }
        public string ContactName { get; set; }
        public string Department { get; set; }
        public Nullable<int> Regionid { get; set; }
        public Nullable<int> Stateid { get; set; }
        public string Delivery { get; set; }
        public string Collection { get; set; }
        public string BLatitude { get; set; }
        public string BLongitude { get; set; }

    }

    //==========================================CompanyAddressBook[=====================================

    public partial class DContactAddress
    {
        public int CABid { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string CostCenterName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public Nullable<int> Countryid { get; set; }
        public Nullable<int> Regionid { get; set; }
        public Nullable<int> Stateid { get; set; }
        public Nullable<int> Cityid { get; set; }
        public Nullable<int> Zoneid { get; set; }
        public Nullable<int> Districtid { get; set; }
        public string PostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public Nullable<int> ContactId { get; set; }
        public string Collection { get; set; }
        public string Delivery { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Department { get; set; }
        public string Collection_Instruction { get; set; }
        public Nullable<int> CBranchId { get; set; }
        public string BranchName { get; set; }
        public string ALatitude { get; set; }
        public string ALongitude { get; set; }
    }

    //===============================================CContactAddress==========================================
    //public partial class DContactAddress

    //{
    //    public int CABid { get; set; }
    //    public Nullable<int> CustomerId { get; set; }
    //    public string CostCenterName { get; set; }
    //    public string Address1 { get; set; }
    //    public string Address2 { get; set; }
    //    public string Address3 { get; set; }
    //    public string Address4 { get; set; }
    //    public Nullable<int> Countryid { get; set; }
    //    public Nullable<int> Regionid { get; set; }
    //    public Nullable<int> Stateid { get; set; }
    //    public Nullable<int> Cityid { get; set; }
    //    public Nullable<int> Zoneid { get; set; }
    //    public Nullable<int> Districtid { get; set; }
    //    public string PostalCode { get; set; }
    //    public string ContactName { get; set; }
    //    public string ContactNumber1 { get; set; }
    //    public string ContactNumber2 { get; set; }
    //    public Nullable<int> ContactId { get; set; }
    //    public string Collection { get; set; }
    //    public string Delivery { get; set; }
    //    public string Ext1 { get; set; }
    //    public string Ext2 { get; set; }
    //    public string Department { get; set; }
    //    public string Collection_Instruction { get; set; }
    //    public Nullable<int> CBranchId { get; set; }
    //    public string BranchName { get; set; }
    //    public string ALatitude { get; set; }
    //    public string ALongitude { get; set; }
    //}

    public partial class CContactAddress
    {

        public string BranchName { get; set; }
        public string CostCenterName { get; set; }


    }
    public partial class Contacts
    {
        internal string contactName;

        public int ContactId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public string PinCode { get; set; }
        public string NickName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string DesignationId { get; set; }
        public string Department { get; set; }
        public string YOG { get; set; }
        public string Tel { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Nullable<int> RaceId { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public Nullable<int> KeyAccountManger { get; set; }
        public Nullable<int> ContactAccountManager { get; set; }
        public Nullable<bool> SyncWithOutlook { get; set; }
        public Nullable<System.DateTime> Anniversary { get; set; }
        public Nullable<int> EnquirySourceId { get; set; }
        public string EnquirySourceName { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> Block { get; set; }
        public string Division { get; set; }
        public Nullable<bool> DContact { get; set; }
        public string Section { get; set; }
        public string Gender { get; set; }
        public string CPassword { get; set; }
        public string Extension2 { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
        public string Extension1 { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LUDate { get; set; }
        public Nullable<int> LUBy { get; set; }
        public Nullable<int> CBranchId { get; set; }
        public string CostCenterId { get; set; }
        public string Fax { get; set; }
        public Nullable<System.DateTime> ActiveFrom { get; set; }
        public Nullable<System.DateTime> ActiveTo { get; set; }
        public Nullable<System.DateTime> test { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedByType { get; set; }
        public string LUByType { get; set; }
        public string ContactType { get; set; }
        public Nullable<System.DateTime> PasswordRenewdate { get; set; }
        public Nullable<bool> RenewStatus { get; set; }
        public Nullable<int> IntervalInDay { get; set; }
        public Nullable<bool> tempPassFlg { get; set; }
        public Nullable<int> Regionid { get; set; }
        public Nullable<int> Zoneid { get; set; }
        public string Collection { get; set; }
        public string Delivery { get; set; }
        public string CLoginQPin { get; set; }
        public string FAddress { get; set; }
        public int Count { get; set; }
        public string BranchName { get; internal set; }
       

    }
    public partial class CompanyAddressBooks
    {
        public int CABid { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string CostCenterName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public Nullable<int> Countryid { get; set; }
        public Nullable<int> Regionid { get; set; }
        public Nullable<int> Stateid { get; set; }
        public Nullable<int> Cityid { get; set; }
        public Nullable<int> Zoneid { get; set; }
        public Nullable<int> Districtid { get; set; }
        public string PostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public Nullable<int> ContactId { get; set; }
        public string Collection { get; set; }
        public string Delivery { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Department { get; set; }
        public string Collection_Instruction { get; set; }
        public Nullable<int> CBranchId { get; set; }
        public string BranchName { get; set; }
        public string ALatitude { get; set; }
        public string ALongitude { get; set; }
        public int Count { get; set; }
        
    }
    public partial class CompanyContactAddress
    {
        public int CCAid { get; set; }
        public Nullable<int> AddressBookid { get; set; }
        public Nullable<int> Contactid { get; set; }
        public Nullable<bool> Collection { get; set; }
        public Nullable<bool> Delivery { get; set; }

    }
}












    

    

