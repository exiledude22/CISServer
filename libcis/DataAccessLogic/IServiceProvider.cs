using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libcis.Models;

namespace libcis.DataAccessLogic
{    
    /// <summary>
    /// Describes the way to interact with services.
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// Returns a list of services available for the specified provider. 
        /// </summary>
        /// <param name="provider_id">The providerId to query.</param>
        /// <returns>A list of <see cref="Service"/> objects.</returns>
        IList<Service> Get(int provider_id);

        /// <summary>
        /// Marks an service order as completed, freeing the hotspot in the process.
        /// </summary>
        /// <param name="order_id">The id of the order to checkout.</param>
        /// <returns>
        /// A <see cref="CheckoutResult"/> object indicating wether the operation succeded.
        /// </returns>
        CheckoutResult Checkout(int order_id);

        /// <summary>
        /// Requires an array of services form a provider.
        /// </summary>
        /// <param name="orders">A <see cref="OrderObject"/> object containing an orderId, hotspotId and
        /// order contents</param>
        void Order(OrderObject orders);

        /// <summary>
        /// Marks the specified order for checkout.
        /// </summary>
        /// <param name="order_id">The order id checkout.</param>
        /// <returns></returns>
        MarkForCheckoutResult MarkForCheckout(int order_id);

        /// <summary>
        /// Marks an list of service requests as viewed.
        /// </summary>
        /// <param name="order_content_ids">A list of serviceIds to mark.</param>
        /// <returns>A <see cref="MarkAsViewResult"/> object indicating wether the operation succeded.</returns>
        MarkAsViewedResult MarkAsViewed(IList<int> order_content_ids);

        /// <summary>
        /// Placeholders
        /// </summary>
        void Cancel();
        void Special();
        void Update();
        void Details();
        void Delete();
        void Lock();
    }
}
