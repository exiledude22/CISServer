using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Represents an API response object to a api/provider/active_hotspots call.
    /// </summary>
    public class ActiveProviderHotspotsResult
    {
        public ActiveProviderHotspotsResult()
        {
            ActiveProviderHotspotsAndOrderItems = new List<ActiveProviderHotspotOrderItemsPair>();
        }

        /// <summary>
        /// Gets or sets a list of <see cref="ActiveProviderHotspotOrderItemsPair"/> objects.
        /// </summary>
        public IList<ActiveProviderHotspotOrderItemsPair> ActiveProviderHotspotsAndOrderItems
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a partial aggregated model entity of a Service and Order.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Gets or sets the service id for this order.
        /// </summary>
        public int ServiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the service for this order.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the price of the services associtated with this order.
        /// </summary>
        public float Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the amount of services associtated with this order.
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents an aggregation of <see cref="OrderItem"/> objects that belong to a provider hotspot.
    /// </summary>
    public class ActiveProviderHotspotOrderItemsPair
    {
        public ActiveProviderHotspotOrderItemsPair()
        {
            OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Gets or sets the total cost of the services associtated with this hotspot.
        /// </summary>
        public float TotalCost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the provideder hotspot id for this aggregation.
        /// </summary>
        public int ProviderHotspotId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a list of <see cref="OrderItem"/> objects that are associated with the
        /// provider hotspot.
        /// </summary>
        public IList<OrderItem> OrderItems
        {
            get;
            set;
        }
    }
}
