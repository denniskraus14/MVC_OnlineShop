using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_OnlineShop {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );*/

            /*
            routes.MapRoute(
                name: "Page1",
                url: "Shop/Page1",
                defaults: new { controller = "Shop", action = "Page1"}
            );

            routes.MapRoute(
                name: "Login",
                url: "User/Login",
                defaults: new { controller = "UserManagement", action = "Login" }
            );

            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Home", action = "Index" }
            );
            */
        }
    }
}
