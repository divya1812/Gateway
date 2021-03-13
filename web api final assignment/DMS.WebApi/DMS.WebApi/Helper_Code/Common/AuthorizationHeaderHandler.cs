using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DMS.WebApi.Resources.Constants;

namespace DMS.WebApi.Helper_Code.Common
{
    public class AuthorizationHeaderHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Initialize Values

            IEnumerable<string> apiKeyHeaderValues = null;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            string userName = null;
            string password = null;

            //verify header
            if (request.Headers.TryGetValues(ApiInfo.API_KEY_HEADER, out apiKeyHeaderValues) && !string.IsNullOrEmpty(authorization.Parameter))
            {

                //get encrypted string and decrypt
                var apiKeyHeaderValue = apiKeyHeaderValues.First();
                string authToken = authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

                //check authorization token
                if (apiKeyHeaderValue.Equals(ApiInfo.API_KEY_VALUE) && userName.Equals(ApiInfo.USERNAME_VALUE) && password.Equals(ApiInfo.PASSWORD_VALUE))
                {

                    var identity = new GenericIdentity(userName);
                    SetPrincipal(new GenericPrincipal(identity, null));


                }

            }

            return base.SendAsync(request, cancellationToken);


        }

        private static void SetPrincipal(IPrincipal principal)
        {
            // set Principal   
            Thread.CurrentPrincipal = principal;
            
            // Verify.   
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }


    }

}