﻿using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineShop.Models;

namespace MVC_OnlineShop.Controllers
{

    [RoutePrefix("Shop")]
    [Route("{action=Index}")]
    public class ShopController : Controller
    {

        Cart ShoppingCart = new Cart();

        // GET: Shop
        public ActionResult Index()
        {
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

        //locahost/shop/page1

        public ViewResult Page1()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(laptops => laptops)
                                        .Where(p => p.Type == "laptop").ToList();

                ViewData["productList"] = products;

                return View("Page1");

            }
        }



        public ViewResult Page2()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(mobiles => mobiles)
                                        .Where(p => p.Type == "mobiles").ToList();

                ViewData["productList"] = products;

                return View("Page2");

            }
        }

        public ViewResult Page3()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(tv => tv)
                                        .Where(p => p.Type == "tv").ToList();

                ViewData["productList"] = products;

                return View("Page3");

            }
        }

        public ViewResult Page4()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(aliens => aliens)
                                        .Where(p => p.Type == "aliens").ToList();

                ViewData["productList"] = products;

                return View("Page4");

            }

        }
    }
}