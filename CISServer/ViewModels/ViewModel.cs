using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CISServer.ViewModel
{
    /// <summary>
    /// A basic view model aggregator class used in displaying data for the ManagementPanel view.
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Gets or sets the list of active hotspots that are used to render the initial state of the view.
        /// </summary>
        public libcis.DataAccessLogic.ActiveProviderHotspotsResult ActiveHotspots
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of pending services that are used to render the initial state of the view.
        /// </summary>
        public IList<libcis.DataAccessLogic.ServiceObject> PendingServices
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total list of pending services.
        /// </summary>
        public int PendingServicesCount
        {
            get
            {
                return PendingServices.Count;
            }
        }
    }
}