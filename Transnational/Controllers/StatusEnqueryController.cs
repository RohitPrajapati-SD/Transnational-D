using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuthenticationInWebAPI;
using Transnational.VM;
using System.Web.Http.Cors;

namespace Transnational.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatusEnqueryController : ApiController

    {
        Entities db = new Entities();
        public IHttpActionResult GetAllCustomer()
        {
            
            IList<Company> compobj = db.tblCompanies.Include("tblcompany").Select(x => new Company()
            {
                CompanyId = x.CompanyId,
                CustomerName = x.CustomerName
            }).ToList<Company>();
            return Ok(compobj);
        }
        
    }
}
