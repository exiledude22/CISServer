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
using System.Web;
using System.Web.Mvc;
using libcis.Providers;

namespace CISServer.Controllers
{
    /// <summary>
    /// Service center (main management page) controller.
    /// </summary>
    public class ServiceCenterController : Controller
    {
        libcis.DataAccessLogic.IProviderService providerServiceInstance;
        libcis.DataAccessLogic.IServiceProvider serviceProviderInstance;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            providerServiceInstance = new ProviderService();
            serviceProviderInstance = new ServiceProvider();

            base.Initialize(requestContext);
        }

        /// <summary>
        /// Displays the ManagementPanel view.
        /// </summary>
        /// <param name="id">A providerId used to filter the displayed data.</param>
        /// <returns></returns>
        public ActionResult ManagementPanel(int id)
        {
            var active_provider_hotspots = providerServiceInstance.GetActiveProviderHotspots(id);
            var pending_provider_hotspots = providerServiceInstance.GetPendingProviderHotspots(id);
            var pending_services = providerServiceInstance.GetPendingServices(id);
            //TODO: add support for un-assigned orders
            return View(new CISServer.ViewModel.ViewModel()
            {
                ActiveHotspots = active_provider_hotspots,
                PendingServices = pending_services
            });
        }
    }
}
