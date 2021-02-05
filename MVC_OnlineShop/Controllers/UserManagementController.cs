using MVC_OnlineShop.Models;
using MVC_OnlineShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers {

    [RoutePrefix("Account")]
    [Route("{action=Login}")]
    public class UserManagementController : Controller {

        // GET: UserManagement
        [HttpGet]
        [Route("Login", Name = "Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Route("Login/{model}")]
        public ActionResult Login(Customer model)
        {
            if (ModelState.IsValid) return View(model);
            else
            {
                using (var context = new CustomerContext())
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
        //[Route("Logout", Name = "Logout")]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Register", Name = "Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
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
                    //model.RoleId = context.Roles.Where(r => r.Name.ToLower().Equals("user")).FirstOrDefault().Id;
                    //model.RoleType = RoleType.Administrator;
                    model.RoleId = 1; // Role ID 1 =  Normal

                    Customer match = context.Customers.Where(u => u.UserId == model.UserId || u.UserName == model.UserName).FirstOrDefault();
                    if (match != null)
                    {
                        ModelState.AddModelError("ExistingUser", "User Already Exists");
                        return View(model);
                    }
                    else
                    {
                        model.CreatedDate = DateTime.Today;
                        model.LastLoginDate = DateTime.Today;
                        context.Customers.Add(model);
                        context.SaveChanges();
                        return Redirect("Login");
                    }
                }
            }
        }

        [HttpGet]
        [Route("ForgetPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword/{model}")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            Customer match;
            using (var context = new CustomerContext())
            {
                match = context.Customers.Find(model.UserId);
            }
            if (match != null && match.SecurityQuestion == model.QuestionId && match.QuestionAnswer.ToLower() == model.Answer.ToLower())
            {
                Session["UserId"] = model.UserId;
                Session["UserName"] = match.UserName;
                return RedirectToAction("ChangePassword", "User");
            }
            else
            {
                ModelState.AddModelError("QuestionAnswerUserMismatch", "User Id, Question, and answer did not all match");
                return View(model);
            }
        }

        [HttpGet]
        [Route("ChangePassword")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ChangePassword/{model}")]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (model.NewPass == model.NewPassValidation && Session["UserId"] != null)
            {
                using (var context = new CustomerContext())
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