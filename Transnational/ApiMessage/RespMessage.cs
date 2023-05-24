using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.ApiMessage
{
    public class RespMessage
    {
        public const string InvalidReq = "Invalid request !";
        public const string OTPUpdate = "OTP! Updated successfully";
        public const string OrderCreate = " Order created successfully";
        public const string Delete = " Data deleted successfully ";
        public const string DataSave = " Data Saved successfully ";



        public const string ServerError = "Server Error !";
        public const string ServerErrorWithEx = "Server Error !{0}";
        public const string LoginSuccess = "Logged in successfully.";
        public const string LoginFailed = "Falscher Pin wurde eingegeben.";
        public const string LoginFailed_App = "Wrong pin was entered.";
        public const string ActivationSuccess = "Your account has been activated successfully.";
        public const string AlreadyActivated = "Your account already activated.";
        public const string ActivationFailed = "Falscher Pin wurde eingegeben.";
        public const string LogoutSuccess = "Logged out successfully";
        public const string Success = " successfully.";
        public const string ChangePassword = "Change Password successfully.";
        public const string OTPUpdated = "OTP Updated successfully.";
        public const string UpdateImage = "Image Update successfully.";
        public const string Update = " Updated successfully.";

        public const string Fail = " Fail.";
        public const string DataSuccess = "Data fetched successfully";
        public const string DataNotFound = "No records found.";
        public const string TrackingStarted = "Tracking Started Successfully";
        public const string Unsuccessful = "Sorry! login Unsuccessfully";
        public const string TrackingPaused = " Tracking paused successfully";
        public const string TrackingResumed = " Tracking resumed successfully";
        public const string TrackingStopped = " Tracking stopped successfully";
        public const string TrackingSaved = " Tracking saved successfully";

        public const string AlreadyWorking =
            "A running session already exist on another property. Do you want to stop session and log out from that property?";

        public const string AlreadyLogin =
            "You are already login to other device.Do you want to log out of the device?";

        public const string AlreadyExist = "{0} Already exist.";
        public const string Activated = "{0} Activated successfully.";
        public const string Inactivated = "{0} Deactivated successfully.";
        public const string Cancelled = "Order Cancelled  successfully.";
         public const string ContractBillingDetail = "Billing Details.";
        public const string Deactivated =
            "Your account has been deactivated by admin. Please contact admin to activate your account.";

        public const string AccountDeleted =
            "Your account has been deleted by admin. Please contact admin to add your account.";

        public const string Logout_Failed = "Logout failed.";
        public const string InvalidFile = "Upload data in valid file format.";
        public const string InvalidCredential = "Email or password is not valid.";
        public const string WrongActivationPin = "Wrong activation pin.";
        public const string AlreadyWorking_Logout = "There is already a running session. Please login again.";
        public const string AssignRequestStaff = "Request Successful.";
        public const string RequestAlreadyConverted = "This request has been already converted with offer.";
        public const string OfferAlreadyConverted = "This Offer has been already converted with order.";
        public const string SalesTemplateSetting = "Sales template is not generated yet,please create it first.";
        public const string EmailSent = "Email sent successfully.";

        public static string FormatMessage(string message, params string[] args)
        {
            return String.Format(message, args);
        }

        public const string DirectoryName = "~/CsvSampleFiles/";
        public const string UploadDirectoryName = "~/CsvUploadFiles/";
    }
}