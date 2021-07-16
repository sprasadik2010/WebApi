using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web_API_Non_MVC.Configuration;
using static Web_API_Non_MVC.Authorization;

namespace Web_API_Non_MVC.Controller
{
    public class HelloController : ApiController
    {
        /// <summary>
        /// Ping service that requires a Token with Read permission
        /// Returns "Success!"
        /// </summary>
        [ApiAuthorize(Permission = ApiPermission.Read)]
        [HttpGet]
        public string Ping()
        {
            return "Success!";
        }


        /// <summary>
        /// Post service that requires a Token with Write permission
        /// Returns "Success Writing!"
        /// </summary>
        [ApiAuthorize(Permission = ApiPermission.Write)]
        [AcceptVerbs("GET", "POST")]
        public string Post()
        {
            return "Success Writing!";
        }
    }
}
