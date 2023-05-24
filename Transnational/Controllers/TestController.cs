using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Transnational.Models;
using System.Web.Http.Cors;

namespace Transnational.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/test/method1")]
        public HttpResponseMessage Post(MyClass myclass)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);

            myclass.Role = roles.ToString();
            myclass.Name = identity.Name;

            return Request.CreateResponse(HttpStatusCode.Created, myclass);
        }
    }
}