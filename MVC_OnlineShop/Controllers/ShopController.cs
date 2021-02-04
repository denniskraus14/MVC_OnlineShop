using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// using MVC_OnlineShop.Models;
// using PagedList;

namespace MVC_OnlineShop.Controllers
{
    [RoutePrefix("Shop")]
    [IsAuthenticationFilter]
    [Route("{action=Portal}")]
    public class ShopController : Controller
    {

        Cart ShoppingCart = new Cart();

        // GET: Shop
        [HttpGet]
        [Route("Portal", Name = "Portal")]
        [IsAuthorized("Normal")]
        public ActionResult Portal()
        {
            return View();
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Normal")]
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

        [HttpGet]
        [Route("ViewBill")]
        [IsAuthorized("Normal")]
        public ActionResult ViewBill()
        {
            return View();
        }

        //locahost/shop/page1

        //Single Page of Laptop Results
        [HttpGet]
        [Route("Page1", Name = "Page1")]
        [IsAuthorized("Normal")]
        public ViewResult Page1(Customer model) {



            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                /*if (Session[ "UserId" ] != null) {
                    Customer match = context.Customers.Find(Session[ "UserId" ]);
                    if (match.Id == 1) {
                        var products = context.Products
                                                .Select(laptops => laptops)
                                                .Where(p => p.Type == ProductType.Laptop).ToList();

                        ViewData[ "productList" ] = products;

                        return View("Page1");
                    }
                }*/

                var products = context.Products
                                        .Select(laptops => laptops)
                                        .Where(p => p.Type == ProductType.Laptop).ToList();

                ViewData[ "productList" ] = products;

                return View("Page1");


            }
        }

        [HttpGet]
        [Route("Page2")]
        [IsAuthorized("Normal")]
        public ViewResult Page2()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(mobiles => mobiles)
                                        .Where(p => p.Type == ProductType.Mobile).ToList();

                ViewData["productList"] = products;

                return View("Page2");

            }
        }

        [HttpGet]
        [Route("Page3")]
        [IsAuthorized("Normal")]
        public ViewResult Page3()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(tv => tv)
                                        .Where(p => p.Type == ProductType.TV).ToList();

                ViewData["productList"] = products;

                return View("Page3");

            }
        }

        [HttpGet]
        [Route("Page4")]
        [IsAuthorized("Normal")]
        public ViewResult Page4()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(aliens => aliens)
                                        .Where(p => p.Type == ProductType.Alien).ToList();

                ViewData["productList"] = products;

                return View("Page4");

            }
         
        }

        [Route("UnAuthorized")]
        [IsAuthorized("Normal")]
        public ActionResult UnAuthorized() {
            ViewBag.Message = "UnAuthorized Page!";
            return View();
        }

        /*
        //Paging of All Products - delete if not preferred
        public ViewResult Page2()
        {
            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(x => x)
                                        .Where(x => x.Type == "Mobile").ToList();

                ViewData["productList"] = products;

                return View();

            }
        }

        public ViewResult Page3()
        {

            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext())
            {

                var products = context.Products
                                        .Select(x => x)
                                        .Where(x => x.Type == "TV").ToList();

                ViewData["productList"] = products;

                return View();

            }

        }

        public ViewResult Page4()
        {
            List<Product> productList = new List<Product>();
            using (var context = new CustomerContext())
            {
                var products = context.Products
                                        .Select(x => x)
                                        .Where(x => x.Type == "Alien").ToList();
                ViewData["productList"] = products;
                return View();
            }

        }
        //Individual Product Page
        [Route("Product/{Id}")]
        public ActionResult Product(int Id)
        {
            List<Product> product = new List<Product>();
            using (var context = new CustomerContext())
            {
                var products = context.Products
                                        .Select(x => x)
                                        .Where(x => x.Id == Id)
                                        .FirstOrDefault();
                ViewBag.Item = products;
            }
            return View();
        }
        */
    }
}