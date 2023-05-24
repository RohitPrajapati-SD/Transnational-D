//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using Transnational.ApiMessage;
//using Transnational.Models;
//using Transnational.Repository.EmailVerification;
//using Transnational.Service;
//using System.Net.Mail;
//using System.Web.Mail;
//using System.Data.SqlClient;
//using MailMessage = System.Net.Mail.MailMessage;

//namespace Transnational.Controllers.EmailVerification
//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class EmailVerificationController : ApiController
//    {
       
      
//            //static EmailVerificationRepository EmailVerificationRepositoryObj = new EmailVerificationRepository();
//            // private ITaskManagementService _iTaskService;
//            private IHttpActionResult responseIHttpActionResult;
//            [System.Web.Http.Route("api/OTPVerification/GetOTPVerification")]
//        [System.Web.Http.HttpGet]

//        public IHttpActionResult GetOTPVerification()
//        {
//            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
//            ResponseStatus<Object> response = new ResponseStatus<Object>();
//            object InsertAddtoMyCartobj = new object();
//            try
//            {
//                string fromMail = "gauravgupta1248@gmail.com";
//                string fromPassword = "sjwozqaipxvaylfm";

//                MailMessage message = new MailMessage();
//                message.From = new MailAddress(fromMail);
//                message.Subject = "Test Subject";
//                message.To.Add(new MailAddress("gauravgupta11489@gmail.com"));
//                message.Body = "<html><body> Your OTP is  </body></html>";
//                message.IsBodyHtml = true;

//                var smtpClient = new SmtpClient("smtp.gmail.com")
//                {
//                    Port = 587,
//                    Credentials = new NetworkCredential(fromMail, fromPassword),
//                    EnableSsl = true,
//                };

//                smtpClient.Send(message);
//            }


//            catch (Exception ex)
//            {
//                response = response.Create(false, RespMessage.ServerError, InsertAddtoMyCartobj);
//                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
//            }
//            return responseIHttpActionResult;
//        }
//    }
//}
