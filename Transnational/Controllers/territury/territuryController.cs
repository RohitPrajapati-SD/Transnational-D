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
using Transnational.Models.territory;
using Transnational.Repository.territury;
using Transnational.Service;
using Address = Transnational.Models.territory.Address;

namespace Transnational.Controllers.territury
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class territuryController : ApiController
    {
        static territuryRepository territuryRepositoryobj = new territuryRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;


        [System.Web.Http.Route("api/Country/GetAllCountries")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Countries>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCountry(Countries Countriesobj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Countries>> response = new ResponseStatus<List<Countries>>();
            List<Countries> Countrys = new List<Models.territory.Countries>();

            try
            {
                
              
                if (Countriesobj.CD == String .Empty)
                {
                    //Countriesobj.CD = "Teamwork-SG-v2UAT";
                    Countriesobj.CD = "Teamwork_CRM_UAT";
                }

                ds = territuryRepositoryobj.GetCountry(Countriesobj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var CountriesobjItem = new Countries()
                        {
                            CountryId = (int)dr["CountryId"],
                            CountryName = (string)dr["CountryName"],
                            DDLCode = (string)dr["DDLCode"],
                        };
                        Countrys.Add(CountriesobjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Countrys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countries>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.Fail, Countrys);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countries>>(response, HttpStatusCode.InternalServerError);
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
        [System.Web.Http.Route("api/Address/GetAddressByPostalCode")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Address>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAddress(Address AddressObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Address>> response = new ResponseStatus<List<Address>>();
            List<Address> addresses = new List<Models.territory.Address>();

            try
            {

                if (AddressObj.CD == String.Empty)
                {
                    //AddressObj.CD = "Teamwork-SG-v2UAT";
                    AddressObj.CD = "Teamwork_CRM_UAT";
                }

                ds = territuryRepositoryobj.GetAddress(AddressObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var AddressObjItem = new Address()
                        {
                            CountryId = (int)dr["CountryId"],
                            ZoneId = (int)dr["ZoneId"],
                            Address1 = (string)dr["Address1"],
                            Address2 = (string)dr["Address2"],
                            Address3 = (string)dr["Address3"],
                            Latitude = (string)dr["Latitude"],
                            Longitude = (string)dr["Longitude"],
                            CityId = (int)dr["CityId"],
                            StateId = (int)dr["StateId"],
                            PostalCode = (string)dr["PostalCode"],
                            PostalCodeTo = (string)dr["PostalCodeTo"],

                        };
                        addresses.Add(AddressObjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, addresses);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Address>>(response, HttpStatusCode.OK);
                }





                else
                {
                    response = response.Create(false, RespMessage.Fail, addresses);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Address>>(response, HttpStatusCode.InternalServerError);
                }
            }

            catch (Exception ex)

            {
                //response = response.Create(false, ex.ToString(), addresses);
                response = response.Create(false, RespMessage.ServerError, addresses);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Address>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/City/GetCityByCountryId")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(ResponseStatus<List<Cities>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCity(Cities Citiesobj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Cities>> response = new ResponseStatus<List<Cities>>();
            List<Cities> City = new List<Models.territory.Cities>();

            try
            {


                if (Citiesobj.CD == String.Empty)
                {
                    //Citiesobj.CD = "Teamwork-SG-v2UAT";
                    Citiesobj.CD = "Teamwork_CRM_UAT";
                }

                ds = territuryRepositoryobj.GetAllCity(Citiesobj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var CitiesobjItem = new Cities()
                        {
                            CityId = (int)dr["StateId"],
                            CityName = (string)dr["StateName"],
                            


                        };
                        City.Add(CitiesobjItem);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, City);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Cities>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.Fail, City);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Cities>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), City);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }

        //--------------------------------------------------Getdistinct---------------------------------------------------------------------//----------- 
        [System.Web.Http.Route("api/Country/GetDistrict")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<Countries>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetDistrict(DistrictCondition DistrictConditionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<District>> response = new ResponseStatus<List<District>>();
            List<District> DistrictObj = new List<Models.territory.District>();

            try
            {
                {

                    ds = territuryRepositoryobj.GetDistrict(DistrictConditionObj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            var DistrictObjItm = new District()
                            {
                                DistrictId = (int)dr["ZoneId"],
                                DistrictName = (string)dr["ZoneName"],



                            };
                            DistrictObj.Add(DistrictObjItm);
                        }
                        response = response.Create(true, RespMessage.DataSuccess, DistrictObj);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<List<District>>(response, HttpStatusCode.OK);
                    }

                    else
                    {
                        response = response.Create(false, RespMessage.Fail, DistrictObj);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<List<District>>(response, HttpStatusCode.InternalServerError);
                    }
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), DistrictObj);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        //------------------------------------------------GetZone------------------------------------------------------------------//----------

        [System.Web.Http.Route("api/Country/GetZone")]
        [System.Web.Http.HttpPost]
        //[ResponseType(typeof(ResponseStatus<List<Countries>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetZone(ZoneCondition ZoneConditionObj)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Zone>> response = new ResponseStatus<List<Zone>>();
            List<Zone> ZoneObj = new List<Models.territory.Zone>();

            try
            {

                ds = territuryRepositoryobj.GetZone(ZoneConditionObj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var ZoneObjItm = new Zone()
                        {
                            ZoneId = (int)dr["CityId"],
                            ZoneName = (string)dr["CityName"],



                        };
                        ZoneObj.Add(ZoneObjItm);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, ZoneObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Zone>>(response, HttpStatusCode.OK);
                }

                else
                {
                    response = response.Create(false, RespMessage.Fail, ZoneObj);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Zone>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)

            {
                response = response.Create(false, ex.ToString(), ZoneObj);
                //response = response.Create(false, RespMessage.ServerError, Countrys);
                //responseIHttpActionResult = new Converter().ApiResponseMessage<List<Countrys>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }


    }
}
