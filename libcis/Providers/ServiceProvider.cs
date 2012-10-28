using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.Providers
{
    public class ServiceProvider : libcis.DataAccessLogic.IServiceProvider
    {
        public IList<Models.Service> Get(int provider_id)
        {
            var context = new libcis.Models.CISDatabaseEntities();
            var result = from services in context.Services
                         where services.ProviderId == provider_id
                         select services;
            var all_services = result.ToList();
            context.Dispose();
            return all_services;
        }

        public void Checkout()
        {
        }

        public void Order()
        {
        }

        public void Update()
        {
        }

        public void Details()
        {
        }

        public void Delete()
        {
        }

        public void Lock()
        {
        }

        public void Cancel()
        {
        }

        public void Special()
        {
        }
    }
}
