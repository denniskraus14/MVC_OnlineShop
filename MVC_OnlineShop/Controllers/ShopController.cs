using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers
{
    [RoutePrefix("Shop")]
    [IsAuthenticationFilter]
    [Route("{action=Portal}")]
    public class ShopController : Controller {
        Cart ShoppingCart = new Cart();

        // GET: Shop
        [HttpGet]
        [Route("Portal", Name = "Portal")]
        //[IsAuthorized("Normal")]
        public ActionResult Portal() {
            List<Product> product = new List<Product>();
            using (var context = new CustomerContext())
            {
                /*
                var productType = context.Products
                                        .Select(type => type)
                                        .FirstOrDefault();*/
                var productType = context.Products.GroupBy(x => x.stringType, (key, g) => g.OrderBy(e => e.Price).FirstOrDefault()).ToList();
                ViewBag.ProductType = productType;
                ViewBag.Item = "Welcome to the Alpha Shop";
                 return View(productType);
            }

            //return View();
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult AddToCart(Product product) {
            if (Session["cart"] == null) {
                using (var context = new CustomerContext()) {
                    Product prod = context.Products
                                                .Select(p => p)
                                                .Where(p => p.Id == product.Id)
                                                .FirstOrDefault();
                    //List<Product> cartList = new List<Product>();
                    //cartList.Add(prod);
                    List<CartItem> cartList = new List<CartItem>();
                    cartList.Add(new CartItem { Product = prod, Quantity = 1 } );
                    Session[ "cart" ] = cartList;
                    // ViewBag.cart = cartList.Count(); // Replaced by Session["count"]
                    Session[ "count" ] = 1;
                    // Decreases quantity amount in database
                    //  - Not sure if this should be here or when Cx checksout and pays. 
                    prod.Quantity = prod.Quantity - 1;
                }
            } else {
                using (var context = new CustomerContext()) {
                    Product prod = context.Products
                                                .Select(p => p)
                                                .Where(p => p.Id == product.Id)
                                                .FirstOrDefault();
                    //List<Product> cartList = (List<Product>)Session[ "cart" ];
                    //cartList.Add(prod);
                    List<CartItem> cartList = (List<CartItem>)Session[ "cart" ];
                    cartList.Add( new CartItem { Product = prod, Quantity = 1 });
                    Session[ "cart" ] = cartList;
                    // ViewBag.cart = cartList.Count(); // Replaced by Session["count"]
                    Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) + 1;
                    // Decreases quantity amount in database
                    //  - Not sure if this should be here or when Cx checksout and pays. 
                    prod.Quantity = prod.Quantity - 1;
                }
            }

            //return RedirectToAction("Portal", "Shop");
            //return new EmptyResult(); // Returns an error
            return new RedirectResult(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpGet]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult CartView() {
            /*return View( (List<Product>) Session[ "cart" ] );*/
            return View((List<CartItem>)Session[ "cart" ]);
        } 

        [HttpPost]
        [Route("UpdateQuantity", Name = "UpdateQuantity")]
        public ActionResult UpdateQuantity(FormCollection formCollection) {
            string[ ] quantities = formCollection.GetValues("cartProductQuantity");
            /*List<Product> cartList = (List<Product>)Session[ "cart" ];*/
            List<CartItem> cartList = (List<CartItem>)Session[ "cart" ];
            for (int i = 0; i < cartList.Count; i++)
                cartList[ i ].Quantity = Convert.ToInt32(quantities[ i ]);
            // Might need to add the additional product to the cartList, Still need testing.
            Session[ "cart" ] = cartList;
            return View("CartView");
        }

        [HttpGet]
        [Route("RemoveProduct", Name = "RemoveProduct")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult RemoveProduct(Product productToRemove) {
            /*List<Product> cartList = (List<Product>)Session[ "cart" ];*/
            /*cartList.RemoveAll(p => p.Id == productToRemove.Id);*/
            List<CartItem> cartList = (List<CartItem>)Session[ "cart" ];
            cartList.RemoveAll(item => item.Product.Id == productToRemove.Id);
            Session[ "cart" ] = cartList;
            Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) - 1;

            return RedirectToAction("CartView", "Shop");
        }

        [HttpGet]
        [Route("RemoveProductById", Name = "RemoveProductById")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult RemoveProductById(string productIdToRemove) {
            List<CartItem> cartList = (List<CartItem>)Session[ "cart" ];
            int index = isExist(productIdToRemove);
            cartList.RemoveAt(index);
            Session[ "cart" ] = cartList;
            Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) - 1;

            return RedirectToAction("CartView", "Shop");
        }

        private int isExist(string id) {
            List<CartItem> cartList = (List<CartItem>)Session[ "cart" ];
            for (int i = 0; i < cartList.Count; i++)
                if (cartList[ i ].Product.Id.Equals(id))
                    return i;
            return -1;
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
                return View(products);
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