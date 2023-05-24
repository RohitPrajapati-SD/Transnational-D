using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using TokenAuthenticationInWebAPI;
using Transnational.Models;

namespace Transnational.Service
{
    public class Converter : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of class</typeparam>
        /// <param name="dataObject">Data that will be receive from repository.</param>
        /// <param name="statusCode">status code of Api.</param>
        /// <returns></returns>
        public IHttpActionResult ApiResponseMessage<T>(ResponseStatus<T> dataObject, HttpStatusCode statusCode) where T : class
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            IHttpActionResult responseIHttpActionResult;
            httpResponseMessage.Content = new ObjectContent<ResponseStatus<T>>(dataObject, new JsonMediaTypeFormatter());

            httpResponseMessage.StatusCode = statusCode;
            responseIHttpActionResult = ResponseMessage(httpResponseMessage);
            return responseIHttpActionResult;
        }

        internal IHttpActionResult ApiResponseMessage<T1>(ResponseStatus<List<tblCompanyBranch>> response, HttpStatusCode httpStatusCode)
        {
            throw new NotImplementedException();
        }
    }
}