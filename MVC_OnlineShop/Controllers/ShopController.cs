﻿using MVC_OnlineShop.Models;
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
            //List<Product> products = new List<Product>();
            //Product p = new Product(1, "Big HP Laptop", 10,1, "carrotcake.jpeg", "Laptop");
            //Product p2 = new Product(1, "Big HP Laptop", 10, 1, "alfredo.jpg", "Laptop");
            //products.Add(p);
            //products.Add(p2);
            //ViewBag.Products = products;

            ViewBag["Products"] = ShoppingCart.Products;
            return View();
        }

        public ActionResult ViewBill()
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