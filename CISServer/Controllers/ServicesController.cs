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
using libcis.DataAccessLogic;


namespace CISServer.Controllers
{
    /// <summary>
    /// Providers a basic API for non-provider consumer applications.
    /// </summary>
    public class ServicesController : ApiController, IProviderHost<libcis.DataAccessLogic.IServiceProvider>
    {
        private libcis.DataAccessLogic.IServiceProvider providerInstance;

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.ServiceProvider();
            base.Initialize(controllerContext);
        }

        public libcis.DataAccessLogic.IServiceProvider Provider
        {
            get
            {
                return providerInstance;
            }
        }

        /// <summary>
        /// Returns a list of services available for the specified provider. 
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of <see cref="Service"/> objects.</returns>
        /// <example>
        /// HTTP GET api/services/list/3
        /// </example>
        [HttpGet]
        [ActionName("list")]
        public IEnumerable<libcis.Models.Service> Get(int provider_id)
        {
            return Provider.Get(provider_id);
        }

        /// <summary>
        /// Marks an list of service requests as viewed.
        /// </summary>
        /// <param name="order_content_ids">A list of serviceIds to mark.</param>
        /// <returns>A <see cref="MarkAsViewResult"/> object indicating wether the operation succeded.</returns>
        /// <example>
        /// HTTP POST api/services/mark_as_viewed
        /// </example>
        /// <remarks>
        /// This is a provider API function mostly and is not intended for non-providers.
        /// 
        /// A viewed state for a service request means that a provider took notices of those requests
        /// and will attempt to provide them.
        /// </remarks>
        [HttpPost]
        [ActionName("mark_as_viewed")]
        public libcis.DataAccessLogic.MarkAsViewedResult MarkAsViewed(IList<int> order_content_ids)
        {
            return Provider.MarkAsViewed(order_content_ids);
        }

        /// <summary>
        /// Requires an array of services form a provider.
        /// </summary>
        /// <param name="orders">A <see cref="OrderObject"/> object containing an orderId, hotspotId and
        /// order contents</param>
        /// <example>
        /// HTTP POST api/services/order
        /// </example>
        [HttpPost]
        [ActionName("order")]
        public void Order([FromBody]libcis.DataAccessLogic.OrderObject orders)
        {
            Provider.Order(orders);
        }

        /// <summary>
        /// Marks an service order as completed, freeing the hotspot in the process.
        /// </summary>
        /// <param name="order_id">The id of the order to checkout.</param>
        /// <returns>
        /// A <see cref="CheckoutResult"/> object indicating wether the operation succeded.
        /// </returns>
        /// <example>
        /// HTTP POST api/services/checkout
        /// </example>
        /// <remarks>
        /// This is a provider API function mostly and is not intended for non-providers.
        /// 
        /// Checking out a order will also remove it from the active orders table.
        /// 
        /// The data is migrated into the statistics database.
        /// </remarks>
        [HttpPost]
        [ActionName("checkout")]
        public libcis.DataAccessLogic.CheckoutResult Checkout([FromBody]int order_id)
        {
            return Provider.Checkout(order_id);
        }
    }
}
