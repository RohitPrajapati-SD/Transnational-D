//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using Transnational.ApiMessage;
//using Transnational.Models;
////using Transnational.Models;
//using Transnational.Repository;
////using Transnational.Repository.Address;
//using Transnational.Service;

//namespace Transnational.Controllers.AddressController
//{
//    public class AddressController : ApiController
//    {
//        static AddressRepository repository = new AddressRepository();
//        // private ITaskManagementService _iTaskService;
//        private IHttpActionResult responseIHttpActionResult;


//        [System.Web.Http.Route("api/Address/GetAddressByPostalCode")]
//        [System.Web.Http.HttpGet]
//        [ResponseType(typeof(ResponseStatus<List<Address>>))]
//        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
//        public IHttpActionResult GetAddress(Address obj)
//        {
//            DataSet ds = new DataSet();
//            ResponseStatus<List<Address>> response = new ResponseStatus<List<Address>>();
//            List<Address> addresses = new List<Models.Address>();

//            try
//            {
//                string CD = obj.CD;
//                //if (dbParam == "Teamwork-SG-v2UAT")
//                //{
//                ds = repository.GetAddress(obj);
//                if (ds.Tables[0].Rows.Count > 0)
//                {
//                    foreach (DataRow dr in ds.Tables[0].Rows)
//                    {
//                        var temp = new Address()
//                        {
//                            CountryId = (int)dr["CountryId"],
//                            ZoneId = (int)dr["ZoneId"],
//                            Address1 = (string)dr["Address1"],
//                            Address2 = (string)dr["Address2"],
//                            Address3 = (string)dr["Address3"],
//                            Latitude = (string)dr["Latitude"],
//                            Longitude = (string)dr["Longitude"],
//                            CityId = (int)dr["CityId"],
//                            StateId = (int)dr["StateId"],
//                            PostalCode = (string)dr["PostalCode"],
//                            PostalCodeTo = (string)dr["PostalCodeTo"],

//                        };
//                        addresses.Add(temp);
//                    }
//                    response = response.Create(true, RespMessage.DataSuccess, addresses);
//                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Address>>(response, HttpStatusCode.OK);
//                }





//                else
//                {
//                    response = response.Create(false, RespMessage.Fail, addresses);
//                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Address>>(response, HttpStatusCode.InternalServerError);
//                }
//            }

//            catch (Exception ex)

//            {
//                response = response.Create(false, ex.ToString(), addresses);
//                //response = response.Create(false, RespMessage.ServerError, Countrys);
//                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
//            }
//            return responseIHttpActionResult;

//        }
    
//        [System.Web.Http.Route("api/Product/ProductSubscriptionByContactId")]
//        [System.Web.Http.HttpGet]
//        [ResponseType(typeof(ResponseStatus<List<ProductSubscription>>))]
//        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
//        public IHttpActionResult GetProductSubscription(ProductSubscription obj)
//        {
//            DataSet ds = new DataSet();
//            ResponseStatus<List<ProductSubscription>> response = new ResponseStatus<List<ProductSubscription>>();
//            List<ProductSubscription> addresses = new List<Models.ProductSubscription>();

//            try
//            {
//                string CD = obj.CD;
//                //if (dbParam == "Teamwork-SG-v2UAT")
//                //{
//                ds = repository.GetProductSubscription(obj);
//                if (ds.Tables[0].Rows.Count > 0)
//                {
//                    foreach (DataRow dr in ds.Tables[0].Rows)
//                    {
//                        var temp = new ProductSubscription()
//                        {
//                            SubscriptionUserId = (int)dr["SubscriptionUserId"],
//                            Description = (string)dr["Description"],
//                            Name = (string)dr["Name"],
//                           // LevelId = (int)dr["LevelId"],
//                            WebSflag = (bool)dr["WebSflag"],

                           

//                        };
//                        addresses.Add(temp);
//                    }
//                    response = response.Create(true, RespMessage.DataSuccess, addresses);
//                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductSubscription>>(response, HttpStatusCode.OK);
//                }





//                else
//                {
//                    response = response.Create(false, RespMessage.Fail, addresses);
//                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<ProductSubscription>>(response, HttpStatusCode.InternalServerError);
//                }
//            }

//            catch (Exception ex)

//            {
//                response = response.Create(false, ex.ToString(), addresses);
//                //response = response.Create(false, RespMessage.ServerError, Countrys);
//                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
//            }
//            return responseIHttpActionResult;

//        }



//    }
//}
