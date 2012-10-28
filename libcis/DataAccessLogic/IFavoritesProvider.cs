using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcis.DataAccessLogic
{
    /// <summary>
    /// Describes a way to interact with favorites providers.
    /// </summary>
    public interface IFavoritesProvider
    {
        /// <summary>
        /// All these methods are placeholder drafts, there are no favorites 
        /// providers implemented.
        /// </summary>
        void Get();
        void Create();
        void Update();
        void Delete();
    }
}
