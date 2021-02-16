using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.Item = "Welcome to the Alpha Shop";
            int BlockSize = 4; // products to display, adds to rows of products
            var products = DataManager.GetProducts(1, BlockSize);
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult _ProductList(List<Product> model) {
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _ProductTypeList(List<Product> model) {
            return PartialView(model);
        }

        /// <summary>
        /// Runs every time we scroll the page down and need to populate the enxt block of data
        /// </summary>
        /// <param name="BlockNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InfinateScroll(int BlockNumber) {
            int BlockSize = 4;
            var products = DataManager.GetProducts(BlockNumber, BlockSize);
            JsonModel jsonModel = new JsonModel();
            jsonModel.NoMoreData = products.Count < BlockSize;
            jsonModel.HTMLString = RenderPartialViewToString("_ProductList", products);

            return Json(jsonModel);
        }

        [HttpPost]
        public ActionResult InfinateScrollForProductType(int BlockNumber, string productType) {
            int BlockSize = 4;
            var products = DataManager.GetProductTypes(BlockNumber, BlockSize, productType);
            JsonModel jsonModel = new JsonModel();
            jsonModel.NoMoreData = products.Count < BlockSize;
            jsonModel.HTMLString = RenderPartialViewToString("_ProductTypeList", products);

            return Json(jsonModel);
        }

        /// <summary>
        /// Gets the HTML string
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected string RenderPartialViewToString(string viewName, object model) {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter()) {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        // Make pages more dynamic based on what they selected to be viewed
        // Works, need to resolve the previous and next buttons
        [HttpGet]
        [Route("Page/{productType}", Name = "Page/{productType}")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ViewResult Page(string productType) {
            ViewBag.pageType = productType;

            int BlockSize = 4; // Adds a row of products
            var products = DataManager.GetProductTypes(1, BlockSize, productType);
            return View(products);
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult AddToCart(Product product) {
            if (Session["cart"] == null) {
                using (var context = new SiteContext()) {
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
                using (var context = new SiteContext()) {
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
            cartList.RemoveAt(index); // TODO: Create issue for removing products
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
        public ActionResult ViewBill() {
            return View();
        }


        [Route("UnAuthorized")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult UnAuthorized() {
            ViewBag.Message = "UnAuthorized Page!";
            return View();
        }

        /// <summary>
        /// Individual Product Page
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("Product/{Id}")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult Product(int Id) {
            using (var context = new SiteContext()) {
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