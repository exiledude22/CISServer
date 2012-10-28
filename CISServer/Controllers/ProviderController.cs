/*
Copyright 2012 CIS(Chiciu Bogdan, Cojocaru Aurelian)
https://github.com/exiledude22/CISServer/blob/master/README.md

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CISServer.Controllers
{
    /// <summary>
    /// Provides access to the provider-specific API.
    /// </summary>
    /// <remarks>
    /// This controller/API is aimed at provider-owned consumer applications. 
    /// </remarks>
    public class ProviderController : ApiController, libcis.DataAccessLogic.IProviderHost<libcis.DataAccessLogic.IProviderService>
    {
        private libcis.DataAccessLogic.IProviderService providerInstance;

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.ProviderService();
            base.Initialize(controllerContext);
        }

        public libcis.DataAccessLogic.IProviderService Provider
        {
            get
            { 
                return providerInstance;
            }
        }

        /// <summary>
        /// Returns the active hotspots for the specified provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A <see cref="ActiveProviderHotspotResult"/> object containing a list of active hotspots and
        /// the services associated with those hotspots.
        /// </returns>
        /// <remarks>
        /// Accessible through HTTP GET only
        /// </remarks>
        /// <example>
        /// HTTP GET api/provider/active_hotspots/3
        /// </example>
        [HttpGet]
        [ActionName("active_hotspots")]
        public libcis.DataAccessLogic.ActiveProviderHotspotsResult GetActiveProvierHotspots(int provider_id)
        {
            return Provider.GetActiveProviderHotspots(provider_id);
        }

        /// <summary>
        /// Returns a list of pending hotspots ids for the specified provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of pending hotspotIds.</returns>
        /// <example>
        /// HTTP GET api/provider/pending_hotspots/3
        /// </example>
        [HttpGet]
        [ActionName("pending_hotspots")]
        public IList<int> GetPendingProviderHotspots(int provider_id)
        {
            return Provider.GetPendingProviderHotspots(provider_id);
        }

        /// <summary>
        /// Returns the pending services for the current provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of <see cref="ServiceObject"/> objects containing pending service data.</returns>
        /// <example>
        /// HTTP GET api/provider/pending_services/3
        /// </example>
        [HttpGet]
        [ActionName("pending_services")]
        public IList<libcis.DataAccessLogic.ServiceObject> GetPendingServices(int provider_id)
        {
            return Provider.GetPendingServices(provider_id);
        }
    }
}
