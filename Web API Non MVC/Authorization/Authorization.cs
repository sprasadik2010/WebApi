using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API_Non_MVC
{
    public class Authorization
    {
        public class ApiAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
        {
            public ApiPermission Permission { get; set; }

            public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                switch (Permission)
                {
                    case ApiPermission.None:
                        return;

                    case ApiPermission.Write:

                        string querywrite = actionContext.Request.RequestUri.Query;
                        var nvcwrite = System.Web.HttpUtility.ParseQueryString(querywrite);
                        string tokenwrite = nvcwrite["token"];

                        if (tokenwrite.ToLower().Contains("gayu")) return;
                        HandleUnauthorizedRequest(actionContext);
                        return;
                    case ApiPermission.Read:

                        string queryread = actionContext.Request.RequestUri.Query;
                        var nvcread = System.Web.HttpUtility.ParseQueryString(queryread);
                        string tokenread = nvcread["token"];

                        // (my code to map the token to an Authorization for the request)               
                        //ApiAuthorization auth = ApiToken.GetAuthorization(token);
                        string authread = tokenread;
                        //if (auth != null && auth.HasPermission(Permission))
                        if (authread != null && authread.ToLower().Contains("siva"))
                            return;

                        HandleUnauthorizedRequest(actionContext);
                        return;

                    default:
                        throw new ArgumentException("Unexpected Permission");
                }
            }
        }

        public enum ApiPermission {None=0, Read = 1, Write = 2}
    }
}