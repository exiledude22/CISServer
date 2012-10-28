using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    //TODO: does not comply with naming scheme/rename
    public interface IProviderService
    {
        ActiveProviderHotspotsResult GetActiveProviderHotspots(int provider_id);
        IList<int> GetPendingProviderHotspots(int provider_id);
    }
}
