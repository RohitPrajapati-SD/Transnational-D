using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Transnational.ApiMessage;
using Transnational.Models;
using Transnational.Repository.Customer;
using Transnational.Service;
using System.Web.Http.Cors;

namespace Transnational.Controllers.Customer
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        static CustomerRepository repository = new CustomerRepository();
        // private ITaskManagementService _iTaskService;
        private IHttpActionResult responseIHttpActionResult;

        [System.Web.Http.Route("api/Customer/GetAllCustomer/{dbParam}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Customers>>))]
        public IHttpActionResult GetAllCustomer(string dbParam)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Customers>> response = new ResponseStatus<List<Customers>>();
            List<Customers> customer = new List<Models.Customers>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCustomer(dbParam);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Customers()
                        {
                            CompanyId = (int)dr["CompanyId"],
                            CustomerName = (string)dr["CustomerName"],
                            NickName = (string)dr["NickName"],
                            ContactPerson = (string)dr["ContactPerson"]
                        };
                        customer.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.Unsuccessful, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, customer);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }

    
        [System.Web.Http.Route("api/Customer/GetAllDepartment/{dbParam}/{ContactId}/{ContractId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Department>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllDepartment(string dbParam, int ContactId, int ContractId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Department>> response = new ResponseStatus<List<Department>>();
            List<Department> department = new List<Models.Department>();
            try
            {

                if (dbParam == "SGP")
                {
                    ds = repository.GetDepartment(dbParam, ContactId, ContractId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Department()
                        {
                            BranchName = (string)dr["BranchName"],
                            CBranchId = (int)dr["CBranchId"],

                        };
                        department.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, department);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Department>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, department);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Department>>(response, HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, department);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Department>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }


        //////////////////////////////////navdeep//////////////////////////////////////



        [System.Web.Http.Route("api/Customer/GetAllCustomerById/{dbParam}/{CustomerId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Customers>>))]

        public IHttpActionResult GetAllCustomerById(string dbParam, int CustomerId)


       {
            DataSet ds = new DataSet();
            ResponseStatus<List<Customers>> response = new ResponseStatus<List<Customers>>();
            List<Customers> customer = new List<Models.Customers>();
            try
            {
                if (dbParam == "SGP")

                {
                    ds = repository.GetCustomerById(dbParam, CustomerId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        
                        var temp = new Customers()
                        {


                            CompanyId = (int)dr["CompanyId"],
                            CustomerName = (string)dr["CustomerName"],
                            NickName = (string)dr["NickName"],
                            ContactTypeId = (int)dr["ContactTypeId"],
                           // x = y ?? z ;
                             // Tel = (dr["Tel"]== null) ? "" : (string)dr["Tel"] ,
                            Tel = (string)dr["Tel"],
                            Fax = (string)dr["Fax"],
                            ZoneId = (int)dr["Zoneid"],
                            CustomerGroupId = (int)dr["CustomerGroupId"],
                            CustomerCategoryId = (int)dr["CustomerCategoryId"],
                            CustomerTypeId = (int)dr["CustomerTypeId"],
                            KeyAccountManager = (int)dr["KeyAccountManager"],
                            EnquirySourceId = (int)dr["EnquirySourceId"],
                            CustomerStatusId = (int)dr["CustomerStatusId"],
                            CreatedDate = (DateTime)dr["CreatedDate"],
                            Portfolio = (bool)dr["Portfolio"],
                            BusinessUnitId = (int)dr["BusinessUnitId"],
                            CustomerId = (string)dr["CustomerId"],
                            LUDate = (DateTime)dr["LUDate"],
                            LUBy = (int)dr["LUBy"],
                            LanguageId = (int)dr["LanguageId"],
                            ActiveSince = (DateTime)dr["ActiveSince"],
                            UnFreezeSince = (DateTime)dr["UnFreezeSince"],
                            ICompanySales = (bool)dr["ICompanySales"],
                            Active = (bool)dr["Active"],
                            CompanyLogo = (string)dr["CompanyLogo"],
                            CreatedBy = (int)dr["CreatedBy"],
                            CreditAmount = (double)dr["CreditAmount"],
                            DepositAmount = (double)dr["DepositAmount"],
                            ContactPerson = (string)dr["ContactPerson"],
                            SendSms = (bool)dr["SendSms"],
                            SendEmail = (bool)dr["SendEmail"],
                            CCenter_on_orderPage = (bool)dr["CCenter_on_orderPage"]


                        };
                        customer.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {

                response = response.Create(false, RespMessage.ServerError, customer);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }


        [System.Web.Http.Route("api/Customer/GetAllCustomerBySearch/{dbParam}/{SearchData}/{CompanyId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Customers>>))]
        public IHttpActionResult GetAllCustmorBySearch(string dbParam, string SearchData, int CompanyId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Customers>> response = new ResponseStatus<List<Customers>>();
            List<Customers> customer = new List<Models.Customers>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCustomerBySearch(dbParam, SearchData, CompanyId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Customers()
                        {
                            CompanyId = (int)dr["CompanyId"],
                            CustomerName = (string)dr["CustomerName"]
                        };
                        customer.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, customer);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        [System.Web.Http.Route("api/Customer/GetAllCustomerBySearch1/{dbParam}/{SearchData}/{CompanyId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Customers>>))]
        public IHttpActionResult GetAllCustmorBySearch1(string dbParam, string SearchData, int CompanyId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Customers>> response = new ResponseStatus<List<Customers>>();
            List<Customers> customer = new List<Models.Customers>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCustomerBySearch1(dbParam, SearchData, CompanyId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Customers()
                        {
                            CompanyId = (int)dr["CompanyId"],
                            CustomerName = (string)dr["CustomerName"]
                        };
                        customer.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, customer);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }

        //================================end=================================


        [System.Web.Http.Route("api/Customer/GetAllCompanyBranch/{dbParam}/{CBranchId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<CompanyBranch>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCompanyBranch(string dbParam, int CBranchId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<CompanyBranch>> response = new ResponseStatus<List<CompanyBranch>>();
            List<CompanyBranch> CompanyBranch = new List<Models.CompanyBranch>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetAllCompanyBranch(dbParam, CBranchId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new CompanyBranch()
                        {
                            Mobile = (string)dr["Mobile"],

                            Phone = (string)dr["Phone"],
                            CompanyId = (int)dr["CompanyId"],
                            CurrencyId = (int)dr["CurrencyId"]



                        };
                        CompanyBranch.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CompanyBranch);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyBranch>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, CompanyBranch);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyBranch>>(response, HttpStatusCode.InternalServerError);
                }
            }

            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CompanyBranch);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyBranch>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



        }
        //=====================================companyaddressbook=======================================


        [System.Web.Http.Route("api/Customer/DContactAddress/{dbParam}/{ContactId}/{Delivery}/{CustomerId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<DContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult DContactAddress(string dbParam, int ContactId, int Delivery, int CustomerId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<DContactAddress>> response = new ResponseStatus<List<DContactAddress>>();
            List<DContactAddress> CompanyAddressBook = new List<Models.DContactAddress>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.DContactAddress(dbParam, ContactId, Delivery, CustomerId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new DContactAddress()
                        {
                            BranchName = (string)dr["BranchName"],
                            CostCenterName = (string)dr["CostCenterName"],
                            ContactName = (string)dr["ContactName"]
                        };
                        CompanyAddressBook.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CompanyAddressBook);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DContactAddress>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(true, RespMessage.ServerError, CompanyAddressBook);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<DContactAddress>>(response, HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CompanyAddressBook);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<DContactAddress>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



        }
        //===========================================CContactAddress===========================================

        [System.Web.Http.Route("api/Customer/GetAllCContactAddress/{dbParam}/{ContactId}/{Collection}/{CustomerId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<CContactAddress>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetAllCContactAddress(string dbParam, int ContactId, int Collection, int CustomerId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<CContactAddress>> response = new ResponseStatus<List<CContactAddress>>();
            List<CContactAddress> CContactAddress = new List<Models.CContactAddress>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCContactAddress(dbParam, ContactId, Collection, CustomerId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new CContactAddress()
                        {
                            BranchName = (string)dr["BranchName"],
                            CostCenterName = (string)dr["CostCenterName"]


                        };
                        CContactAddress.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CContactAddress);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CContactAddress>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, CContactAddress);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CContactAddress>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CContactAddress);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<CContactAddress>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;



        }
        [System.Web.Http.Route("api/Customer/GetCollectionAddress/{dbParam}/{ContactId}/{FAddress}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Contacts>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetCollectionAddress(string dbParam, int ContactId, string FAddress)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Contacts>> response = new ResponseStatus<List<Contacts>>();
            List<Contacts> Contacts = new List<Models.Contacts>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCollectionAddress(dbParam, ContactId, FAddress);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Contacts()
                        {
                            //BranchName = (string)dr["BranchName"],
                            //CostCenterName = (string)dr["CostCenterName"]
                            Count = (int)dr["Count"]


                        };
                        Contacts.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Contacts);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Contacts);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Contacts);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;


        }
        [System.Web.Http.Route("api/Customer/GetCompanyAddressBook/{dbParam}/{ContactId}/{CustomerId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<CompanyAddressBooks>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetCompanyAddressBook(string dbParam, int ContactId, int CustomerId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<CompanyAddressBooks>> response = new ResponseStatus<List<CompanyAddressBooks>>();
            List<CompanyAddressBooks> CompanyAddressBooks = new List<Models.CompanyAddressBooks>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCompanyAddressBook(dbParam, ContactId, CustomerId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new CompanyAddressBooks()
                        {
                            //BranchName = (string)dr["BranchName"],
                            //CostCenterName = (string)dr["CostCenterName"]
                            Count = (int)dr["Count"]


                        };
                        CompanyAddressBooks.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CompanyAddressBooks);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, CompanyAddressBooks);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CompanyAddressBooks);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
        [System.Web.Http.Route("api/Customer/GetContacts/{dbParam}/{ContactId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<Contacts>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetContacts(string dbParam, int ContactId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<Contacts>> response = new ResponseStatus<List<Contacts>>();
            List<Contacts> Contacts = new List<Models.Contacts>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetContacts(dbParam, ContactId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new Contacts()
                        {
                            //FirstName = (string)dr["FirstName"],
                            //MiddleName = (string)dr["MiddleName"],
                            //LastName = (string)dr["LastName"],
                            //Tel = (string)dr["Tel"],
                            //Phone2 = (string)dr["Phone2"],
                            //Extension1 = (string)dr["Extension1"],
                            //Extension2 = (string)dr["Extension2"],
                            //CountryId = (int)dr["CountryId"],
                            //CityId = (int)dr["CityId"],
                            //DistrictId = (int)dr["DistrictId"],
                            //Zoneid = (int)dr["ZoneId"],
                            contactName = (string)dr["contactName"]
                            //Department = (string)dr["Department"],
                            // BranchName = (string)dr["BranchName"]
                            //CostCenterName = (string)dr["CostCenterName"]
                            //Count = (int)dr["Count"]


                        };
                        Contacts.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, Contacts);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, Contacts);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, Contacts);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<Contacts>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;

        }
        [System.Web.Http.Route("api/Customer/GetCompanyAddressBookId/{dbParam}/{ContactId}/{CustomerId}")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseStatus<List<CompanyAddressBooks>>))]
        //public IHttpActionResult GetAllContract(int Companyid, int contactid)
        public IHttpActionResult GetCompanyAddressBookId(string dbParam, int ContactId, int CustomerId)
        {
            DataSet ds = new DataSet();
            ResponseStatus<List<CompanyAddressBooks>> response = new ResponseStatus<List<CompanyAddressBooks>>();
            List<CompanyAddressBooks> CompanyAddressBooks = new List<Models.CompanyAddressBooks>();
            try
            {
                if (dbParam == "SGP")
                {
                    ds = repository.GetCompanyAddressBookId(dbParam, ContactId, CustomerId);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var temp = new CompanyAddressBooks()
                        {
                            //BranchName = (string)dr["BranchName"],
                            //CostCenterName = (string)dr["CostCenterName"]
                            //Count = (int)dr["Count"]
                            Department = (string)dr["Department"]


                        };
                        CompanyAddressBooks.Add(temp);
                    }
                    response = response.Create(true, RespMessage.DataSuccess, CompanyAddressBooks);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.OK);
                }
                else
                {
                    response = response.Create(false, RespMessage.ServerError, CompanyAddressBooks);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.InternalServerError);

                }
            }
            catch (Exception ex)
            {
                response = response.Create(false, RespMessage.ServerError, CompanyAddressBooks);
                responseIHttpActionResult = new Converter().ApiResponseMessage<List<CompanyAddressBooks>>(response, HttpStatusCode.InternalServerError);
            }
            return responseIHttpActionResult;
        }
      

            [System.Web.Http.Route("api/Customer/PostAllCustomer/{dbParam}")]
            [System.Web.Http.HttpGet]
            [ResponseType(typeof(ResponseStatus<List<Customers>>))]
            public IHttpActionResult PostAllCustomer(string dbParam)
            {
                DataSet ds = new DataSet();
                ResponseStatus<List<Customers>> response = new ResponseStatus<List<Customers>>();
                List<Customers> customer = new List<Models.Customers>();
                try
                {
                    if (dbParam == "SGP")
                    {
                        ds = repository.PostCustomer(dbParam);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                        var temp = new Customers()
                        //var insertedCustomer = SaveCustomer(Customers);

                        {
                                CompanyId = (int)dr["CompanyId"],
                                CustomerName = (string)dr["CustomerName"]
                            };
                            customer.Add(temp);
                        }
                        response = response.Create(true, RespMessage.DataSuccess, customer);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.OK);
                    }
                    else
                    {
                        response = response.Create(true, RespMessage.Unsuccessful, customer);
                        responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                    }

                }
                catch (Exception ex)
                {
                    response = response.Create(false, RespMessage.ServerError, customer);
                    responseIHttpActionResult = new Converter().ApiResponseMessage<List<Customers>>(response, HttpStatusCode.InternalServerError);
                }
                return responseIHttpActionResult;

            }


            [Route("api/Customer/UploadFiles")]
            [HttpPost]
            public HttpResponseMessage UploadFiles()
            {
                //Create the Directory.
                
                //string path = HttpContext.Current.Server.MapPath("~/Uploads/");
                string path = "E:/Transnational/Teamkwork-UAT-Till-txt-upload-code/img";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Fetch the File.
                HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

                //Fetch the File Name.
                string fileName =postedFile.FileName;

                //Save the File.
                postedFile.SaveAs(path + fileName);

                //Send OK Response to Client.
                return Request.CreateResponse(HttpStatusCode.OK, fileName);
            }
      
        }
    }

       


                                         
    



    