using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers
{
    [RoutePrefix("Shop")]
    [IsAuthenticationFilter]
    [Route("{action=Portal}")]
    public class ShopController : Controller {

        private List<CartItem> __cartList;

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
            ViewBag.Item = productType;
            int BlockSize = 4; // Adds a row of products
            var products = DataManager.GetProductTypes(1, BlockSize, productType);  //search:Lenovo
            if (products.Count == 0){
                //the inputted string is not a producttype and should be treated as a search
                //fill var products based off of the search
                using (var context = new SiteContext()){
                    //search logic here
                    products = (List<Product>)context.Products.Select(p => p).Where(p => DbFunctions.Like(p.Name,"%"+productType+"%"));
                }
            }
            return View(products);
        }

        [HttpGet]
        [Route("Cart")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult AddToCart(Product product) {
            using (var context = new SiteContext()) {
                Product prod = context.Products
                                            .Select(p => p)
                                            .Where(p => p.Id == product.Id)
                                            .FirstOrDefault();

                if (Session[ "cart" ] == null) {
                    __cartList = new List<CartItem>();
                    Session[ "count" ] = 1;
                } else {
                    __cartList = (List<CartItem>)Session[ "cart" ];
                    Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) + 1;
                }

                __cartList.Add(new CartItem { Product = prod, Quantity = 1 });

                Session[ "cart" ] = __cartList;

                // Decreases quantity amount in database
                //  - Not sure if this should be here or when Cx checksout and pays. 
                prod.Quantity = prod.Quantity - 1;
            }

            return new RedirectResult(Request.UrlReferrer.AbsoluteUri);
        }

        /// <summary>
        /// The is will display the cart view weather there is products inside
        /// it or not.
        /// </summary>
        [HttpGet]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult CartView() {
            return View(__cartList);
        } 

        /// <summary>
        /// This will get the quantity that is inside the CartView Partial and update the
        /// cart Session. 
        /// </summary>
        /// <param name="formCollection">Post request for product quantity values</param>
        /// <returns>Returns the cartView</returns>
        [HttpPost]
        [Route("UpdateQuantity", Name = "UpdateQuantity")]
        /*public ActionResult UpdateQuantity(FormCollection formCollection) {
            string[ ] quantities = formCollection.GetValues("cartProductQuantity");*/
        public ActionResult UpdateQuantity(CartItem quantities) { 

            __cartList = (List<CartItem>)Session[ "cart" ];
            for (int i = 0; i < __cartList.Count; i++)
                //__cartList[ i ].Quantity = Convert.ToInt32(quantities[ i ]);
                __cartList[ i ].Quantity = quantities.Quantity;

            // Might need to add the additional product to the cartList, Still need testing.
            Session[ "cart" ] = __cartList;
            // TODO: Add Database quantity deductor for when the amount for the product has changed

            if (Session[ "count" ].Equals(0))
                Session[ "cart" ] = null;

            return View("CartView");
        }

        [HttpPost]
        [Route("RemoveProduct", Name = "RemoveProduct")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult RemoveProduct(Product productToRemove) {
            __cartList = (List<CartItem>)Session[ "cart" ];
            __cartList.RemoveAll(item => item.Product.Id == productToRemove.Id);
            Session[ "cart" ] = __cartList;
            Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) - 1;

            return RedirectToAction("CartView", "Shop");
        }

        [HttpGet]
        //[Route("RemoveProductById/{productIdToRemove}", Name = "RemoveProductById")]
        [IsAuthorized("Administrator", "Moderator", "Normal")]
        public ActionResult RemoveProductById(string productIdToRemove) {
            __cartList = (List<CartItem>)Session[ "cart" ];
            int index = isExist(productIdToRemove);
            __cartList.RemoveAt(index); // TODO: Create issue for removing products
            Session[ "cart" ] = __cartList;
            Session[ "count" ] = Convert.ToInt32(Session[ "count" ]) - 1;

            return RedirectToAction("CartView", "Shop");
        }

        private int isExist(string id) {
            __cartList = (List<CartItem>)Session[ "cart" ];
            for (int i = 0; i < __cartList.Count; i++)
                if (__cartList[ i ].Product.Id.Equals(id))
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