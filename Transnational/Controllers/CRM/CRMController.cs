using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Models.CRM;
using Transnational.Repository.CRM;
using Transnational.Service;
using Transnational.VM;

namespace Transnational.Controllers.CRM
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CRMController : ApiController
    {
        static CRMRepository CRMRepositoryobj = new CRMRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/CRM/GetAllAppVersion")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<AppVersion>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllAppVersion(AppVersion AppVersionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<AppVersion>> response = new ResponseStatus<List<AppVersion>>();
            List<AppVersion> AppVersionobj = new List<Models.CRM.AppVersion>();
            try
            {


                ds = CRMRepositoryobj.GetAllAppVersion(AppVersionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var AppVersionObjItem = new AppVersion()
                        {
                            AppVersionID = (int)dr["AppVersionID"],
                            version = (string)dr["version"],
                            Remarks = (string)dr["Remarks"],


                        };
                        AppVersionobj.Add(AppVersionObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, AppVersionobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AppVersion>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, AppVersionobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AppVersion>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), AppVersionobj);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/Contact/GetAllEnquiryType")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<EnquiryTypes>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllEnquiryType(EnquiryTypes EnquiryTypesObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<EnquiryTypes>> response = new ResponseStatus<List<EnquiryTypes>>();
            List<EnquiryTypes> EnquiryTypeObj = new List<Models.CRM.EnquiryTypes>();

            try
            {
                //string CD = obj.CD;
                //if (dbParam == "Teamwork-SG-v2UAT")
                //{
                ds = CRMRepositoryobj.GetAllEnquiryType(EnquiryTypesObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactAddressObjItem = new EnquiryTypes()
                        {
                            EnquiryTypeId = (int)dr["EnquiryTypeId"],
                            EnquiryType = (string)dr["EnquiryType"],
                        };
                        EnquiryTypeObj.Add(ContactAddressObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, EnquiryTypeObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<EnquiryTypes>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), EnquiryTypeObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<EnquiryTypes>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, EnquiryTypeObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<EnquiryTypes>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/insertContactUs")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult insertContactUs(ContactUs ContactUsObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Contactusobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = CRMRepositoryobj.insertContactUs(ContactUsObj);

                if (result == true)
                {
                    response = response.Create(true, "Data save Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Contactusobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/insertCallbackRequests")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult insertCallbackRequest(CallbackRequest CallbackRequestObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object CallbackRequestobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = CRMRepositoryobj.insertCallbackRequest(CallbackRequestObj);

                if (result == true)
                {
                    response = response.Create(true, "Data save Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CallbackRequestobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/InsertFeedbackByUser")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult InsertFeedbackByUser(FeedbackByUser FeedbackByUserObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object FeedbackByUserobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = CRMRepositoryobj.InsertFeedbackByUser(FeedbackByUserObj);

                if (result == true)
                {
                    response = response.Create(true, "Data save Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, FeedbackByUserobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        [System.Web.Http.Route("api/CRM/GetScreenImage")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ScreenImage>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetScreenImage(ScreenImageConduction ScreenImageObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ScreenImage>> response = new ResponseStatus<List<ScreenImage>>();
            List<ScreenImage> ScreenImageobj = new List<Models.CRM.ScreenImage>();
            try
            {


                ds = CRMRepositoryobj.GetScreenImage(ScreenImageObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ScreenImageObjItem = new ScreenImage()
                        {

                            ImagePath = (string)dr["ImagePath"],
                        };
                        ScreenImageobj.Add(ScreenImageObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ScreenImageobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ScreenImage>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, ScreenImageobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ScreenImage>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), ScreenImageobj);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;


        }


        [System.Web.Http.Route("api/CRM/GetFAQ")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetFAQ(FAQConduction FAQConductionObj)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {


                result = CRMRepositoryobj.GetFAQ(FAQConductionObj);
                if (result != null)
                {
                    response = response.Create(true, "Data fatch successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, "Sorry! Record not found", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //[System.Web.Http.Route("api/CRM/FAQquestionAns")]
        //[System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<Response>>))]
        //public IHttpActionResult GetFAQquestionAns(FAQquestionAnsConduction FAQquestionAnsConductionObj)
        //{
        //    ResponseStatus<Object> response = new ResponseStatus<Object>();
        //    object result = new object();
        //    try
        //    {


        //        result = CRMRepositoryobj.GetFAQquestionAns(FAQquestionAnsConductionObj);
        //        if (result != null)
        //        {
        //            response = response.Create(true, "Data fatch successfully", result);
        //            responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
        //        }
        //        else
        //        {
        //            response = response.Create(false, "Data fatch successfully", result);
        //            responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
        //        }

        //    }


        //    catch (Exception ex)
        //    {
        //        response = response.Create(false, RespMessage.ServerError, result);
        //        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
        //    }
        //    return responseIHttpActionResult;
        //}
        [System.Web.Http.Route("api/CRM/GetAllDeliveryoptions")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetAllDeliveryoptions(DeliveryoptionsConduction DeliveryoptionsConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Deliveryoptions>> response = new ResponseStatus<List<Deliveryoptions>>();
            List<Deliveryoptions> DeliveryoptionsObj = new List<Models.CRM.Deliveryoptions>();
            try
            {
                ds = CRMRepositoryobj.GetAllDeliveryoptions(DeliveryoptionsConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var DeliveryoptionsItem = new Deliveryoptions()
                        {
                            DeliveryOptionId = (int)dr["DeliveryOptionId"],
                            Name = (string)dr["Name"],
                            Rate = (int)dr["Rate"],
                        };
                        DeliveryoptionsObj.Add(DeliveryoptionsItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, DeliveryoptionsObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Deliveryoptions>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, DeliveryoptionsObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Deliveryoptions>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, DeliveryoptionsObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Deliveryoptions>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/CRM/GetAlertMaster")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<AlertMaster>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAlertMaster(AlertMasterCondition AlertMasterConditionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<AlertMaster>> response = new ResponseStatus<List<AlertMaster>>();
            List<AlertMaster> AlertMasterobj = new List<Models.CRM.AlertMaster>();
            try
            {
                ds = CRMRepositoryobj.GetAlertMaster(AlertMasterConditionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var AlertMasterobjItem = new AlertMaster()
                        {
                            AlertStartDate = (string)dr["AlertStartDate"],
                            AlertEndDate = (string)dr["AlertEndDate"],
                            AlertStartTime = (string)dr["AlertStartTime"],
                            AlertEndTime = (string)dr["AlertEndTime"],
                            AlertMessage = (string)dr["AlertMessage"],
                            Status = (string)dr["Status"],
                        };
                        AlertMasterobj.Add(AlertMasterobjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, AlertMasterobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AlertMaster>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, AlertMasterobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AlertMaster>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, RespMessage.ServerError, AlertMasterobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<AlertMaster>>(response, HttpStatusCode.InternalServerError);

            }
            return responseIHttpActionResult;
        }
//-------------------------------------------------------------------------------SaveNotification-------------------------------------------------------
        [System.Web.Http.Route("api/CRM/InsertNotification")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<AlertMaster>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult InsertNotification(SaveNotification SaveNotificationObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object SaveNotificationsobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = CRMRepositoryobj.InsertNotification(SaveNotificationObj);

                if (result == true)
                {
                    response = response.Create(true, "Data save Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, SaveNotificationsobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //--------------------------------------------------InsertUserDevice---------------------------------------------------//---------

        [System.Web.Http.Route("api/CRM/InsertUserDevice")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult InsertUserDevice(UserDevice UserDeviceObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object UserDeviceObjitm = new object();
            try
            {
                bool result = false;
                DataSet dss = new DataSet();
                if (UserDeviceObj.LogIn_LogOut.ToString ().Trim ().ToLower()  == "login")
                {
                     result = CRMRepositoryobj.InsertUserDevice(UserDeviceObj);
                }else{
                    result = CRMRepositoryobj.DeleteUserDevice(UserDeviceObj);
                }
                

                if (result == true)
                {
                    response = response.Create(true, "Data save Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, UserDeviceObjitm);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/CRM/GetStatusMaster")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult GetStatusMaster(StatusMaster StatusMasterObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                DataSet dss = new DataSet();
                 result = CRMRepositoryobj.GetStatusMaster(StatusMasterObj);
                
                if (result != null)
                {
                    response = response.Create(true, "Data Fatch Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/CRM/getCouponCodeDetail")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult getCouponCodeDetail(CouponMasterParameter CouponMasterParameterObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                DataSet dss = new DataSet();
                result = CRMRepositoryobj.GetCouponCodeDetail(CouponMasterParameterObj);

                if (result != null)
                {
                    response = response.Create(true, "Data Fatch Successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, "Sorry! Invalid Coupon Code.", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //--------------------------------------------------GetAllCouponList---------------------------------------------------//---------

        [System.Web.Http.Route("api/CRM/GetAllCouponList")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<CouponlistDetail>>))]
        public IHttpActionResult GetAllCouponList(CouponlistDetail CouponlistDetailObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<CouponListMaster>> response = new ResponseStatus<List<CouponListMaster>>();
            List<CouponListMaster> CouponListobj = new List<Models.CRM.CouponListMaster>();
            try
            {
                ds = CRMRepositoryobj.GetAllCouponList(CouponlistDetailObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var CouponListMasterObjItem = new CouponListMaster()
                        {
                            CouponName = (string)dr["CouponName"],
                            CouponCode = (string)dr["CouponCode"],
                            Amount = (float)dr["Amount"],
                            AmountType = (string)dr["AmountType"],
                            StartDate = (String)dr["StartDate"],
                            EndDate = (String)dr["EndDate"],
                            Status = (string)dr["Status"],
                            CouponImage = (string)dr["CouponImage"],
                            //CompanyId = (int)dr["CompanyId"],
                            //ContactId = (int)dr["ContactId"]
                        };
                        
                        CouponListobj.Add(CouponListMasterObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CouponListobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CouponListMaster>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, CouponListobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CouponListMaster>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, ex.ToString(), CouponListobj);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
    }
}
