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
using Transnational.Models.Country;
using Transnational.Repository.Country;
using Transnational.Service;
using System.Web.Http.Cors;

namespace Transnational.Controllers.Country
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CountryController : ApiController
    {

        static CountryRepository repository = new CountryRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Country/GetAllCountry/{dbParam}/{LanguageId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Countrys>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCountry(string dbParam, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Countrys>> response = new ResponseStatus<List<Countrys>>();
            List<Countrys> Countrys = new List<Models.Country.Countrys>();
            try
            {
                //if (dbParam == "Teamwork-SG-v2UAT")
                if (dbParam == "Teamwork_CRM_UAT")
                {
                    ds = repository.GetCountry(dbParam, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Countrys()
                        {
                            CountryId = (int)dr["CountryId"],
                            CountryName = (string)dr["CountryName"],

                        };
                        Countrys.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Countrys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Countrys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), Countrys);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }





        // ==============================================================================================================================
        [System.Web.Http.Route("api/City/GetAllCity/{dbParam}/{CountryId}/{LanguageId}")]
        [System.Web.Http.HttpGet]

        [ResponseType(typeof(ResponseStatus<List<Citys>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCity(string dbParam, int CountryId, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Citys>> response = new ResponseStatus<List<Citys>>();
            List<Citys> Citys = new List<Models.Country.Citys>();
            try
            {
               // if (dbParam == "Teamwork-SG-v2UAT")
                if (dbParam == "Teamwork_CRM_UAT")
                {
                    ds = repository.GetCity(dbParam, CountryId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Citys()
                        {
                            StateName = (string)dr["StateName"],
                            StateId = (int)dr["StateId"],

                        };
                        Citys.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Citys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Citys>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Citys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Citys>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Citys);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Citys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        //==========================================================================

        [System.Web.Http.Route("api/District/GetAllDistrict/{dbParam}/{StateID}/{LanguageId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Districts>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllDistrict(int StateID, int LanguageId, string dbParam)

        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Districts>> response = new ResponseStatus<List<Districts>>();
            List<Districts> District = new List<Models.Country.Districts>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetDistrict(dbParam,StateID, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Districts()
                        {
                            ZoneName = (string)dr["ZoneName"],
                            ZoneId = (int)dr["ZoneId"],


                        };
                        District.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, District);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Districts>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, District);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Districts>>(response, HttpStatusCode.InternalServerError);
                }
            }


            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, District);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Districts>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //=======================================================================================================
        [System.Web.Http.Route("api/Zone/GetAllZone/{dbParam}/{ZoneId}/{LanguageId}")]

        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Zones>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllZone(int ZoneId, int LanguageId, string dbParam)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Zones>> response = new ResponseStatus<List<Zones>>();
            List<Zones> Zone = new List<Models.Country.Zones>();
            try
            {
                if (dbParam == "SGP")
                {

                    ds = repository.GetZone(dbParam,ZoneId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Zones()
                        {
                            CityName = (string)dr["CityName"],
                            CityId = (int)dr["CityId"],

                        };
                        Zone.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Zone);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Zones>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Zone);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Zones>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Zone);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Zones>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



        }
        //===============================================//navdeep//===========================//============================================//============================

        [System.Web.Http.Route("api/PostalCode/GetDistrictCountPostalCode/{dbParam}/{ZoneId}/{LanguageId}")]

        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<DistrictPostalCodes>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetDistrictCountPostalCode(string dbParam, int ZoneId, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<DistrictPostalCodes>> response = new ResponseStatus<List<DistrictPostalCodes>>();
            List<DistrictPostalCodes> PostalCode = new List<Models.Country.DistrictPostalCodes>();
            try
            {

                if (dbParam == "SGP")
                {

                    ds = repository.GetDistrictCountPostalCode(dbParam, ZoneId, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new DistrictPostalCodes()
                        {
                            count = (int)dr["count"]

                        };
                        PostalCode.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, PostalCode);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/PostalCode/GetDemoGraphicalTag/{dbParam}/{DistrictId}")]

        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<DemoGraphicalTags>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetDemoGraphicalTag(string dbParam, int DistrictId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<DemoGraphicalTags>> response = new ResponseStatus<List<DemoGraphicalTags>>();
            List<DemoGraphicalTags> PostalCode = new List<Models.Country.DemoGraphicalTags>();
            try
            {

                if (dbParam == "SGP")
                {

                    ds = repository.GetDemoGraphicalTag(dbParam, DistrictId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new DemoGraphicalTags()
                        {
                            CityId = (int)dr["CityId"],
                            StateId = (int)dr["StateId"],
                            CountryId = (int)dr["CountryId"]


                        };
                        PostalCode.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DemoGraphicalTags>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DemoGraphicalTags>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, PostalCode);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<DemoGraphicalTags>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }

        [System.Web.Http.Route("api/PostalCode/GetDistrictPostalCode/{dbParam}/{ZoneId}/{LanguageId}")]

        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<DistrictPostalCodes>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetDistrictPostalCode(string dbParam, int LanguageId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<DistrictPostalCodes>> response = new ResponseStatus<List<DistrictPostalCodes>>();
            List<DistrictPostalCodes> PostalCode = new List<Models.Country.DistrictPostalCodes>();
            try
            {

                if (dbParam == "SGP")
                {

                    ds = repository.GetDistrictPostalCode(dbParam, LanguageId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new DistrictPostalCodes()
                        {
                            //count = (int)dr["count"]
                            Latitude = (string)dr["Latitude"]

                        };
                        PostalCode.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, PostalCode);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, PostalCode);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<DistrictPostalCodes>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
    }
}





    

