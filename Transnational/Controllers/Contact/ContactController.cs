using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using EnDecryptDLL;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Models.Contact;
using Transnational.Models.VM;
using Transnational.Repository.Login;
using Transnational.Repository.OTPRepository;
//using Transnational.ContactRepository;
using Transnational.Service;
using Transnational.VM;
using Transnational.Service;
using System.Net.Mail;
using System.Web.Mail;
using System.Data.SqlClient;
using MailMessage = System.Net.Mail.MailMessage;

namespace Transnational.Controllers.OTPController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactController : ApiController
    {
        static ContactRepository ContactRepositoryObj = new ContactRepository();
        //static LoginRepository LoginRepositoryObj = new LoginRepository();
        private IHttpActionResult responseIHttpActionResult;
        [System.Web.Http.Route("api/SendOTP/SendOTP")]
        [System.Web.Http.HttpPut]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]

        public IHttpActionResult reciveOTP(ForgotPass Loginsobj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            DataSet ds = new DataSet();
            DataSet ContactDs = new DataSet();
            try
            {
                string DatabaseName = "";
                string UserType = "";
                ds = ContactRepositoryObj.getLoginLocation("trConnection", Loginsobj);


                if (ds.Tables[0].Rows.Count > 0)
                { // record found
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DatabaseName = (string)dr["DatabaseName"];
                        UserType = (string)dr["UserType"];
                        ContactDs = ContactRepositoryObj.reciveOTP(DatabaseName, UserType, Loginsobj);


                    }

                    if (ContactDs.Tables[0].Rows.Count > 0)
                    {
                        SendFogotPasswordOTPEmail(Loginsobj.OTP, Loginsobj.LoginId );
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.OTPUpdated), ContactDs);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }


                    else
                    {
                        response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), ContactDs);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactDs);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
       public int SendFogotPasswordOTPEmail(string OTP,string EmailTo)
        {
           
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Result = new object();
            try
            {

                    string fromMail = "gauravgupta1248@gmail.com";
                    string fromPassword = "sjwozqaipxvaylfm";

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(fromMail);
                    message.Subject = "Forgot Password OTP";
                    message.To.Add(new MailAddress(EmailTo));
                    message.Body = "<html><body>Forgot Password OTP " + OTP + "</body></html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);

                    response = response.Create(true, "OTP Sent Successfully", 1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);


            }

            catch (Exception ex)
            {
               // response = response.Create(false, RespMessage.ServerError, Result);
               // responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }

            return 1;
        }
        

        [System.Web.Http.Route("api/UpdatePassward/UpdatePassward")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdatePassward(Logins obj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            DataSet ds = new DataSet();
            DataSet ContactDs = new DataSet();
            //object Contact = new object();
            try
            {

                DataSet dss = new DataSet();
                bool Contact = ContactRepositoryObj.UpdatePassward(obj);

                if (Contact == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.ChangePassword), ContactDs);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, "Sorry! OTP does not matched", ContactDs);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactDs);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/UpdateContactDP/UpdateImagebyContactId")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdateContactDP(Logins obj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                DataSet dss = new DataSet();
                bool resul = ContactRepositoryObj.UpdateContactDP(obj);

                if (resul == true)
                {


                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.UpdateImage), result);
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
        [System.Web.Http.Route("api/Address/UpdateAddressByContactId")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult ContactAddress(Logins obj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object ContactAddressObj = new object();
            try
            {
                DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.ContactAddress(obj);

                if (result == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Update), ContactAddressObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.Fail), ContactAddressObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactAddressObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/SavecontactAddress")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult SavecontactAddress(ContactAddress ContactAddressObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Savecontact = new object();
            try
            {
                //string CD = SavecontactObj.CD;

                DataSet dss = new DataSet();
                
                bool result = ContactRepositoryObj.SavecontactAddress(ContactAddressObj);

                if (result == true)
                {


                    response = response.Create(true, "data save successfully", result);
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
                response = response.Create(false, RespMessage.ServerError, Savecontact);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //------------------------------------------UpdateContactAddress------------------------------------------------------//
        [System.Web.Http.Route("api/Contact/UpdateContactAddress")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdateContactAddress(ContactAddress ContactAddressObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Savecontact = new object();
            try
            { 

                DataSet dss = new DataSet();

                bool result = ContactRepositoryObj.UpdateContactAddress(ContactAddressObj);

                if (result == true)
                {

                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Update), result);
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
                response = response.Create(false, RespMessage.ServerError, Savecontact);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //------------------------------------------GetContactAddressByContactId------------------------------------------------//

        [System.Web.Http.Route("api/Contact/GetContactAddressByContactId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetContactAddress(ContactAddressConduction ContactAddressConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ContactAddress>> response = new ResponseStatus<List<ContactAddress>>();
            List<ContactAddress> ContactAddressObj = new List<Models.Contact.ContactAddress>();

            try
            {
              
                ds = ContactRepositoryObj.GetContactAddress(ContactAddressConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactAddressObjItem = new ContactAddress()
                        {
                            CABid= (int)dr["CABid"],
                            PostalCode = (string)dr["PostalCode"],
                            Address1 = (string)dr["Address1"],
                            Address2 = (string)dr["Address2"],
                            Address3 = (string)dr["Address3"],
                            Address4 = (string)dr["Address4"],
                            Districtid = (int)dr["DistrictId"],
                            Countryid = (int)dr["CountryId"],
                            Cityid = (int)dr["Cityid"],
                            Zoneid = (int)dr["ZoneId"],
                            ContactId = (int)dr["ContactId"],
                            ALatitude = (string)dr["ALatitude"],
                            ALongitude = (string)dr["ALongitude"],
                            Collection = (string)dr["Collection"],
                            Delivery = (string)dr["Delivery"],
                            CostCenterName = (string)dr["CostCenterName"],
                            ContactNumber1 = (string)dr["ContactNumber1"],
                            ContactNumber2 = (string)dr["ContactNumber2"],
                            ContactName= (string)dr["ContactName"],
                            AddressName = (string)dr["AddressName"],
                            DefaultAddress = (string)dr["DefaultAddress"],
                            DefaultShipping = (string)dr["DefaultShipping"],
                            DefaultBilling = (string)dr["DefaultBilling"],

                            CustomerId = (int)dr["CustomerId"],


                        };
                        ContactAddressObj.Add(ContactAddressObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ContactAddressObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactAddress>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), ContactAddressObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactAddress>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactAddressObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactAddress>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/GetOldpasswordbyContactId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetOldpasswordbyContactId(OldpasswordbyContactIdConduction OldpasswordbyContactIdConductionObj)
        {
            DataSet ds = new DataSet();
            Security SecurityObj = new Security();
            ResponseStatus<List<OldpasswordbyContactId>> response = new ResponseStatus<List<OldpasswordbyContactId>>();
            List<OldpasswordbyContactId> OldpasswordbyContactIdObj = new List<Models.Contact.OldpasswordbyContactId>();

            try
            {
                //string CD = obj.CD;
                //if (dbParam == "Teamwork-SG-v2UAT")
                //{
                ds = ContactRepositoryObj.GetOldpasswordbyContactId(OldpasswordbyContactIdConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactAddressObjItem = new OldpasswordbyContactId()
                        {

                            CPassword = SecurityObj.deCrypt((string)dr["CPassword"])


                        };
                        OldpasswordbyContactIdObj.Add(ContactAddressObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, OldpasswordbyContactIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<OldpasswordbyContactId>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), OldpasswordbyContactIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<OldpasswordbyContactId>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, OldpasswordbyContactIdObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<OldpasswordbyContactId>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Contact/UpdateOldPasswordbyContactId")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdateOldPasswordbyContactId(UpdateOldpasswordbyContactId UpdateOldpasswordbyContactIdObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object UpdatepasswordObj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.UpdateOldPasswordbyContactId(UpdateOldpasswordbyContactIdObj);

                if (result == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Update), result);
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
                response = response.Create(false, RespMessage.ServerError, UpdatepasswordObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //-----------------------------------------------------UpdateContactprofilebycontactId-------------------------------------//------------


        [System.Web.Http.Route("api/Contact/UpdateContactprofilebycontactId")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdateContactprofilebycontactId(ContactProfileByContactId ContactProfileByContactIdObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object ContactProfileobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.UpdateContactprofilebycontactId(ContactProfileByContactIdObj);

                if (result == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Update), result);
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
                response = response.Create(false, RespMessage.ServerError, ContactProfileobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }


        //-------------------------------------------------GetContactprofilebycontactId----------------------------------------------------//----------

        [System.Web.Http.Route("api/Contact/GetContactprofilebycontactId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetContactprofilebycontactId(ContactProfileByContactId ContactProfileByContactId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ContactProfileByContactId>> response = new ResponseStatus<List<ContactProfileByContactId>>();
            List<ContactProfileByContactId> ContactProfileByContactIdObj = new List<Models.Contact.ContactProfileByContactId>();

            try
            {

                ds = ContactRepositoryObj.GetContactprofilebycontactId(ContactProfileByContactId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactProfileByContactIdItem = new ContactProfileByContactId()
                        {
                          
                            FirstName = (string)dr["FirstName"],
                            PinCode = (string)dr["PinCode"],
                            Email = (string)dr["Email"],
                            Address = (string)dr["Address"],
                            Address2 = (string)dr["Address2"],
                            Address3 = (string)dr["Address3"],
                            Address4 = (string)dr["Address4"],
                            CountryId = (int)dr["CountryId"],
                            Cityid = (int)dr["Cityid"],
                            Mobile = (string)dr["Mobile"],
                            DistrictId = (int)dr["DistrictId"],
                            Zoneid = (int)dr["ZoneId"],
                            StateId  = (int)dr["StateId"],

                        };
                        ContactProfileByContactIdObj.Add(ContactProfileByContactIdItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ContactProfileByContactIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactProfileByContactId>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), ContactProfileByContactIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactProfileByContactId>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactProfileByContactIdObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactProfileByContactId>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //-------------------------------------------------UpdateContactDefaultAddressMode---------------------------------------//------------
        [System.Web.Http.Route("api/Contact/UpdateContactDefaultAddressMode")]
        [System.Web.Http.HttpPut]

        public IHttpActionResult UpdateContactDefaultAddressMode(ContactDefaultAddressMode ContactDefaultAddressModeObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Obj = new object();
            try
            {

                //DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.UpdateContactDefaultAddressMode(ContactDefaultAddressModeObj);

                if (result == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Update), result);
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
                response = response.Create(false, RespMessage.ServerError, Obj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }


        //----------------------------------------------------InsertContactRegistration--------------------------------------------------------//--

        [System.Web.Http.Route("api/Contact/InsertContactRegistration")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertContactRegistration(ContactRegistration ContactRegistrationObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object ContactRegistrationItmObj = new object();
            try
            {

                //DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.InsertContactRegistration(ContactRegistrationObj);

                if (result == true)
                {
                    response = response.Create(true, "Registered Successfully", result);
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
                response = response.Create(false, RespMessage.ServerError, ContactRegistrationItmObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //------------------------------------------------GetContactProfileByContactId_Pic--------------------------------------------//-------
        [System.Web.Http.Route("api/Contact/GetContactprofilebycontactId_Pic")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetContactprofilebycontactId_Pic(ContactprofilebycontactId_Pic_Conduction ContactprofilebycontactId_Pic_ConditionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ContactprofilebycontactId_Pic>> response = new ResponseStatus<List<ContactprofilebycontactId_Pic>>();
            List<ContactprofilebycontactId_Pic> ContactprofilebycontactId_PicObj = new List<Models.Contact.ContactprofilebycontactId_Pic>();

            try
            {

                ds = ContactRepositoryObj.GetContactprofilebycontactId_Pic(ContactprofilebycontactId_Pic_ConditionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactprofilebycontactId_PicItem = new ContactprofilebycontactId_Pic()
                        {

                            ImageString = (string)dr["ImageString"],
                            

                        };
                        ContactprofilebycontactId_PicObj.Add(ContactprofilebycontactId_PicItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ContactprofilebycontactId_PicObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactprofilebycontactId_Pic>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), ContactprofilebycontactId_PicObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactprofilebycontactId_Pic>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactprofilebycontactId_PicObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactprofilebycontactId_Pic>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //--------------------------------------------------------GetPaymentMethod---------------------------------------------------------//------

        [System.Web.Http.Route("api/Contact/GetPaymentMethodByContractId")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetPaymentMethod(PaymentMethodConduction PaymentMethodConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<PaymentMethod>> response = new ResponseStatus<List<PaymentMethod>>();
            List<PaymentMethod> PaymentMethodObj = new List<Models.Contact.PaymentMethod>();
            try
            {
                ds = ContactRepositoryObj.GetPaymentMethod(PaymentMethodConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var PaymentMethodObjItem = new PaymentMethod()
                        {
                            ContactPaymentMethodId = (int)dr["ContactPaymentMethodId"],
                            PaymentMethodId = (int)dr["PaymentMethodId"],
                            ContactId = (int)dr["ContactId"],
                            CardHolderName = (string)dr["CardHolderName"],
                            CardNumber = (string)dr["CardNumber"],
                            Month = (string)dr["Month"],
                            Year = (string)dr["Year"],
                            ContractId = (int)dr["ContractId"],
                            PaymentMethodName = (string)dr["PaymentMethodName"],
                            PaymentMethodImage = (string)dr["PaymentMethodImage"],
                        };
                        PaymentMethodObj.Add(PaymentMethodObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, PaymentMethodObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<PaymentMethod>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), PaymentMethodObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<PaymentMethod>>(response, HttpStatusCode.OK);
                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, PaymentMethodObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<PaymentMethod>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //-----------------------------------------InsertPaymentmethod------------------------------------------//----------------------//--

        [System.Web.Http.Route("api/Contact/InsertContactPaymentmethod")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult InsertPaymentmethod(PaymentMethod PaymentMethodObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object PaymentMethodObjitm = new object();
            try
            {

                //DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.InsertPaymentmethod(PaymentMethodObj);

                if (result == true)
                {
                    response = response.Create(true, "Data Save Successfully", result);
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
                response = response.Create(false, RespMessage.ServerError, PaymentMethodObjitm);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //-----------------------------------------GetContactPaymentMethod---------------------------------------------//--------//----

        [System.Web.Http.Route("api/Contact/GetContactPaymentMethodByContactId")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<ContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetContactPaymentMethod(ContactPaymentMethodConduction ContactPaymentMethodConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ContactPaymentMethod>> response = new ResponseStatus<List<ContactPaymentMethod>>();
            List<ContactPaymentMethod> ContactPaymentMethodObj = new List<Models.Contact.ContactPaymentMethod>();

            try
            {

                ds = ContactRepositoryObj.GetContactPaymentMethod(ContactPaymentMethodConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContactPaymentMethoditem = new ContactPaymentMethod()
                        {
                            ContactPaymentMethodId=(int)dr["ContactPaymentMethodId"],

                            PaymentMethodId = (int)dr["PaymentMethodId"],
                            ContactId = (int)dr["ContactId"],
                            CardHolderName = (string)dr["CardHolderName"],
                            CardNumber = (string)dr["CardNumber"],
                            Month = (string)dr["Month"],
                            Year = (string)dr["Year"],
                            DefaultPaymentMethod = (string)dr["DefaultPaymentMethod"],
                            PaymentMethodName = (string)dr["PaymentMethodName"],
                            PaymentMethodImage = (string)dr["PaymentMethodImage"],

                        };
                        ContactPaymentMethodObj.Add(ContactPaymentMethoditem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ContactPaymentMethodObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactPaymentMethod>>(response, HttpStatusCode.OK);
                }



                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), ContactPaymentMethodObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactPaymentMethod>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ContactPaymentMethodObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContactPaymentMethod>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //----------------------------------------------DeleteContactPaymentMethod--------------------------------//-----------------------//--
       [System.Web.Http.Route("api/Contact/DeleteContactPaymentMethod")]
       [System.Web.Http.HttpDelete]

        public IHttpActionResult DeleteContactPaymentMethod(PaymentMethod PaymentMethodObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object PaymentMethodObjitm = new object();
            try
            {

                //DataSet dss = new DataSet();
                bool result = ContactRepositoryObj.DeleteContactPaymentMethod(PaymentMethodObj);

                if (result == true)
                {
                    response = response.Create(true, "Data Deleted Successfully", result);
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
                response = response.Create(false, RespMessage.ServerError, PaymentMethodObjitm);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

       //----------------------------------------------DeleteContactAddressBook--------------------------------//-----------------------//--
       [System.Web.Http.Route("api/Contact/DeleteContactAddressBook")]
       [System.Web.Http.HttpDelete]

       public IHttpActionResult DeleteContactAddressBook(ContactAddressBookDelete ContactAddressConductionObj)
       {

           ResponseStatus<Object> response = new ResponseStatus<Object>();
           object ContactAddressConductionObjitm = new object();
           try
           {

               //DataSet dss = new DataSet();
               bool result = ContactRepositoryObj.DeleteContactAddressBook(ContactAddressConductionObj);

               if (result == true)
               {
                   response = response.Create(true, "Data Deleted Successfully", result);
                   responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
               }

               else
               {
                   response = response.Create(false, "Default Address Cannot Be Deleted", result);
                   responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
               }
           }
           catch (Exception ex)
           {
               response = response.Create(false, RespMessage.ServerError, ContactAddressConductionObjitm);
               responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
           }
           return responseIHttpActionResult;
       }
        //--------------------------------------------GetOTPVerification------------------------------------------//---------------------//--
        [System.Web.Http.Route("api/OTPVerification/GetOTPVerification")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult GetOTPVerification(EmailVerifications EmailVerificationObj)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object Result = new object();
            try
            {
                int value = ContactRepositoryObj.GetOTPVerification(EmailVerificationObj);
                if (value >= 1)
                {
                    response = response.Create(true, "EmailId Already Registered", value);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);

                }
                else
                {

                    string fromMail = "gauravgupta1248@gmail.com";
                string fromPassword = "sjwozqaipxvaylfm";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Verification OTP";
                message.To.Add(new MailAddress(EmailVerificationObj.Email));
                message.Body = "<html><body> Your Verification OTP is " + EmailVerificationObj.OTP+ "  </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
             
                    response = response.Create(true, "OTP Send Successfully", value);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                   

                }
                
            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }

            return responseIHttpActionResult;
        }

        [System.Web.Http.Route("api/Contact/GetAllPaymentMethod")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult GetAllPaymentMethod(PaymentMethod PaymentMethodObj)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {


                result = ContactRepositoryObj.GetAllPaymentMethod(PaymentMethodObj);
                if (result != null)
                {
                    response = response.Create(true, "Data fatch successfully", result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, "Sorry! Record Not Found", result);
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
    }
}


