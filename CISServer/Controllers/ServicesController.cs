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

        [HttpPost]
        [ActionName("mark_as_viewed")]
        public libcis.DataAccessLogic.MarkAsViewedResult MarkAsViewed(IList<int> order_content_ids)
        {
            return Provider.MarkAsViewed(order_content_ids);
        }

        [HttpPost]
        [ActionName("order")]
        public void Order([FromBody]libcis.DataAccessLogic.OrderObject orders)
        {
            Provider.Order(orders);
        }
                
        [HttpPost]
        [ActionName("checkout")]
        public libcis.DataAccessLogic.CheckoutResult Checkout([FromBody]int order_id)
        {
            return Provider.Checkout(order_id);
        } 

        [HttpPost]
        [ActionName("checkout")]
       
        public void Put(int id, [FromBody]string value)
        {            
        }

        public void Delete(int id)
        {
        }
    }
}
