using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Represents an API base provider host object (IE. a ApiController).
    /// </summary>
    /// <typeparam name="T">A Provider interface</typeparam>
    /// <example>
    /// public class AuthenticationProviderHost : IProviderHost<IAuthenticationProvider>
    /// </example>
    /// <remarks>
    /// The main reason for this interface is to separate the API code from the actual
    /// controllers.
    /// </remarks>
    public interface IProviderHost<T>
    {
        /// <summary>
        /// Represents a provider for a specific service.
        /// </summary>
        T Provider
        {
            get;
        }
    }
}
