/*
Copyright 2012 CIS(Chiciu Bogdan, Cojocaru Aurelian)
https://github.com/exiledude22/CISServer/blob/master/README.md

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using libcis.DataAccessLogic;

namespace CISServer.Controllers
{
    /// <summary>
    /// Authentication API controller.
    /// </summary>
    public class AuthenticationController : ApiController, libcis.DataAccessLogic.IProviderHost<IAuthenticationProvider>
    {
        private IAuthenticationProvider providerInstance;
        
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            providerInstance = new libcis.Providers.AuthenticationProvider();
            base.Initialize(controllerContext);
        }

        /// <summary>
        /// Controller provider instance.
        /// </summary>
        public IAuthenticationProvider Provider
        {
            get
            {
                return providerInstance;
            }
        }

        /// <summary>
        /// Authenticates a hotspot marker provided by a consumer application. 
        /// </summary>
        /// <param name="marker_id">The ID of the marker to authenticate</param>
        /// <returns>An <see cref="AuthenticationResult"/> object indicating whether the operation succeded.</returns>
        /// <remarks>
        /// The <see cref="AuthenticationResult"/> will also contain the provider_id, hotspot_id and order_id
        /// if the operation succeded.
        /// </remarks>
        [HttpGet]
        public libcis.DataAccessLogic.AuthenticationResult Get(int marker_id)
        {
            return providerInstance.Get(marker_id);
        }
    }
}
