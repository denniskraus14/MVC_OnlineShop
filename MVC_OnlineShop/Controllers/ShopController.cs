using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineShop.Models;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("Shop")]
    [Route("{action=Index}")]
    public class ShopController : Controller {

        Cart ShoppingCart = new Cart();

        // GET: Shop
        public ActionResult Index() {
            return View();
        }

        public ActionResult Cart()
        {
            // TO DELETE
            List<Product> products = new List<Product>();
            Product p = new Product(1, "Big HP Laptop", 10,1, "~/Resources/carrotcake.jpeg", "Laptop");
            Product p2 = new Product(1, "Big HP Laptop", 10, 1, "~/Resources/alfredo.jpeg", "Laptop");
            products.Add(p);
            products.Add(p2);
            ViewBag.Products = products;

            //ViewBag["Products"] = ShoppingCart.Products;
            return View();
        }
    }
}