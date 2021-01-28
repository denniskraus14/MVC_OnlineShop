using MVC_OnlineShop.Models;
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

        //locahost/shop/page1

        public ViewResult Page1() {

            List<Product> productList = new List<Product>();

            using(var context = new CustomerContext()) {

                var products = context.Products
                                        .Select(laptops => laptops)
                                        .Where(p => p.Type == "laptop").ToList();

                ViewData["productList"] = products;

                //return RedirectToAction("Index", "Shop");
                return View("Page1");
               
            }
            

            //return View()
        }
    }
}