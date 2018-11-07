﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineMarket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(null,
            "",
            new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                page = 1
            }
                );

            routes.MapRoute(null,
             "{category}",
            new { controller = "Product", action = "List", page = 1 }
            );
        }
    }
}
