using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorld
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home", //name is a key which should be unique for different routes
                url: "Home",
                defaults: new { controller = "Home", action = "GotoHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home1", //name is a key which should be unique for different routes
                url: "Home/Home",
                defaults: new { controller = "Home", action = "GotoHome", id = UrlParameter.Optional }
            );

            //Start page in MVC can be set like this
            //routes.MapRoute(
            //    name: "Home2", //name is a key which should be unique for different routes
            //    url: "",
            //    defaults: new { controller = "Home", action = "GotoHome", id = UrlParameter.Optional }
            //);

            //this should be always last in the sequence so that it won't get invoke at first instance
            routes.MapRoute(
                name: "Default", //name is a key which should be unique for different routes
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
