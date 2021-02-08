using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System;
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
                //ViewBag.Item = productType;
                ViewBag.ProductType = productType;
                ViewBag.Item = "Welcome to the Alpha Shop";
            }

            return View();
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult Cart(Product product) {
            if (Session["cart"] == null) {
                using (var context = new CustomerContext()) {
                    Product prod = context.Products
                                                .Select(p => p)
                                                .Where(p => p.Id == product.Id)
                                                .FirstOrDefault();
                    List<Product> cartList = new List<Product>();
                    cartList.Add(prod);
                    Session[ "cart" ] = cartList;
                    ViewBag.cart = cartList.Count();
                    Session[ "count" ] = 1;
                }
            } else {
                using (var context = new CustomerContext()) {
                    Product prod = context.Products
                                                .Select(p => p)
                                                .Where(p => p.Id == product.Id)
                                                .FirstOrDefault();
                    List<Product> cartList = (List<Product>)Session[ "cart" ];
                    cartList.Add(prod);
                    Session[ "cart" ] = cartList;
                    ViewBag.cart = cartList.Count();
                    Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) + 1;
                }
            }

            return RedirectToAction("Portal", "Shop");
        }

        [HttpGet]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        // TODO: Make this the new cart html page. 
        // TODO: Put cart html into cartView html
        public ActionResult CartView() { 
            return View( (List<Product>) Session[ "cart" ] );
        } 

        [HttpGet]
        [Route("RemoveProduct", Name = "RemoveProduct")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult RemoveProduct(Product productToRemove) {
            List<Product> cartList = (List<Product>)Session[ "cart" ];
            cartList.RemoveAll(p => p.Id == productToRemove.Id);
            Session[ "cart" ] = cartList;
            Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) - 1;

            return RedirectToAction("CartView", "Shop");
        }

        [HttpGet]
        [Route("ViewBill")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        // TODO: Make ViewBill html page 
        //          - Will only have the payment stuff in this html page along with how to pay for products.
        public ActionResult ViewBill() {
            return View();
        }

        // Make pages more dynamic based on what they selected to be viewed
        // Works, need to resolve the previous and next buttons
        [HttpGet]
        [Route("Page/{productType}", Name = "Page/{productType}")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ViewResult Page(string productType) {
            using ( var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(type => type)
                                        .Where(p => p.stringType == productType).ToList();
                ViewData[ "stringProductList" ] = products;
                ViewBag.Item = productType + "s";
                return View("Page");
            }
        }

        [Route("UnAuthorized")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        // TODO: Work on a more dynamic not authorized page
        public ActionResult UnAuthorized() {
            ViewBag.Message = "UnAuthorized Page!";
            return View();
        }
        
        //Individual Product Page
        [Route("Product/{Id}")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        // TODO: Change how this page is being rendered.
        public ActionResult Product(int Id) {
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