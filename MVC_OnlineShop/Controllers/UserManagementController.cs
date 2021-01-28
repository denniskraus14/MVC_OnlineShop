using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("User")] // Not sure if this should be named "User" or something else
    [Route("{action=Login}")]
    public class UserManagementController : Controller {
        
        // GET: UserManagement
        public ActionResult Login(){
            return View();
        }

        public ActionResult Login(Customer customer) {
            // TODO: Add logic here
            return View(customer);
        }

        public ActionResult Logout() {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}