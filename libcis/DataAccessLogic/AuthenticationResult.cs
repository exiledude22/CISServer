using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Represents an API response object to a api/authentication call.
    /// </summary>
    public class AuthenticationResult
    {
        /// <summary>
        /// A value indicating wether the operation succeded.
        /// </summary>
        public bool Success
        {
            get;
            set;
        }

        /// <summary>
        /// If the <see cref="AuthenticationResult.Success"/> property is false this
        /// should provide basic information about why the call failed.
        /// </summary>
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// The provider id returned by the authentication procedure.
        /// </summary>
        public int ProviderId
        {
            get;
            set;
        }

        /// <summary>
        /// The hotspot id associated with the marked that was used to perform the authentication.
        /// </summary>
        public int HotspotId
        {
            get;
            set;
        }

        /// <summary>
        /// The order id created by the authentication process.
        /// </summary>
        public int OrderId
        {
            get;
            set;
        }
    }
}
