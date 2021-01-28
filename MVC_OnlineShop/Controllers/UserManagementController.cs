using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineShop.Models;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("User")] // Not sure if this should be named "User" or something else
    [Route("{action=Login}")]
    public class UserManagementController : Controller {

        // GET: UserManagement
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer model)
        {
            if (!ModelState.IsValid) return View(model);
            else
            {
                using (var context = new CostumerContext())
                {
                    Customer user = context.Customers.Where(u => u.UserId == model.UserId).FirstOrDefault();
                    if (user == null)
                    {
                        ModelState.AddModelError("BadUser", $"User {model.UserId} not found");
                        return View(model);
                    }
                    else if (user.Password != model.Password)
                    {
                        ModelState.AddModelError("BadPassword", $"Incorrect password for user {model.UserId} ");
                        return View(model);
                    }
                    else
                    {
                        Session.Timeout = 10;
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        model.LastLoginDate = DateTime.Today;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer model)
        {
            if (!ModelState.IsValid) return View(model);
            else if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("PasswordsDoNotMatch", "Passwords do not Match");
                return View(model);
            }
            else
            {
                using (var context = new CustomerContext())
                {
                    model.Role = context.Roles.Where(r => r.Name.ToLower().Equals("user")).FirstOrDefault();
                    User match = context.Customers.Where(u => u.UserId == model.UserId || u.UserName == model.UserName).FirstOrDefault();
                    if (match != null)
                    {
                        ModelState.AddModelError("ExistingUser", "User Already Exists");
                        return View(model);
                    }
                    else
                    {
                        model.CreatedDate = DateTime.Today;
                        model.LastLoginDate = DateTime.Today;
                        context.Users.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("Login", "User");
                    }
                }
            }
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            User match;
            using (var context = new CustomerContext())
            {
                match = context.Customers.Find(model.UserId);
            }
            if (match != null && match.SecurityQuestion == model.QuestionId && match.QuestionAnswer.ToLower() == model.Answer.ToLower())
            {
                Session["UserId"] = model.UserId;
                Session["UserName"] = match.Username;
                return RedirectToAction("ChangePassword", "User");
            }
            else
            {
                ModelState.AddModelError("QuestionAnswerUserMismatch", "User Id, Question, and answer did not all match");
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (model.NewPass == model.NewPassValidation && Session["UserId"] != null)
            {
                using (var context = new UserContext())
                {
                    Customer match = context.Customers.Find(Session["UserId"]);
                    context.Customers.Remove(match);
                    context.SaveChanges();
                    match.Password = model.NewPass;
                    context.Customers.Add(match);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("PasswordsDoNotMatch", "Passwords do not Match");
                return View(model);
            }
        }
    }
}