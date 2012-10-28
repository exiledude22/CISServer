using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libcis.Providers;

namespace CISServer.Controllers
{
    public class ViewModel
    {
        public libcis.DataAccessLogic.ActiveProviderHotspotsResult ActiveHotspots
        {
            get;
            set;
        }
    }

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

        public ActionResult ManagementPanel(int id)
        {
            var active_provider_hotspots = providerServiceInstance.GetActiveProviderHotspots(id);
            var pending_provider_hotspots = providerServiceInstance.GetPendingProviderHotspots(id);
            //TODO: add support for un-assigned orders
            return View(new ViewModel()
            {
                ActiveHotspots = active_provider_hotspots
            });
        }
    }
}
