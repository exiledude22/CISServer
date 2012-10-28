using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public class ServiceObject
    {
        public int ServiceId
        {
            get;
            set;
        }
        public string ServiceName
        {
            get;
            set;
        }
        
        public int Quantity
        {
            get;
            set;
        }

        public int HotSpotId
        {
            get;
            set;
        }

        public float Price
        {
            get;
            set;
        }

    }
}
