using System;
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
                controller = "Products",
                action = "Index",
                category = (string)null,
                page = 1
            }
                );

            routes.MapRoute(null,
            "Page{page}",
            new { controller = "Products", action = "Index", category = (string)null },
            new { page = @"\d+" }
                );

            routes.MapRoute(null,
             "{category}",
            new { controller = "Products", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
             "{category}/Page{page}",
                new { controller = "Products", action = "Index" },
                new { page = @"\d+" }
                 );

            
        }
    }
}
