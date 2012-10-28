using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{    
    /// <summary>
    /// Represents an API response object to a api/[something] call.
    /// </summary>
    public class MarkAsViewedResult
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
    }
}
