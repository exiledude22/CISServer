﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CISServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApiWithNames",
                routeTemplate: "api/authentication/{marker_id}",
                defaults: new
                {
                    controller = "authentication",
                    marker_id = RouteParameter.Optional
                }
                );

            config.Routes.MapHttpRoute(
                name: "iasdf",
                routeTemplate: "api/services/{action}",
                defaults: new
                {
                    controller = "services"
                }
                );
            
            config.Routes.MapHttpRoute(
                name: "iiiio",
                routeTemplate: "api/services/{action}/{provider_id}",
                defaults: new
                {
                    controller = "services",
                    provider_id = RouteParameter.Optional
                }
                );
            config.Routes.MapHttpRoute(
    name: "sdfagfsagfa",
    routeTemplate: "api/provider/{action}/{provider_id}",
    defaults: new
    {
        controller = "provider",
        provider_id = RouteParameter.Optional
    }
    );
            /*
            config.Routes.MapHttpRoute(
               name: "orderss",
               routeTemplate: "api/services/{action}",
               defaults: new
               {
                   controller = "services",
                   marker_id = RouteParameter.Optional
               }
               );
            */
        }
    }
}