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
using Transnational.Models.ServiceAndProduct;
using Transnational.Repository.ServiceAndProduct;
using Transnational.Service;
using Transnational.VM;

namespace Transnational.Controllers.ServiceAndproduct
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceAndProductController : ApiController
    {

        static ServiceAndProductRepository ServiceAndProductRepositoryObj = new ServiceAndProductRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;

        public object ReturnService { get; private set; }
        public object Object { get; private set; }

        [System.Web.Http.Route("api/ServiceAndProduct/GetBussinessLinebyContact")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<BusinesslineByContact>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetBussinessLinebyContact(BusinesslineByContactConduction BusinesslineByContactConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<BusinesslineByContact>> response = new ResponseStatus<List<BusinesslineByContact>>();
            List<BusinesslineByContact> BusinesslineByContactObj = new List<Models.ServiceAndProduct.BusinesslineByContact>();
            try
            {


                ds = ServiceAndProductRepositoryObj.GetBussinessLinebyContact(BusinesslineByContactConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var BusinesslineByContactObjitem = new BusinesslineByContact()
                        {
                            BusinessLineId = (int)dr["BusinessLineId"],
                            BusinessLine = (string)dr["BusinessLine"],
                            PictureFileName = (string)dr["PictureFileName"],
                            IconFileName = (string)dr["IconFileName"],
                            LevelId = (Double)dr["LevelId"],
                            CompanyId = (int)dr["CompanyId"],
                            SubscriptionStatus = (string)dr["SubscriptionStatus"],
                            Description = (String)dr["Description"]


                        };
                        BusinesslineByContactObj.Add(BusinesslineByContactObjitem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, BusinesslineByContactObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<BusinesslineByContact>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.Fail, BusinesslineByContactObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<BusinesslineByContact>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, BusinesslineByContactObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<BusinesslineByContact>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/ServiceAndProduct/GetContractByBusinessLineId_CompanyId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<ContractByBusinessLineId_CompanyId>>))]
        //read the ContractByBusinessLineId_CompanyIdConductionObj paramerter object
        public IHttpActionResult GetContractByBusinessLineId_CompanyId(ContractByBusinessLineId_CompanyIdConduction ContractByBusinessLineId_CompanyIdConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ContractByBusinessLineId_CompanyId>> response = new ResponseStatus<List<ContractByBusinessLineId_CompanyId>>();
            List<ContractByBusinessLineId_CompanyId> ContractByBusinessLineId_CompanyIdObj = new List<Models.ServiceAndProduct.ContractByBusinessLineId_CompanyId>();
            try
            {
                ds = ServiceAndProductRepositoryObj.GetContractByBusinessLineId_CompanyId(ContractByBusinessLineId_CompanyIdConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ContractByBusinessLineId_CompanyIditem = new ContractByBusinessLineId_CompanyId()
                        {
                            ContractId = (int)dr["ContractId"],
                            CompanyId = (int)dr["CompanyId"],
                            ContractNo = (string)dr["ContractNo"],
                            ContractDescription = (string)dr["ContractDescription"],
                            BusinessLineId = (int)dr["BusinessLineId"],
                            SubBusinessLineId = (int)dr["SubBusinessLineId"],
                            BillingEmail = (string)dr["BillingEmail"],
                            BillingAddress = (string)dr["Address"],
                           
                        };
                        ContractByBusinessLineId_CompanyIdObj.Add(ContractByBusinessLineId_CompanyIditem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ContractByBusinessLineId_CompanyIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContractByBusinessLineId_CompanyId>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, ContractByBusinessLineId_CompanyIdObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContractByBusinessLineId_CompanyId>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                // response = response.Create(false, ex.ToString(), ContractByBusinessLineId_CompanyIdobj);
                response = response.Create(false, RespMessage.ServerError, ContractByBusinessLineId_CompanyIdObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ContractByBusinessLineId_CompanyId>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/ServiceAndProduct/InsertBusinesslineSubscription")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult InsertBusinesslineSubcribion(InsertBusinesslineSubcribion InsertBusinesslineSubcribionObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object InsertBusinesslineSubcribionobj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = ServiceAndProductRepositoryObj.InsertBusinesslineSubcribion(InsertBusinesslineSubcribionObj);

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
                response = response.Create(false, RespMessage.ServerError, InsertBusinesslineSubcribionobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/ServiceAndProduct/GetServicesByContract")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<BusinesslineByContact>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetServicesByContract(ServicesByContractConduction ServicesByContractConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ServicesByContract>> response = new ResponseStatus<List<ServicesByContract>>();
            List<ServicesByContract> ServicesByContractObj = new List<Models.ServiceAndProduct.ServicesByContract>();
            try
            {

                ds = ServiceAndProductRepositoryObj.GetServicesByContract(ServicesByContractConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        Object NewPriceN = dr["NewPriceRateMatrix"];
                        Object NewPrice1 = dr["NewPrice"];
                       

                        if (Convert.ToDouble(NewPriceN) > 0)
                        {
                            NewPriceN = Convert.ToDouble(NewPriceN);
                        }
                        else
                        {
                            NewPriceN = Convert.ToDouble(NewPrice1);
                        }
                        var ServicesByContractObjitem = new ServicesByContract()
                        {
                            BusinessLine = (string)dr["BusinessLine"],
                            SubBusinessLine = (string)dr["SubBusinessLine"],
                            ServiceId = (int)dr["ServiceId"],
                            ServiceName = (string)dr["ServiceName"],
                            NewPrice = (Double)NewPriceN,
                            IsSelected = (bool)dr["IsSelected"],
                            ServiceUnavailableID = (int)dr["ServiceUnavailableID"],
                            ReturnService = Convert.ToBoolean(dr["ReturnService"]),
                            ReturnServiceType = (int)dr["ReturnServiceType"],//Return Service Id
                        };
                        ServicesByContractObj.Add(ServicesByContractObjitem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ServicesByContractObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ServicesByContract>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.Fail, ServicesByContractObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ServicesByContract>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, ServicesByContractObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ServicesByContract>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/ServiceAndProduct/GetAllProduct")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Products>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllProduct(ProductConduction ProductConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Products>> response = new ResponseStatus<List<Products>>();
            List<Products> ProductObj = new List<Models.ServiceAndProduct.Products>();
            try
            {
                String SubBusinessLineId_str = "";
                for (int i = 0; i < ProductConductionObj.SubBusinessLineIdsObjlst.Count; i++)
                {
                    if (i == 0)

                        SubBusinessLineId_str = "'" + ProductConductionObj.SubBusinessLineIdsObjlst[i].SubBusinessLineId.ToString() + "'";
                    else
                        SubBusinessLineId_str = SubBusinessLineId_str + "," + "'" + ProductConductionObj.SubBusinessLineIdsObjlst[i].SubBusinessLineId.ToString() + "'";
                }

                ds = ServiceAndProductRepositoryObj.GetAllProduct(ProductConductionObj, SubBusinessLineId_str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ProductObjItem = new Products()
                        {
                            ProductAnnouncementId = (Object)dr["ProductAnnouncementId"],
                            BusinessLineId = (int)dr["BusinessLineId"],
                            BusinessLine = (string)dr["BusinessLine"],
                            SubBusinessLineId = (int)dr["SubBusinessLineId"],
                            SubBusinessLine = (string)dr["SubBusinessLine"],
                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            ContractId = (int)dr["ContractId"],
                            ServiceId = (int)dr["ServiceId"],
                            ServiceName = (string)dr["ServiceName"],
                            ServiceImage = (string)dr["ServiceImage"],
                            NewPrice = (Double)dr["NewPrice"],
                            Status=(string)dr["Status"],
                            Description = (string)dr["Description"],
                            ShortDescription = (string)dr["ShortDescription"],
                            ProductAnnouncementDescription = (string)dr["ProductAnnouncementDescription"],
                            AccessRight = (string)dr["AccessRight"],
                            //ProductAnnounceMentImage = (string)dr["ProductAnnounceMentImage"],


                        };
                        ProductObj.Add(ProductObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ProductObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.Fail, ProductObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, ProductObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Products>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/ServiceAndProduct/InsertAddtoMyCart")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult InsertAddtoMyCart(AddtoMyCart InsertAddtoMyCartObj)
        {
            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object InsertAddtoMyCartobj = new object();
            try
            {
                DataSet dss = new DataSet();
                bool result = false;


                int ItemFound = ServiceAndProductRepositoryObj.GetMyCartByProduct(InsertAddtoMyCartObj);
                if (ItemFound > 0)
                {
                    result = ServiceAndProductRepositoryObj.UpdateMyCart(InsertAddtoMyCartObj);
                }
                else
                {
                    result = ServiceAndProductRepositoryObj.InsertAddtoMyCart(InsertAddtoMyCartObj);
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
                response = response.Create(false, RespMessage.ServerError, InsertAddtoMyCartobj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/ServiceAndProduct/DeleteMyCart")]
        [System.Web.Http.HttpDelete]

        public IHttpActionResult DeleteMyCart(DeleteMyCart DeleteMyCartObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object DeleteMyCartObjObj = new object();
            try
            {

                DataSet dss = new DataSet();
                bool result = ServiceAndProductRepositoryObj.DeleteMyCart(DeleteMyCartObj);

                if (result == true)
                {
                    response = response.Create(true, RespMessage.FormatMessage(RespMessage.Delete) , result);
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
                response = response.Create(false, RespMessage.ServerError, DeleteMyCartObjObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<Object>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/ServiceAndProduct/GetMyCartItem")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Products>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetMyCartItem(MyCartItemConduction MyCartItemConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<MyCartItem>> response = new ResponseStatus<List<MyCartItem>>();
            List<MyCartItem> MyCartItemObj = new List<Models.ServiceAndProduct.MyCartItem>();
            try
            {
                ds = ServiceAndProductRepositoryObj.GetMyCartItem(MyCartItemConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var MyCartItemObjItem = new MyCartItem()
                        {
                            CartId = (int)dr["CartId"],
                            CartUserId = (int)dr["CartUserId"],
                            ProductId = (int)dr["ProductId"],
                            Qty = (Double)dr["Qty"],
                            Rate = (Double)dr["Rate"],
                            ProductName = (string)dr["ProductName"],
                            NewPrice = (Double)dr["NewPrice"],
                            ServiceImage= (string)dr["ServiceImage"],
                        };
                        MyCartItemObj.Add(MyCartItemObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, MyCartItemObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<MyCartItem>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, MyCartItemObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<MyCartItem>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, MyCartItemObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<MyCartItem>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;


        }
       
        [System.Web.Http.Route("api/ServiceAndProduct/GetProductAnnouncement")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<Deliveryoptions>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetProductAnnouncement(ProductAnnouncementConduction ProductAnnouncementConductionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<ProductAnnouncement>> response = new ResponseStatus<List<ProductAnnouncement>>();
            List<ProductAnnouncement> ProductAnnouncementObj = new List<Models.ServiceAndProduct.ProductAnnouncement>();
            try
            {
                ds = ServiceAndProductRepositoryObj.GetProductAnnouncement(ProductAnnouncementConductionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ProductAnnouncementObjItem = new ProductAnnouncement()
                        {

                            ProductAnnouncementId = (int)dr["ProductAnnouncementId"],
                            BusinessLineId = (int)dr["BusinessLineId"],
                            BusinessLine = (string)dr["BusinessLine"],
                            SubBusinessLineId = (int)dr["SubBusinessLineId"],
                            SubBusinessLine = (string)dr["SubBusinessLine"],

                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            //ProductName = (string)dr["ProductName"],
                            //ProductId = (int)dr["ProductId"],
                            ProductAnnouncementDescription = (string)dr["ProductAnnouncementDescription"],
                            Description = (string)dr["Description"],
                            ShortDescription = (string)dr["ShortDescription"],
                            
                            //ProductImage = (string)dr["ProductImage"],
                            Status = (string)dr["Status"],
                            ServiceId = (int)dr["ServiceId"],
                            ServiceName = (string)dr["ServiceName"],
                            ServiceImage = (string)dr["ServiceImage"],

                            NewPrice = (double)dr["NewPrice"],
                            ContractId = (int)dr["ContractId"],
                            AccessRight = (string)dr["AccessRight"],
                        };
                        ProductAnnouncementObj.Add(ProductAnnouncementObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ProductAnnouncementObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductAnnouncement>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.DataNotFound, ProductAnnouncementObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductAnnouncement>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                //response = response.Create(false, ex.ToString(), BusinesslineByContact);
                response = response.Create(false, RespMessage.ServerError, ProductAnnouncementObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductAnnouncement>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        //----------------------------------GetProductRating--------------------------------------//--
        [System.Web.Http.Route("api/ServiceAndProduct/GetProductRating")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetProductRating(ProductRatingConduction ProductRatingConductionObj)
        {

            DataSet ds = new DataSet();
            ResponseStatus<List<ProductRating>> response = new ResponseStatus<List<ProductRating>>();
            List<ProductRating> ProductRatingObj = new List<Models.ServiceAndProduct.ProductRating>();
            try
            {
                //DataSet dss = new DataSet();
                ds = ServiceAndProductRepositoryObj.GetProductRating(ProductRatingConductionObj);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        var ProductRatingObjItem = new ProductRating()
                        {
                            ProductId = (int)dr["ProductId"],
                            Rating = (Double)dr["Rating"],
                            Total = (int)dr["Total"],
                            percentage = (int)Convert.ToDouble(dr["percentage"]),
                        };

                        ProductRatingObj.Add(ProductRatingObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ProductRatingObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductRating>>(response, HttpStatusCode.OK);
                }


                else
                {
                    response = response.Create(true, RespMessage.DataNotFound, ProductRatingObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductRating>>(response, HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, ProductRatingObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductRating>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //----------------------------------------------------GetSubBusinessLine---------------------------------------------------//----

        [System.Web.Http.Route("api/ServiceAndProduct/GetSubBusinessLine")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetSubBusinessLine(SubBusinessLineConduction SubBusinessLineConductionObj)
        {

            DataSet ds = new DataSet();
            ResponseStatus<List<SubBusinessLines>> response = new ResponseStatus<List<SubBusinessLines>>();
            List<SubBusinessLines> SubBusinessLineObj = new List<Models.ServiceAndProduct.SubBusinessLines>();
            try
            {
                //DataSet dss = new DataSet();
                ds = ServiceAndProductRepositoryObj.GetSubBusinessLine(SubBusinessLineConductionObj);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        var SubBusinessLineObjItem = new SubBusinessLines()
                        {
                            BusinessLineId = (int)dr["BusinessLineId"],
                            BusinessLine = (string)dr["BusinessLine"],
                            SubBusinessLineId = (int)dr["SubBusinessLineId"],
                            SubBusinessLine = (string)dr["SubBusinessLine"],
                        };

                        SubBusinessLineObj.Add(SubBusinessLineObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, SubBusinessLineObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<SubBusinessLines>>(response, HttpStatusCode.OK);
                }


                else
                {
                    response = response.Create(true, RespMessage.DataNotFound, SubBusinessLineObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<SubBusinessLines>>(response, HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, SubBusinessLineObj);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<SubBusinessLines>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //-----------------------------------------------------GetSubBusinessLineEnd----------------------------------------//------------------------------

        [System.Web.Http.Route("api/ServiceAndProduct/GetAllServices")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult GetAllServices(AllServices AllServicesObj)
        {

            ResponseStatus<Object> response = new ResponseStatus<Object>();
            object result = new object();
            try
            {

                DataSet dss = new DataSet();
                 result = ServiceAndProductRepositoryObj.GetAllServices(AllServicesObj);

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
    }

}
