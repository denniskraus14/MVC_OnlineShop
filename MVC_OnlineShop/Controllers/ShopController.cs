using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers
{
    [RoutePrefix("Shop")]
    //[IsAuthenticationFilter]
    [Route("{action=Portal}")]
    public class ShopController : Controller {
        Cart ShoppingCart = new Cart();

        // GET: Shop
        [HttpGet]
        [Route("Portal", Name = "Portal")]
        //[IsAuthorized("Normal")]
        public ActionResult Portal() {
            List<Product> product = new List<Product>();
            using (var context = new CustomerContext()) {
                var productType = context.Products
                                        .Select(type => type)
                                        .FirstOrDefault();
                ViewBag.Item = productType;
            }
            return View();
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Normal")]
        public ActionResult Cart() {
            ViewBag["Products"] = ShoppingCart.Products;
            return View();
        }

        [HttpGet]
        [Route("ViewBill")]
        [IsAuthorized("Normal")]
        public ActionResult ViewBill() {
            return View();
        }

        //locahost/shop/page1

        //Single Page of Laptop Results
        [HttpGet]
        [Route("Page1", Name = "Page1")]
        [IsAuthorized("Normal")]
        public ViewResult Page1(Customer model) {
            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(laptops => laptops)
                                        .Where(p => p.Type == ProductType.Laptop).ToList();

                ViewData["productList"] = products;

                return View("Page1");
            }
        }

        [HttpGet]
        [Route("Page2", Name = "Page2")]
        [IsAuthorized("Normal")]
        public ViewResult Page2() {
            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(mobiles => mobiles)
                                        .Where(p => p.Type == ProductType.Mobile).ToList();

                ViewData["productList"] = products;

                return View("Page2");
            }
        }

        [HttpGet]
        [Route("Page3", Name = "Page3")]
        [IsAuthorized("Normal")]
        public ViewResult Page3() {
            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(tv => tv)
                                        .Where(p => p.Type == ProductType.TV).ToList();

                ViewData["productList"] = products;

                return View("Page3");
            }
        }

        [HttpGet]
        [Route("Page4", Name = "Page4")]
        [IsAuthorized("Normal")]
        public ViewResult Page4() {
            List<Product> productList = new List<Product>();

            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(aliens => aliens)
                                        .Where(p => p.Type == ProductType.Alien).ToList();

                ViewData["productList"] = products;

                return View("Page4");
            }
        }

        // Make pages more dynamic based on what they selected to be viewed
        // Works, need to resolve the previous and next buttons
        [HttpGet]
        [Route("Page/{productType}", Name = "Page/{productType}")]
        [IsAuthorized("Normal")]
        public ViewResult Page(string productType) {
            List<Product> productList = new List<Product>();

            using ( var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(type => type)
                                        .Where(p => p.stringType == productType).ToList();
                ViewData[ "stringProductList" ] = products;
                return View("Page");
            }
        }

        [Route("UnAuthorized")]
        [IsAuthorized("Normal")]
        public ActionResult UnAuthorized() {
            ViewBag.Message = "UnAuthorized Page!";
            return View();
        }
        
        //Individual Product Page
        [Route("Product/{Id}")]
        [IsAuthorized("Normal")]
        public ActionResult Product(int Id) {
            List<Product> product = new List<Product>();
            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(x => x)
                                        .Where(x => x.Id == Id)
                                        .FirstOrDefault();
                ViewBag.Item = products;
            }
            return View();
        }

    }
}