using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public class OrderItem
    {
        public int ServiceId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public float Price
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }

    public class ActiveProviderHotspotOrderItemsPair
    {
        public ActiveProviderHotspotOrderItemsPair()
        {
            OrderItems = new List<OrderItem>();
        }

        public int ProviderHotspotId
        {
            get;
            set;
        }

        public IList<OrderItem> OrderItems
        {
            get;
            set;
        }
    }
    public class ActiveProviderHotspotsResult
    {
        public ActiveProviderHotspotsResult()
        {
            ActiveProviderHotspotsAndOrderItems = new List<ActiveProviderHotspotOrderItemsPair>();
        }

        public IList<ActiveProviderHotspotOrderItemsPair> ActiveProviderHotspotsAndOrderItems
        {
            get;
            set;
        }
    }
}
