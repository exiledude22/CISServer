using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CISServer;

namespace ProviderServiceTest.Tests
{
    [TestClass]
    public class ProviderServiceTest
    {
        [TestMethod]
        public void GetActiveProviderHotspots()
        {
            libcis.Providers.ProviderService provider_test = new libcis.Providers.ProviderService();
            var result = provider_test.GetActiveProviderHotspots(3);
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void GetPendingProviderHotspots()
        {
            libcis.Providers.ProviderService provider_test = new libcis.Providers.ProviderService();
            var result = provider_test.GetPendingProviderHotspots(3);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<int>));
        }

        [TestMethod]
        public void GetPendingServices()
        {
            libcis.Providers.ProviderService provider_test = new libcis.Providers.ProviderService();
            var result = provider_test.GetPendingServices(3);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IList<libcis.DataAccessLogic.ServiceObject>));
        }

    }
}
