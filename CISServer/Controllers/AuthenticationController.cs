using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using libcis.DataAccessLogic;

namespace CISServer.Controllers
{
    public class AuthenticationController : ApiController, libcis.DataAccessLogic.IProviderHost<IAuthenticationProvider>
    {
        private IAuthenticationProvider providerInstance;
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.AuthenticationProvider();
            base.Initialize(controllerContext);
        }
        public IAuthenticationProvider Provider
        {
            get
            {
                return providerInstance;
            }
        }

        [HttpGet]
        public libcis.DataAccessLogic.AuthenticationResult Get(int marker_id)
        {
            return providerInstance.Get(marker_id);
        }

        // POST api/authentication
        public void Post([FromBody]string value)
        {
        }

        // PUT api/authentication/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/authentication/5
        public void Delete(int id)
        {
        }

    }
}
