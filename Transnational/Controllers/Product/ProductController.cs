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
using Transnational.Models.Products;
using Transnational.Repository.Product;
using Transnational.Service;
using System.Web.Http.Cors;

namespace Transnational.Controllers.Product
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {



        static ProductRepository repository = new ProductRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult IHttpActionResult;
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Product/GetAllProduct/{dbParam}/{ContractId}/{LanguageId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Products>>))]
        public IHttpActionResult GetAllProduct(string dbParam, int ContractId, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Products>> response = new ResponseStatus<List<Products>>();
            List<Products> Product = new List<Models.Products.Products>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetProduct(dbParam, ContractId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Products()
                        {
                            SeqNo = (int)dr["SeqNo"],
                            ServiceName = (string)dr["ServiceName"]
                        };
                        Product.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Product);
                    IHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.Unsuccessful, Product);
                    IHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Product);
                IHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
            }
            return IHttpActionResult;


        }



        [System.Web.Http.Route("api/Product/GetAllProduct1/{dbParam}/{ContractId}/{LanguageId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Products>>))]
        public IHttpActionResult GetAllproduct1(string dbParam, int ContractId, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Products>> response = new ResponseStatus<List<Products>>();
            List<Products> Product1 = new List<Models.Products.Products>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetProduct1(dbParam, ContractId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Products()
                        {
                            SeqNo = (int)dr["SeqNo"],
                            ServiceName = (string)dr["ServiceName"]
                        };
                        Product1.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Product1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.Unsuccessful, Product1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Product1);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //==================================================navdeep/////////////////////////////////////////////////////////==============
        [System.Web.Http.Route("api/Product/GetContractReturnServices/{dbParam}/{ContractId}/{LanguageId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Products>>))]
        public IHttpActionResult GetContractReturnServices(string dbParam, int ContractId, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Products>> response = new ResponseStatus<List<Products>>();
            List<Products> Product1 = new List<Models.Products.Products>();
            try
            {
                if (dbParam == "SGP")
                {

                    ds = repository.GetContractReturnServices(dbParam, ContractId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Products()
                        {
                            SeqNo = (int)dr["SeqNo"],
                            ServiceName = (string)dr["ServiceName"]
                        };
                        Product1.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Product1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Product1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Product1);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Product/GetReturnService/{dbParam}/{SeqNo}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<ProductPrices>>))]
        public IHttpActionResult GetReturnService(string dbParam, int SeqNo)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ProductPrices>> response = new ResponseStatus<List<ProductPrices>>();
            List<ProductPrices> Product = new List<Models.Products.ProductPrices>();
            try
            {
                if (dbParam == "SGP")
                {

                    ds = repository.GetReturnService(dbParam, SeqNo);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new ProductPrices()
                        {
                            ReturnServiceType = (int)dr["ReturnServiceType"]
                           
                        };
                        Product.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Product);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Product);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Product);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Product/GetDeliveryduration/{dbParam}/{languageId}/{ContractId}/{ServiceId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<ProductPrices>>))]
        public IHttpActionResult GetDeliveryduration(string dbParam, int languageId, int ContractId, int ServiceId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ProductPrices>> response = new ResponseStatus<List<ProductPrices>>();
            List<ProductPrices> Product = new List<Models.Products.ProductPrices>();
            try
            {
                if (dbParam == "SGP")
                {

                    ds = repository.GetDeliveryduration(dbParam, languageId,  ContractId,  ServiceId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new ProductPrices()
                        {
                            Deliveryduration = (double)dr["Deliveryduration"]

                        };
                        Product.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Product);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Product);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Product);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductPrices>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
    }
}





