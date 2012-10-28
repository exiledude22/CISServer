using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CISServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //the only non-api route where the management panels are found
            //IE: cis-cloud.azurewebsites.net/manage/3
            routes.MapRoute(
                name: "Default",
                url: "manage/{id}",
                defaults: new
                {
                    controller = "ServiceCenter",
                    action = "ManagementPanel",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}