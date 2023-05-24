using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Transnational.Models.VM;
using Transnational.Repository.Login;
using Transnational.Service;
using Transnational.VM;
using System.Web;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TokenAuthenticationInWebAPI;
using Transnational.ApiMessage;
using Transnational.Models;
using System.Web.Http.Cors;

namespace Transnational.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        Entities db = new Entities();
        static LoginRepository repository = new LoginRepository();
        private IHttpActionResult responseIHttpActionResult;


        [System.Web.Http.Route("api/login/GetLogin")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetLogin(Logins login)
        {
            string loginId = login.Email;
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                string DatabaseName = "";
                string UserType = "";

                DataSet ds = new DataSet();
                ds = repository.getLoginLocation("trConnection", login);


                if (ds.Tables[0].Rows.Count > 0)
                { // record found
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DatabaseName = (string)dr["DatabaseName"];
                        UserType = (string)dr["UserType"];

                        DataSet ds_response = new DataSet();
                        ds_response = repository.CheckLoginWithDB(DatabaseName, login, UserType);

                        result = ds_response;
                        String a = Convert.ToString(ds_response.Tables[0].Rows[0]["Status"]);

                        if ( a == "Fail")
                        {
                            response = response.Create(false, RespMessage.Unsuccessful, result);
                            responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                        }
                        else
                        {
                            response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Login"), result);
                            responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                        }
                    }
                    
                }
                else
                {

                    DataSet dss = new DataSet();

                    DataTable dt = new DataTable("DataTable");
                    dt.Columns.Add(new DataColumn("Status", typeof(string)));
                    dt.Columns.Add(new DataColumn("Message", typeof(string)));

                    DataRow dr = dt.NewRow();
                    dr["Status"] = "Fail";
                    dr["Message"] = "Sorry! login Email/Mobile does not exist.";
                    dt.Rows.Add(dr);
                    dss.Tables.Add(dt);



                    response = response.Create(false, RespMessage.Unsuccessful, dss);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);

                }


            }
            catch (Exception ex)
            {
                response = response = response.Create(false, ex.Message, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);

                
                
                //response = response.Create(false, RespMessage.ServerError, result);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }





    }

}
