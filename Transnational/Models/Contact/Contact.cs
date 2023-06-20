using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.Contact
{

    public class ContactAddress
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
        public string AddressName { get; set; }
        public string DefaultAddress { get; set; }
        public string DefaultShipping { get; set; }
        public string DefaultBilling { get; set; }





        public string CD { get; set; }
    }
    public class ContactAddressBookDelete
    {
        public int CABId { get; set; }

        public string CD { get; set; }
    }
    public class ContactAddressConduction
    {
        public int ContactId { get; set; }

        public string DefaultAddress { get; set; }

        public int CompanyAddressBookId { get; set; }

        public string CD { get; set; }
    }
    public class OldpasswordbyContactIdConduction
    {

        public int ContactId { get; set; }
        //public string Password { set; get; }
        public string CD { get; set; }

    }
    public class OldpasswordbyContactId
    {
        public string CPassword { set; get; }

    }
    public class UpdateOldpasswordbyContactId
    {
        public string CPassword { set; get; }
        public int ContactId { get; set; }
        public string CD { get; set; }
    }
    //public class EnquiryTypes
    //{
    //    public int EnquiryTypeId { set; get; }
    //    public string EnquiryType { get; set; }
    //    public string CD { get; set; }
    //}
    //public class ContactUs
    //{
    //    public string ContactId { set; get; }
    //    public string EnquiryTypeId { get; set; }
    //    public string Details { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string CD { get; set; }
    //}
    //public class CallbackRequest
    //{
    //    public string ContactId { set; get; }
    //    public string EnquiryTypeId { get; set; }
    //    public string Details { get; set; }
    //    //public string Status { get; set; }
    //    //public string Priority { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }

    //    public string CD { get; set; }
    //}
    public class ContactProfileByContactId
    {
        public string ContactId { set; get; }
        public string FirstName { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int CountryId { get; set; }
        public int Cityid { get; set; }
        public int DistrictId { get; set; }
        public int Zoneid { get; set; }
        public int StateId { get; set; }
        public string Mobile { get; set; }
        //public string CompanyName { get; set; }
        public string CD { get; set; }
    }
    public class ContactDefaultAddressMode
    {
        public int CABid { set; get; }
        public string DefaultAddress { set; get; }
        public string CD { get; set; }
    }

    //---------------------------------------------------------InsertContactRegistration-------------------------------------------//---
    public class ContactRegistration
    {
        public string CustomerId { set; get; }
        public int CountryId { set; get; }
        public string DDLCode { set; get; }

        public int ContactId { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string CPassword { set; get; }
        public string CD { get; set; }
        public InsertLogin InsertLoginObj { get; set; }

    }

    public class DbName
    {
        public string dbName { get; set; }

    }

    public class InsertLogin
    {

        public string EmailId { set; get; }
        public string MobileNo { set; get; }
        public string UserId { set; get; }
        public string DatabaseName { set; get; }

        public string CD { get; set; }
    }
    public class ContactprofilebycontactId_Pic_Conduction
    {

        public int ContactId { set; get; }
        public string CD { get; set; }




    }
    public class ContactprofilebycontactId_Pic
    {

        public string ImageString { get; set; }
    }

    public class PaymentMethodConduction
    {

        public int ContactId { set; get; }
        public int ContractId { set; get; }
        public string CD { get; set; }
    }
    public class PaymentMethod
    {
        public int ContactPaymentMethodId { set; get; }
        public int PaymentMethodId { set; get; }
        public int ContactId { set; get; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int ContractId { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodImage { get; set; }
        public string DefaultPaymentMethod { get; set; }


        public string CD { get; set; }
    }
    //public class PaymentMethods
    //{
    //    public int ContactPaymentMethodId { set; get; }
    //    public int PaymentMethodId { set; get; }
    //    public int ContactId { set; get; }
    //    public string CardHolderName { get; set; }
    //    public string CardNumber { get; set; }
    //    public string Month { get; set; }
    //    public string Year { get; set; }
    //    public int ContractId { get; set; }
    //    public string PaymentMethodName { get; set; }
    //    public string PaymentMethodImage { get; set; }
    //    public string DefaultPaymentMethod { get; set; }


    //    public string CD { get; set; }
    //}

    public class ContactPaymentMethodConduction
    {

        public int ContactId { set; get; }
      
        public string CD { get; set; }
    }
    public class ContactPaymentMethod
    {
        
        public int ContactPaymentMethodId { set; get; }
        public int PaymentMethodId { set; get; }
        public int ContactId { set; get; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodImage { get; set; }
        public string DefaultPaymentMethod { get; set; }

       
    }
    public class EmailVerifications
    {
        public string Email { set; get; }
        public string OTP { set; get; }
        //public int isPublic { set; get; }
        public string CD { get; set; }


    }
}