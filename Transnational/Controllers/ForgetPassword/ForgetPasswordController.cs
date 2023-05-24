using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TokenAuthenticationInWebAPI;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Models.VM;
using Transnational.Repository.Customer;
using Transnational.Repository.ForgetPassword;
using Transnational.Repository.Login;
using Transnational.Service;
using Transnational.VM;
using System.Web.Http.Cors;
namespace Transnational.Controllers.ForgetPassword
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ForgetPasswordController : ApiController
    {
        Entities db = new Entities();
        static ForgetPasswordRepository repository = new ForgetPasswordRepository();
        private IHttpActionResult responseIHttpActionResult;


        [System.Web.Http.Route("api/login/GetForgetPassword")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetForgetPassword(Logins login)
        {
            string loginId = login.Email;
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();

            try
            {
                string DatabaseName = "";
                string UserType = "";
                string OTP = login.OTP;

                DataSet ds = new DataSet();
                ds = repository.getLoginLocation("DbLogin", login);

             

                if (ds.Tables[0].Rows.Count > 0)
                { // record found
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        DatabaseName = (string)dr["DatabaseName"];
                        UserType = (string)dr["UserType"];


                        DataSet dss_response = new DataSet();
                        String Result = repository.getforgetPassword(DatabaseName, login);
                        

                    }

                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "UPdated"), result);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);

                }
                else
                { // record not found

                    DataSet dss = new DataSet();

                    DataTable dt = new DataTable("DataTable");
                    dt.Columns.Add(new DataColumn("Status", typeof(string)));
                    dt.Columns.Add(new DataColumn("Message", typeof(string)));

                    DataRow dr = dt.NewRow();
                    dr["Status"] = "Fail";
                    dr["Message"] = "Sorry! login Email/Mobile does not exist.";
                    dt.Rows.Add(dr);
                    dss.Tables.Add(dt);



                    response = response.Create(true, RespMessage.Unsuccessful, dss);
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

    

