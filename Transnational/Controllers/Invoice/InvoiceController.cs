using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Description;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Repository.Invoice;
using Transnational.Service;
using System.Data;
using Transnational.VM;
using System.Web.Http.Cors;

namespace Transnational.Controllers.Invoice
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InvoiceController : ApiController
    {
        static InvoiceRepository repository = new InvoiceRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;
     

        [System.Web.Http.Route("api/Invoice/GetInvoice/{dbParam}/{InvoiceId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Invoices>>))]
        public IHttpActionResult GetInvoice(string dbParam,int InvoiceId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Invoices>> response = new ResponseStatus<List<Invoices>>();
            List<Invoices> Invoice = new List<Models.Invoices>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetInvoice(dbParam,InvoiceId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Invoices()
                        {
                            LanguageId = (int)dr["LanguageId"],
                            CompanyId = (string)dr["CompanyId"],
                            ContractCostCntrDprt = (string)dr["ContractCostCntrDprt"],
                            ContractId = (int)dr["ContractId"]
                        };
                        Invoice.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Invoice);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Invoices>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Invoice);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Invoices>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Invoice);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Invoices>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }



        [System.Web.Http.Route("api/Invoice/InvoiceDetail")]
        [System.Web.Http.HttpPost]
        //public Response InvoiceDetail(Invoices InvoiceId, Invoices ServiceId,Invoices Qty, Invoices Price)
        public Response InvoiceDetail(InvoiceDetail InvD)
        {
            //calling EmpRepository Class Method and storing Repsonse   
            int InvoiceId = repository.InvoiceDetail(InvD);

            if (InvoiceId > 0)
            {
                return new Response { Status = "Success", Message = "Order Created Successfully", Id = InvoiceId };
            }
            else
            {
                return new Response { Status = "Failed", Message = "Order Not Created", Id = 0 };
                //}
                //return new Response { Status = "Success", Message = "Order Created Successfully", Id = 1 };
            }
        }
    }
}
     

