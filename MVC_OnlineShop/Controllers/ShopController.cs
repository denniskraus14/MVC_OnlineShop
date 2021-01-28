using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("Shop")]
    [Route("{action=Index}")]
    public class ShopController : Controller {

        // GET: Shop
        public ActionResult Index() {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
    }
}