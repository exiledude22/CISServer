using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.Providers
{
    public class ProviderService : libcis.DataAccessLogic.IProviderService
    {
        public DataAccessLogic.ActiveProviderHotspotsResult GetActiveProviderHotspots(int provider_id)
        {
            DataAccessLogic.ActiveProviderHotspotsResult result = new DataAccessLogic.ActiveProviderHotspotsResult();
            var context = new libcis.Models.CISDatabaseEntities();
            var active_hotspots_result = from hotspots in context.ProviderHotspots
                                         where hotspots.ProviderId == provider_id
                                         select hotspots;
            var active_hotspots = active_hotspots_result.ToList();
            foreach (var hotspot in active_hotspots)
            {
                var order_pair = new DataAccessLogic.ActiveProviderHotspotOrderItemsPair();
                order_pair.ProviderHotspotId = hotspot.Id;
                
                var active_orders_for_hotspot_result = from orders in context.Orders
                                                       where orders.ProviderHotspotId == hotspot.Id
                                                       select orders;
                var active_orders_for_hotspot = active_orders_for_hotspot_result.ToList();
                foreach (var order in active_orders_for_hotspot)
                {
                    var order_contents_result = from order_contents in context.OrderContents
                                                where order_contents.OrderId == order.Id
                                                join service in context.Services on order_contents.ServiceId equals service.Id
                                                select new
                                                {
                                                    service_id = service.Id,
                                                    serivce_name = service.Name,
                                                    service_price = service.Price,
                                                    quantity = order_contents.Quantity
                                                };
                    var order_items = order_contents_result.ToList();
                    foreach (var order_item in order_items)
                    {
                        var order_item_object = new DataAccessLogic.OrderItem();
                        order_item_object.ServiceId = order_item.service_id;
                        order_item_object.Name = order_item.serivce_name;
                        order_item_object.Price = order_item.service_price;
                        order_item_object.Quantity = order_item.quantity;
                        order_pair.OrderItems.Add(order_item_object);
                    }
                }

                result.ActiveProviderHotspotsAndOrderItems.Add(order_pair);

            }
            context.Dispose();
            return result;
        }

        public IList<int> GetPendingProviderHotspots(int provider_id)
        {
            var context = new libcis.Models.CISDatabaseEntities();
            var pending_hotspots_result = (from hotspots in context.ProviderHotspots
                                          where hotspots.ProviderId == provider_id
                                          join order in context.Orders on hotspots.Id equals order.ProviderHotspotId
                                          where order.MarkedForChekout == 1
                                          select new
                                          {
                                              hotspot_id = hotspots.Id
                                          });

            var pending_hotspots = pending_hotspots_result.Select(selector => selector.hotspot_id).ToList();
            return pending_hotspots;
        }
    }
}
