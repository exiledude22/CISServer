using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Represents a pair of service ids and quantity.
    /// </summary>
    public struct ServiceIdQuantityPair 
    {
        /// <summary>
        /// The id of the service.
        /// </summary>
        public int ServiceId 
        { 
            get;
            set;
        }

        /// <summary>
        /// The quantity of the service.
        /// </summary>
        public int Quantity 
        { 
            get;
            set; 
        }
    }

    /// <summary>
    /// Represents an order object aggregate.
    /// </summary>
    public class OrderObject
    {
        /// <summary>
        /// The id of the order.
        /// </summary>
        public int OrderId
        { 
            get;
            set;
        }

        /// <summary>
        /// The hotspot.
        /// </summary>
        public int ProviderHotspotId 
        { 
            get;
            set;
        }

        /// <summary>
        /// A list of Service/Quanitiy pair objects associated with the order/hotspot.
        /// </summary>
        public IList<ServiceIdQuantityPair> OrderContents 
        { 
            get;
            set;
        }
    }
}
