using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public interface IStatisticsProvider
    {
        void GetStatisticsForProvider();
        void GetStatisticsForService();
    }
}
