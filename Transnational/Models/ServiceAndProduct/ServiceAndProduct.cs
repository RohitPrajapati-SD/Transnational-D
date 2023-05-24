using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.ServiceAndProduct
{
    public class BusinesslineByContactConduction
    {

        public int CompanyId { get; set; }
        public int ContactId { get; set; }
        public int LanguageId { get; set; }
        public string CD { get; set; }
    }
    public class BusinesslineByContact
    {
        public int BusinessLineId { get; set; }
        public string BusinessLine { get; set; }
        public string PictureFileName { get; set; }
        public string IconFileName { get; set; }
        public Double LevelId { get; set; }
        public int CompanyId { get; set; }
        public string SubscriptionStatus { get; set; }
        public String Description { get; set; }
        

    }
    public class ContractByBusinessLineId_CompanyIdConduction
    {

        public int ContactId { get; set; }
        public int BusinessLineId { get; set; }
        public string CD { get; set; }
    }

    public class ContractByBusinessLineId_CompanyId
    {

        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public string ContractNo { get; set; }
        public string ContractDescription { get; set; }
        public int BusinessLineId { get; set; }
        public int SubBusinessLineId { get; set; }
        public string BillingEmail { get; set; }
        public string BillingAddress { get; set; }

    }
    public class InsertBusinesslineSubcribion
    {

        public int ContactId { get; set; }
        public int BusinessLineId { get; set; }
        public string CD { get; set; }

        //public string ContractNo { get; set; }
        //public string ContractDescription { get; set; }
        //public int BusinessLineId { get; set; }
        //public int SubBusinessLineId { get; set; }

    }
    public class ServicesByContractConduction
    {
        public int ContractId { get; set; }
        public int ContactId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public int CityIdFrom { get; set; }
        public int CityIdTo { get; set; }
        public string CD { get; set; }
    }
    public class ServicesByContract
    {

        public string BusinessLine { get; set; }
        public string SubBusinessLine { get; set; }
        public int ServiceId { get; set; }                                 
        public string ServiceName { get; set; }
        public double NewPrice { get; set; }
        public bool IsSelected { get; set; }
        public int ServiceUnavailableID { get; set; }
        public bool ReturnService { get; set; }
        public int ReturnServiceType { get; set; }
        
    }
    public class ProductConduction
    {

        public int LevelId { get; set; }
        public int LanguageId { get; set; }

        public string SubBusinessLineId { get; set; }

        public string CD { get; set; }

        public Nullable <int> CompanyId { get; set; }
        public Nullable<int> ContactId { get; set; }
        public int IsPublic { get; set; }
        public List<SubBusinessLineIds> SubBusinessLineIdsObjlst { get; set; }
        public double RateFrom { get; set; }
        public double RateTo { get; set; }

    }
    public class SubBusinessLineIds
    {
        public string SubBusinessLineId { get; set; }

    }



    public class Products
    {
        public object ProductAnnouncementId { get; set; }
        public int BusinessLineId { get; set; }
        public string BusinessLine { get; set; }
        public int SubBusinessLineId { get; set; }
        public string SubBusinessLine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ProductAnnouncementDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public double NewPrice { get; set; }
        public int ContractId { get; set; }
        public string AccessRight { get; set; }
      
        //public string ProductAnnounceMentImage { get; set; }

        




    }
    public class AddtoMyCart
    {
        public int CartId { get; set; }
        public int CartUserId { get; set; }
        public int ProductId { get; set; }
        public Double Qty { get; set; }
        public double Rate { get; set; }
        public string Status { get; set; }
        public string item_Mode { get; set; }
        public string CD { get; set; }
        public int ContractId { get; set; } 



    }
    public class MyCartItemConduction
    {

        public int CartUserId { get; set; }
        public string CD { get; set; }
    }
    public class MyCartItem
    {

        public int CartId { get; set; }
        public int CartUserId { get; set; }
        public int ProductId { get; set; }
        public Double Qty { get; set; }
        public Double Rate { get; set; }
        public string ProductName { get; set; }
        public double NewPrice { get; set; }
        public string ServiceImage { get; set; }

    }

    public class ProductAnnouncementConduction
    {
        public string CD { get; set; }
    }
    public class ProductAnnouncement
    {
        public int ProductAnnouncementId { get; set; }
        public int BusinessLineId { get; set; }
        public string BusinessLine { get; set; }
        public int SubBusinessLineId { get; set; }
        public string SubBusinessLine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int ProductId { get; set; }
        //public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductAnnouncementDescription { get; set; }
        public string ShortDescription { get; set; }
        //public string ProductImage { get; set; }
        public string Status { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public double NewPrice { get; set; }
        public int ContractId { get; set; }
        public string AccessRight { get; set; }


    }
    public class DeleteMyCart
    {

        public int CartId { get; set; }
        public string CD { get; set; }
    }
    public class ProductRatingConduction
    {

        public int ProductId { get; set; }
        public string CD { get; set; }
    }
    public class ProductRating
    {

        public int ProductId { get; set; }
        public Double Rating { get; set; }
        public int Total { get; set; }
        public int percentage { get; set; }
    }
    public class SubBusinessLineConduction
    {

        public int LevelId { get; set; }
        public int LanguageId { get; set; }
        public string ProductType { get; set; }

        public string CD { get; set; }
    }
    public class SubBusinessLines
    {

        public int BusinessLineId { get; set; }
        public string BusinessLine { get; set; }
        public int SubBusinessLineId { get; set; }
        public string SubBusinessLine { get; set; }


    }
    public class AllServices
    {
        public string CD { get; set; }
    }
}




