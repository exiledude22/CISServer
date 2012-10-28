using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CISServer;

namespace AuthentificationProviderTest.Tests
{
    [TestClass]
    public class AuthentificationProviderTest
    {
        [TestMethod]
        public void Get()
        {
            libcis.Providers.AuthenticationProvider authentification_test = new libcis.Providers.AuthenticationProvider();
            var result = authentification_test.Get(3);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(libcis.DataAccessLogic.AuthenticationResult));
        }
    }
}

