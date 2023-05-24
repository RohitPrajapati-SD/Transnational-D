using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Repository.Contract;
using Transnational.Service;
using System.Web.Http.Cors;

namespace Transnational.Controllers.Contract
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContractController : ApiController
    {
       
        static ContractRepository repository = new ContractRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Contract/GetAllContract/{dbParam}/{CompanyId}/{ContactId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Contracts>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllContract(string dbParam, int CompanyId, int ContactId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Contracts>> response = new ResponseStatus<List<Contracts>>();
            List<Contracts> contract = new List<Models.Contracts>();
            try
            {
                //if (dbParam == "Teamwork-SG-v2UAT")
                if (dbParam == "Teamwork_CRM_UAT")
                {
                    ds = repository.GetContract(CompanyId, ContactId, dbParam);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Contracts()
                        {
                            ContractNo = (string)dr["ContractNo"],
                            BillingCycle = (string)dr["BillingCycle"],
                            Address1 = (string)dr["Address1"]
                            // CompanyId = (int)dr["CompanyId"],
                            // CustomerName = (string)dr["CustomerName"]
                        };
                        contract.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, contract);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contracts>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, contract);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contracts>>(response, HttpStatusCode.InternalServerError);
                }
            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, contract);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contracts>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }

        [System.Web.Http.Route("api/Order/GetContractBillingDetails")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Contracts>>))]
        public IHttpActionResult GetOrderVolumeDetels(GetContractBillingDetails GetContractBillingDetailsObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            DataTable dt = new DataTable();
            List<Contracts> contract = new List<Models.Contracts>();
            try
            {

                //DataSet dss = new DataSet();
                dt = repository.GetContractBillingDetail(GetContractBillingDetailsObj);

                if (dt != null)
                {

                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.ContractBillingDetail), dt);
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
    }
}