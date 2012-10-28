using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public class CheckoutResult
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
    }
}
