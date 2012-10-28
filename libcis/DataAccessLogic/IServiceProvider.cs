using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libcis.Models;

namespace libcis.DataAccessLogic
{
    public interface IServiceProvider
    {
        IList<Service> Get(int provider_id);
        void Checkout();
        void Order();
        void Update();
        void Details();
        void Delete();
        void Lock();

        void Cancel();
        void Special();
    }
}
