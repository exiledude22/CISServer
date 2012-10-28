using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public struct ServiceIdQuantityPair 
    {
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderObject
    {
        public int OrderId { get; set; }
        public int ProviderHotspotId { get; set; }
        public IList<ServiceIdQuantityPair> OrderContents { get; set; }
    }
}
