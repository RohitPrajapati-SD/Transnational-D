using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Net;


namespace Transnational.MessageHandler
{
    public class ApiKeytMessageHandler : DelegatingHandler
    {

        private const string APIKeyToCheck = "5567GGH67225HYVGG";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage HttpRequestMessage, CancellationToken CancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = HttpRequestMessage.Headers.TryGetValues("ApiKey", out requestHeaders);
            if (checkApiKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKeyToCheck))
                {
                    validKey = true;

                }


                if (!validKey)
                {
                    return HttpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "sorry! Invalid Key");
                }
            }

            else
            {
                return HttpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Sorry! please Enter your APIkey");
            }


            var response = await base.SendAsync(HttpRequestMessage, CancellationToken);
            return response;
        }
    }
}



