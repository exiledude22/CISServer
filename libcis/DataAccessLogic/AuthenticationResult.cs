using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public class AuthenticationResult
    {
        public bool Success
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public int ProviderId
        {
            get;
            set;
        }

        public int HotspotId
        {
            get;
            set;
        }
    }
}
