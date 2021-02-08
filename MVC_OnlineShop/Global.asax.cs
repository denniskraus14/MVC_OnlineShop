using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC_OnlineShop.Migrations;

namespace MVC_OnlineShop {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            CustomerContextMigrations.Migrations();
        }
    }
}
