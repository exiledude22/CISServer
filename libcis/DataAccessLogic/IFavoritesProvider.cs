using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    public interface IFavoritesProvider
    {
        void Get();
        void Create();
        void Update();
        void Delete();
    }
}
