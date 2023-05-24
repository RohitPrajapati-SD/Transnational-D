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
using Transnational.Models.Order;
using Transnational.Repository.CreateOrder;
using Transnational.Service;
using Transnational.VM;
using System.Net.Mail;
using System.Web.Mail;
using System.Data.SqlClient;
using MailMessage = System.Net.Mail.MailMessage;

namespace Transnational.Controllers.CreateOrder
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CreateOrderController : ApiController
    {
        static CreateOrderRepository OrderRepositoryObj = new CreateOrderRepository();
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Order/AddOrder")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult AddOrder(Orders OrderObj)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {
                int InvoiceId = 0 ;int ReturnOrderId = 0;

                InvoiceId = OrderRepositoryObj.AddNewOrder(OrderObj, OrderObj.OrderDeliveryAddress, OrderObj.OrderAddress);


                if (InvoiceId  > 0)

                {
                    if (OrderObj.rtrnTrip == true )
                    {
                        // created mew Order , with reversed address
                         ReturnOrderId = OrderRepositoryObj.AddNewOrder_Return(OrderObj, OrderObj.OrderDeliveryAddress, OrderObj.OrderAddress, InvoiceId);

                        
                    }
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.OrderCreate), result);
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
        //------------------------------- GetAllOrdersFilter--------------------------//
        [System.Web.Http.Route("api/Order/GetAllOrders")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<AllOrdersConduction>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllOrders(AllOrdersConduction AllOrdersConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<AllOrders>> response = new ResponseStatus<List<AllOrders>>();
            List<AllOrders> AllOrdersobj = new List<Models.Order.AllOrders>();
            //Object result = new object();
            // System.DateTime dt = new System . DateTime();
            try
            {

                String Status_str = "";
                for (int i = 0; i < AllOrdersConductionObj.OrderStatusObjList.Count; i++)
                {
                    if (i == 0)

                        Status_str = "'" + AllOrdersConductionObj.OrderStatusObjList[i].Status.ToString() + "'";
                    else
                        Status_str = Status_str + "," + "'" + AllOrdersConductionObj.OrderStatusObjList[i].Status.ToString() + "'";
                }

                ds = OrderRepositoryObj.GetAllOrders(AllOrdersConductionObj, Status_str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var AllOrdersObjitem = new AllOrders()
                        {
                            InvoiceId = (int)dr["InvoiceId"],
                            CompanyId = (String)dr["CompanyId"],
                            CBranchId = (int)dr["CBranchId"],
                            Status = (string)dr["Status"].ToString(),
                            Remark = (string)dr["Remark"].ToString(),
                            PickupDate = (DateTime)dr["PickupDate"],
                            PickupTime = (string)dr["PickupTime"],
                            DeliveryDate = (DateTime)dr["DeliveryDate"],
                            DeliveryTime = (string)dr["DeliveryTime"],
                            OrderNo = (string)dr["OrderNo"].ToString(),
                            OrderDate = (DateTime)dr["OrderDate"],
                            ContactId = (int)dr["ContactId"],
                            ContactName = (string)dr["ContactName"].ToString(),
                            collectionAddress = (string)dr["collectionAddress"].ToString(),
                            CollectionBranchName = (string)dr["CollectionBranchName"].ToString(),
                            DeliveryAddress = (string)dr["DeliveryAddress"].ToString(),
                            DeliveryBranchName = (string)dr["DeliveryBranchName"].ToString(),
                            ServiceName = (string)dr["ServiceName"].ToString(),
                            ContractId = (int)dr["ContractId"],
                            CreatedBy = (int)dr["CreatedBy"],
                            CreatedByType = (string)dr["CreatedByType"],
                            ServiceId = (int)dr["ServiceId"],

                        };
                        AllOrdersobj.Add(AllOrdersObjitem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, AllOrdersobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AllOrders>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), AllOrdersobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<AllOrders>>(response, HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, AllOrdersobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<AllOrders>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //------------------------------- GetAllOrdersFilter End--------------------------//

        [System.Web.Http.Route("api/Order/GetOrderByOrderId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetOrderByOrderId(GetOrderByOrderId GetOrderByOrderIdObj)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {


                result = OrderRepositoryObj.GetOrderByOrderId(GetOrderByOrderIdObj);
                if (result != null)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.OrderCreate), result);
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

        //--------------------------------------------GetOrderStatusByOrderId-------------------------------------//----------

        [System.Web.Http.Route("api/Order/GetOrderStatusByOrderId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetOrderSatusByOrderId(TrackOrderStatus TrackOrderStatusObj)
        {
            ResponseStatus<List<TrackOrder>> response = new ResponseStatus<List<TrackOrder>>();
            List<TrackOrder> TrackOrderobj = new List<Models.Order.TrackOrder>();
            //ResponseStatus<Object> response = new ResponseStatus<Object>();

            DataSet ds = new DataSet();
            object result = new object();
            try
            {


                //result = OrderRepositoryObj.GetOrderStatusByOrderId(TrackOrderStatusObj);
                ds = OrderRepositoryObj.GetOrderStatusByOrderId(TrackOrderStatusObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var TrackOrderObjitem = new TrackOrder()
                        {
                            OrderDeliveryDate = (Object)dr["OrderDeliveryDate"],
                            OrderLastUpdateDate = (Object)dr["OrderLastUpdateDate"],
                            OrderTime = (DateTime)dr["OrderTime"],
                            UpdatedStatus = (string)dr["UpdatedStatus"],
                            OrderStatus = (string)dr["OrderStatus"],
                            Remark = (string)dr["Remark"],
                            OrderNo = (string)dr["OrderNo"],
                            Index_Row = (Object)dr["Index_Row"],
                            OrderStatusId_Tracking = (int)dr["OrderStatusId_Tracking"],

                        };
                        TrackOrderobj.Add(TrackOrderObjitem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, TrackOrderobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<TrackOrder>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), TrackOrderobj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<TrackOrder>>(response, HttpStatusCode.OK);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, TrackOrderobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<TrackOrder>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //--------------------------------------UpdateAPI----------------------------------------------//

        [System.Web.Http.Route("api/Order/UpdateInvoiceStatus")]
        [System.Web.Http.HttpPut]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult UpdateInvoiceStatus(UpdateInvoiceStatus UpdateInvoiceStatusObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                //DataSet dss = new DataSet();
                result = OrderRepositoryObj.UpdateInvoiceStatus(UpdateInvoiceStatusObj);

                if (result != null)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Cancelled), result);
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


        //-------------------------------------InsertOrderProductRating----------------------------------------------//
        [System.Web.Http.Route("api/Order/InsertOrderProductRating")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult InsertOrderProductRating(OrderProductRating OrderProductRatingObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                //DataSet dss = new DataSet();
                result = OrderRepositoryObj.InsertOrderProductRating(OrderProductRatingObj);

                if (result != null)
                {
                    response = response.Create(true, "FeedBack Submited Successfully", result);
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


        //--------------------------------------------//GetOrderProductByInoviceId //------------------------------------------//
        [System.Web.Http.Route("api/Order/GetOrderProductByInoviceId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetOrderProductByInoviceId(OrderProductConduction OrderProductConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<OrderProduct>> response = new ResponseStatus<List<OrderProduct>>();
            List<OrderProduct> OrderProductObj = new List<Models.Order.OrderProduct>();

            try
            {
                ds = OrderRepositoryObj.GetOrderProductByInoviceId(OrderProductConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var OrderProductObjItem = new OrderProduct()
                        {
                            CartId = (int)dr["CartId"],
                            ProductId = (int)dr["ProductId"],
                            Rate = (Double)dr["Rate"],
                            Qty = (Double)dr["Qty"],
                            ServiceName = (string)dr["ServiceName"],
                            ServiceImage = (string)dr["ServiceImage"],

                        };
                        OrderProductObj.Add(OrderProductObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, OrderProductObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<OrderProduct>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.FormatMessage(RespMessage.DataNotFound), OrderProductObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<OrderProduct>>(response, HttpStatusCode.OK);


                }

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, OrderProductObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<OrderProduct>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }


        [System.Web.Http.Route("api/Order/GetOrderVolumeDetels")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Response>>))]
        public IHttpActionResult GetOrderVolumeDetels(OrderVolumeDetels OrderVolumeDetelsObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                //DataSet dss = new DataSet();
                result = OrderRepositoryObj.GetOrderVolumeDetels(OrderVolumeDetelsObj);

                if (result != null)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Cancelled), result);
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

        //--------------------------------------------GetOTPVerification------------------------------------------//---------------------//--
        [System.Web.Http.Route("api/Order/SendEmail")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult SendEmail(SendEmail SendEmailObj)
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
                    message.Subject = "Email test";
                    message.To.Add(new MailAddress("gauravgupta11489@gmail.com"));
                    message.Body = "<html><body>Test Email </body></html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);

                    response = response.Create(true, "Email Sent Successfully", 1);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.OK);


                

            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Result);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }

            return responseIHttpActionResult;
        }

    }
}

