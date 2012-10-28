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
        CheckoutResult Checkout(int order_id);
        void Order(OrderObject orders);
        void Update();
        void Details();
        void Delete();
        void Lock();
        MarkForCheckoutResult MarkForCheckout(int order_id);

        void Cancel();
        void Special();
    }
}
