using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.Providers
{
    public class ServiceProvider : libcis.DataAccessLogic.IServiceProvider
    {
        public IList<Models.Service> Get(int provider_id)
        {
            var context = new libcis.Models.CISDatabaseEntities();
            var result = from services in context.Services
                         where services.ProviderId == provider_id
                         select services;
            var all_services = result.ToList();
            context.Dispose();
            return all_services;
        }

        public libcis.DataAccessLogic.MarkAsViewedResult MarkAsViewed(IList<int> order_content_ids)
        {
            libcis.DataAccessLogic.MarkAsViewedResult viewed_result = new DataAccessLogic.MarkAsViewedResult();
            var context = new libcis.Models.CISDatabaseEntities();
            foreach(var order_content_id in order_content_ids)
            {
                var result = from contents in context.OrderContents
                             where contents.Id == order_content_id
                             select contents;
                var current_order_content = result.First();
                current_order_content.Viewed = 1;
            }
            context.SaveChanges();
            viewed_result.Success = true;
            return viewed_result;
        }

        public libcis.DataAccessLogic.MarkForCheckoutResult MarkForCheckout(int order_id)
        {
            libcis.DataAccessLogic.MarkForCheckoutResult checkout_result = new DataAccessLogic.MarkForCheckoutResult();
            var context = new libcis.Models.CISDatabaseEntities();
            var order_result = from orders in context.Orders
                               where orders.Id == order_id
                               select orders;
            var current_order = order_result.First();
            current_order.MarkedForChekout = 1;
            checkout_result.Success = true;
            context.SaveChanges();
            context.Dispose();
            return checkout_result;
        }

        public libcis.DataAccessLogic.CheckoutResult Checkout(int order_id)
        {
            libcis.DataAccessLogic.CheckoutResult checkout_result = new DataAccessLogic.CheckoutResult();
            
            var context = new libcis.Models.CISDatabaseEntities();

            //Get ProviderHotspotId
            var hotspot_result = from hotspots in context.Orders
                                 where hotspots.Id == order_id
                                 select hotspots.ProviderHotspotId;
            var hotspot_id = hotspot_result.First();

            //Get ProviderId
            var provider_result = from data in context.ProviderHotspots
                                  where data.Id == hotspot_id
                                  select data.ProviderId;
            var provider_id = provider_result.First();


            //Get all orders with recieved order_id
            var result = from orders in context.OrderContents
                         where orders.OrderId == order_id
                         select orders;
            var checkout_orders = result;

            foreach (var current_order in checkout_orders)
            {
                //Gets current service name
                var service_name_result = from services in context.Services
                                          where services.Id == current_order.ServiceId
                                          select services.Name;
                string service_name = service_name_result.First();

                //Creates lew log and fills it
                var new_log = new libcis.Models.Log();
                new_log.ServiceId = current_order.ServiceId;
                new_log.ProviderHotspotId = hotspot_id;
                new_log.ProviderId = provider_id;
                new_log.Quantity = current_order.Quantity;
                new_log.OrderId = order_id;
                if (current_order.Time.HasValue)
                    new_log.Time = current_order.Time.Value;
                else
                    new_log.Time = DateTime.Now;
                context.Logs.Add(new_log);

                //Removes order_content from Database
                context.OrderContents.Remove(current_order);
            }
            //Removes Order
            var order_result = from orders in context.Orders
                               where orders.Id == order_id
                               select orders;
            context.Orders.Remove(order_result.First());           
            context.SaveChanges();
            context.Dispose();

            checkout_result.Success = true;
            return checkout_result;
        }

        public void Order(libcis.DataAccessLogic.OrderObject orders)
        {
            libcis.Models.CISDatabaseEntities context = new Models.CISDatabaseEntities();
            foreach (var item in orders.OrderContents)
            {
                libcis.Models.OrderContent new_order_content = new Models.OrderContent();                
                new_order_content.Quantity = item.Quantity;
                new_order_content.ServiceId = item.ServiceId;
                new_order_content.OrderId = orders.OrderId;
                new_order_content.Time = DateTime.Now;
                context.OrderContents.Add(new_order_content);
            }
            context.SaveChanges();
            context.Dispose();
        }

        public void Update()
        {
        }

        public void Details()
        {
        }

        public void Delete()
        {
        }

        public void Lock()
        {
        }

        public void Cancel()
        {
        }

        public void Special()
        {
        }
    }
}
