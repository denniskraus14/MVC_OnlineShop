using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers {

    //[RoutePrefix("")]
    [RoutePrefix("Home")]
    [Route("{action=Index}")]
    public class HomeController : Controller {

        [HttpGet]
        [Route("Index", Name = "Index")]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        [Route("Contact", Name = "Contact")]
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}