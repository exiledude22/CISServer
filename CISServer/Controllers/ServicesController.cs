using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using libcis.DataAccessLogic;


namespace CISServer.Controllers
{
    public class ServicesController : ApiController, IProviderHost<libcis.DataAccessLogic.IServiceProvider>
    {
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.ServiceProvider();
            base.Initialize(controllerContext);
        }

        private libcis.DataAccessLogic.IServiceProvider providerInstance;
        public libcis.DataAccessLogic.IServiceProvider Provider
        {
            get
            {
                return providerInstance;
            }
        }

        [HttpGet]
        [ActionName("list")]
        public IEnumerable<libcis.Models.Service> Get(int provider_id)
        {
            return Provider.Get(provider_id);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
