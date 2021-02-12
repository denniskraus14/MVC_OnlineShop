using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("Home")]
    [Route("{action}")]
    public class HomeController : Controller {

        [HttpGet]
        [Route("~/")]
        [Route("")]
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

        [HttpGet]
        [Route("About", Name = "About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";
            return View();
        }
    }
}