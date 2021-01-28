using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Login(){
            return View();
        }

        public ActionResult Login(Customer customer) {
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