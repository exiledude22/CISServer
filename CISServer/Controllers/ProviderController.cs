using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CISServer.Controllers
{
    public class ProviderController : ApiController, libcis.DataAccessLogic.IProviderHost<libcis.DataAccessLogic.IProviderService>
    {
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.ProviderService();
            base.Initialize(controllerContext);
        }

        private libcis.DataAccessLogic.IProviderService providerInstance;
        public libcis.DataAccessLogic.IProviderService Provider
        {
            get
            { 
                return providerInstance;
            }
        }

        [HttpGet]
        [ActionName("active_hotspots")]
        public libcis.DataAccessLogic.ActiveProviderHotspotsResult GetActiveProvierHotspots(int provider_id)
        {
            return Provider.GetActiveProviderHotspots(provider_id);
        }

        [HttpGet]
        [ActionName("pending_hotspots")]
        public IList<int> GetPendingProviderHotspots(int provider_id)
        {
            return Provider.GetPendingProviderHotspots(provider_id);
        }

        // GET api/provider/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/provider
        public void Post([FromBody]string value)
        {
        }

        // PUT api/provider/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/provider/5
        public void Delete(int id)
        {
        }

    }
}
