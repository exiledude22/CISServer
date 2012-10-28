using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// A service object aggregate from the service/hotspot/order models.
    /// </summary>
    public class ServiceObject
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
        /// The name of the service.
        /// </summary>
        public string ServiceName
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

        /// <summary>
        /// The hotspot associtated with the service.
        /// </summary>
        public int HotSpotId
        {
            get;
            set;
        }

        /// <summary>
        /// The cost of the service.
        /// </summary>
        public float Price
        {
            get;
            set;
        }

    }
}
