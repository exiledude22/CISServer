using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CISServer;
using System.Data.Entity;
using System.Data;

namespace ServiceProviderTest.Tests
{    
    [TestClass]
    public class ServiceProviderTest
    {
        [TestMethod]
        public void Get()
        {
            libcis.Providers.ServiceProvider service_provider_test = new libcis.Providers.ServiceProvider();

            IList<libcis.Models.Service> result = service_provider_test.Get(3);

            Assert.IsNotNull(result);
        }       

        [TestMethod]
        public void Checkout()
        {
            libcis.Providers.ServiceProvider service_provider_test = new libcis.Providers.ServiceProvider();
            libcis.DataAccessLogic.CheckoutResult checkout_test_result = new libcis.DataAccessLogic.CheckoutResult();
        }
    }
}