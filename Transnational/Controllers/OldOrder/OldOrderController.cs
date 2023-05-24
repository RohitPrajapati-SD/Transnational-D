using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Models.Order;
using Transnational.Repository.Order;
using Transnational.Service;
using Transnational.VM;
using System.Web.Http.Cors;

namespace Transnational.Controllers
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        static OrderRepository repository = new OrderRepository();
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Order/AddOrder/{dbParam}")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult AddOrder(Orders Ord, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
               // if (dbParam == "Teamwork-SG-v2UAT")
                if (dbParam == "Teamwork_CRM_UAT")
                {
                    result = repository.AddNewOrder(Ord, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Order Created"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }

                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        [System.Web.Http.Route("api/Order/AddOrderAddress/{dbParam}")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult AddOrderAddress(OrderAddress OrdAdd, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                if (dbParam == "SGP")
                {
                    result = repository.AddOrderAddress(OrdAdd, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Order Created Successfully"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }
                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;




            //calling EmpRepository Class Method and storing Repsonse   
            //var invoiceaddressid = repository.AddOrderAddress(OrdAdd);
            //if (invoiceaddressid > 0)
            //{
            //    return new Response { Status = "Success", Message = "Order Address Add Successfully", Id = invoiceaddressid };
            //}
            //else
            //{
            //    return new Response { Status = "Failed", Message = " Order Address Not Created", Id = 0 };
            //}

        }

        [System.Web.Http.Route("api/Order/AddOrderDeliveryAddress/{dbParam}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddOrderDeliveryAddress(OrderDeliveryAddress DelAdd, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                if (dbParam == "SGP")
                {
                    result = repository.AddOrderDeliveryAddress(DelAdd, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Order Delivery Address Add Successfully"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }
                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

            //calling EmpRepository Class Method and storing Repsonse   
            //var invoiceDeliveryaddressid = repository.AddOrderDeliveryAddress(DelAdd);
            //if (invoiceDeliveryaddressid > 0)
            //{
            //    return new Response { Status = "Success", Message = "Order Delivery Address Add Successfully", Id = invoiceDeliveryaddressid };
            //}
            //else
            //{
            //    return new Response { Status = "Failed", Message = "Order Delivery Address Not Created", Id = 0 };
            //}

        }

        [System.Web.Http.Route("api/Order/SaveOrderSMS/{dbParam}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult SaveOrderSMS(OrderSms Ordsms, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                if (dbParam == "SGP")
                {
                    result = repository.SaveOrderSMS(Ordsms, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, " SMS Order Save Successfully"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }
                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

            //calling EmpRepository Class Method and storing Repsonse   
            //var invoiceDeliveryaddressid = repository.AddOrderDeliveryAddress(DelAdd);
            //if (invoiceDeliveryaddressid > 0)
            //{
            //    return new Response { Status = "Success", Message = "Order Delivery Address Add Successfully", Id = invoiceDeliveryaddressid };
            //}
            //else
            //{
            //    return new Response { Status = "Failed", Message = "Order Delivery Address Not Created", Id = 0 };
            //}

        }
        [System.Web.Http.Route("api/Order/SaveOrderEmail/{dbParam}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult SaveOrderEmail(OrderEmail Ordemail, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                if (dbParam == "SGP")
                {
                    result = repository.SaveOrderEmail(Ordemail, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Email Order Save Successfully"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }
                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



            //calling EmpRepository Class Method and storing Repsonse   
            //var invoiceDeliveryaddressid = repository.AddOrderDeliveryAddress(DelAdd);
            //if (invoiceDeliveryaddressid > 0)
            //{
            //    return new Response { Status = "Success", Message = "Order Delivery Address Add Successfully", Id = invoiceDeliveryaddressid };
            //}
            //else
            //{
            //    return new Response { Status = "Failed", Message = "Order Delivery Address Not Created", Id = 0 };
            //}

        }
        [System.Web.Http.Route("api/Order/saveOrderMiscServiceReturn/{dbParam}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult saveOrderMiscServiceReturn(MiscellaneousOrder OrdMiscel, string dbParam)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                if (dbParam == "SGP")
                {
                    result = repository.saveOrderMiscServiceReturn(OrdMiscel, dbParam);
                    if (result != null)
                    {
                        response = response.Create(true, RespMessage.FormatMessage(RespMessage.Success, "Miscellaneous Order Save Successfully"), result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, result);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.NoContent);
                    }
                }
                else
                {

                    response = response.Create(false, RespMessage.ServerError, result);

                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



            //calling EmpRepository Class Method and storing Repsonse   
            //var invoiceDeliveryaddressid = repository.AddOrderDeliveryAddress(DelAdd);
            //if (invoiceDeliveryaddressid > 0)
            //{
            //    return new Response { Status = "Success", Message = "Order Delivery Address Add Successfully", Id = invoiceDeliveryaddressid };
            //}
            //else
            //{
            //    return new Response { Status = "Failed", Message = "Order Delivery Address Not Created", Id = 0 };
            //}

        }




    }
}