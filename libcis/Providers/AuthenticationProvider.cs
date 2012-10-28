using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.Providers
{
    public class AuthenticationProvider : libcis.DataAccessLogic.IAuthenticationProvider
    {
        public libcis.DataAccessLogic.AuthenticationResult Get(int marker_id)
        {
            var context = new libcis.Models.CISDatabaseEntities();
            var result = from provider_hotspots in context.ProviderHotspots
                         where provider_hotspots.MarkerId == marker_id
                         select provider_hotspots;
            var provider_hotspot = result.ToList();
            var return_message = new libcis.DataAccessLogic.AuthenticationResult();
            if(provider_hotspot.Count == 0)
            {
                return_message.Success = false;
                //TODO: do not keep static strings here
                return_message.ErrorMessage = string.Format("Invalid marker id: {0}", marker_id);
            }
            else
            {
                var hotspot = provider_hotspot.First();
                libcis.Models.Order customer_order = new libcis.Models.Order();
                customer_order.ProviderHotspotId = hotspot.Id;
                context.Orders.Add(customer_order);
                context.SaveChanges();
                return_message.OrderId = customer_order.Id;                
                return_message.Success = true;
                return_message.ProviderId = hotspot.ProviderId;
                return_message.HotspotId = hotspot.Id;
            }
            context.Dispose();
            return return_message;
        }
    }
}
