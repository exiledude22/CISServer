using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    //TODO: does not comply with naming scheme/rename
    /// <summary>
    /// Describes the way to interact with service providers.
    /// </summary>
    public interface IProviderService
    {
        /// <summary>
        /// Returns the active hotspots for the specified provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A <see cref="ActiveProviderHotspotResult"/> object containing a list of active hotspots and
        /// the services associated with those hotspots.
        /// </returns>
        ActiveProviderHotspotsResult GetActiveProviderHotspots(int provider_id);

        /// <summary>
        /// Returns a list of pending hotspots ids for the specified provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of pending hotspotIds.</returns>
        IList<int> GetPendingProviderHotspots(int provider_id);

        /// <summary>
        /// Returns the pending services for the current provider.
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of <see cref="ServiceObject"/> objects containing pending service data.</returns>
        IList<ServiceObject> GetPendingServices(int provider_id);
    }
}
