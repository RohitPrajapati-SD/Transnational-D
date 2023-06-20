using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models.CRM
{
    public class AppVersion
    {
        public int AppVersionID { get; set; }
        public string version { get; set; }
        public string Remarks { get; set; }
        public string CD { get; set; }
    }
    public class EnquiryTypes
    {
        public int EnquiryTypeId { set; get; }
        public string EnquiryType { get; set; }
        public string CD { get; set; }
    }
    public class ContactUs
    {
        public string ContactId { set; get; }
        public string EnquiryTypeId { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OrderNo { get; set; }
        public string CD { get; set; }
    }
    public class CallbackRequest
    {
        public string ContactId { set; get; }
        public string EnquiryTypeId { get; set; }
        public string Details { get; set; }
        public string OrderNo { get; set; }
        //public string Priority { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string CD { get; set; }
    }
    public class FeedbackByUser
    {
        public string Feedback { get; set; }
        //public string BusinessLineId { get; set; }
        public float Rating { get; set; }
        public int ContactId { get; set; }
        public string CD { get; set; }
    }
    public class ScreenImageConduction
    {

        public string PageName { get; set; }
        public string CD { get; set; }
    }
    public class ScreenImage
    {

        public string ImagePath { get; set; }

    }
    public class FAQConduction
    {

        public string CD { get; set; }
        public int FAQId { get; set; }
    }
    public class FAQquestionAnsConduction
    {
        public int FAQId { get; set; }
        public string CD { get; set; }
    }
    public class AlertMasterCondition
    {
        public string CD { get; set; }
    }
    public class SaveNotification
    {
        public string CD { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public string DeviceId { get; set; }
        public string Status { get; set; }
        public int ContactId { get; set; }
    }
    public class DeliveryoptionsConduction
    {
        public string CD { get; set; }
    }
    public class Deliveryoptions
    {

        public int DeliveryOptionId { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

    }
    public class AlertMaster
    {
        public string AlertStartDate { get; set; }
        public string AlertEndDate { get; set; }
        public string AlertStartTime { get; set; }
        public string AlertEndTime { get; set; }
        public string AlertMessage { get; set; }
        public string Status { get; set; }
    }
    public class UserDevice
    {
        public string EmailId { get; set; }
        public string DeviceId { get; set; }
        public int ContactId { get; set; }
        public string CD { get; set; }
        public string LogIn_LogOut { get; set; }

    }
    public class StatusMaster
    {
        public string CD { get; set; }


    }
    public class CouponMasterParameter
    {
        public string CD { get; set; }
        public string CouponCode { get; set; }
    }

    /*GetAllCouponLis*/
    public class CouponListMaster
    {
        public string CouponCode { get; set; }
        public string CouponName { get; set; }
        public float Amount { get; set; }
        public string AmountType { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public string Status { get; set; }
        public string CouponImage { get; set; }
       //public int CompanyId { get; set; }
        //public int ContactId { get; set; }
    }
    public class CouponlistDetail
    {
        public string CD { get; set; }
    }
}
      



