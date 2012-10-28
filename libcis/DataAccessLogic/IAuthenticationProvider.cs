using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Describes the way to interact with authentication providers.
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Check to see if the marker id is a valid hotspot in the CIS network.
        /// </summary>
        /// <param name="marker_id">A marker id</param>
        /// <returns>An <see cref="AuthenticationResult"/> object indicating wether the operation
        /// succeeded.</returns>
        AuthenticationResult Get(int marker_id);
    }
}
