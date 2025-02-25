﻿using MVC_OnlineShop.Models;
using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Model;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Web;

namespace MVC_OnlineShop.Controllers
{

    [RoutePrefix("Account")]
    [Route("{action=Login}")]
    public class UserManagementController : Controller{

        private AES _encrypt = new AES();
        private ContentRepository _image = new ContentRepository();

        // GET: UserManagement
        [HttpGet]
        [Route("Login", Name = "Login")]
        public ActionResult Login(){
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer model){
            if (ModelState.IsValid) return View(model);
            else{
                using (var context = new SiteContext()){
                    //Customer user = context.Customers.Where(u => u.UserId == model.UserId).FirstOrDefault();
                    Customer user = context.Customers.Where(u => u.Email == model.Email).FirstOrDefault();

                    //model.Password = Encryption(model.Password);
                    model.Password = _encrypt.Encryption(model.Password);

                    if (user == null){
                        ModelState.AddModelError("BadUser", $"User {model.UserId} not found");
                        return View(model);
                    }
                    else if (user.Password != model.Password){
                        ModelState.AddModelError("BadPassword", $"Incorrect password for user {model.UserId} ");
                        return View(model);
                    }
                    else{
                        Session.Timeout = 10;
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        model.LastLoginDate = DateTime.Today;
                        if (model.File == null){
                            model.File = new byte[] { };
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(){
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Register", Name = "Register")]
        public ActionResult Register(){
            return View();
        }

        //[HttpPost]
        //[Route("Register")]
        public ActionResult Register(Customer model){
                if (!ModelState.IsValid) return View(model);
                //the password is checked using the [Compare] tag. (checked before this post method is invoked). See Customer
                /*else if (model.Password != model.ConfirmPassword){
                    ModelState.AddModelError("PasswordsDoNotMatch", "Passwords do not match!");
                    return View(model);
                }*/
                else{
                using (var context = new SiteContext()) {
                    //model.RoleId = context.Roles.Where(r => r.Name.ToLower().Equals("user")).FirstOrDefault().Id;
                    //model.RoleType = RoleType.Administrator;
                    model.RoleId = 3; // Role ID 3 =  Normal

                    Customer match = context.Customers.Where(u => u.UserName == model.UserName || u.Email == model.Email).FirstOrDefault();
                    //this is now being checked by the modelstate checker. see customer entity class
                    /*
                    if (match != null){
                        ModelState.AddModelError("ExistingUser", "Please choose a different username");
                        return View(model);
                    }
                    else{*/
                    model.CreatedDate = DateTime.Today;
                    model.LastLoginDate = DateTime.Today;

                    HttpPostedFileBase file = Request.Files["ImageData"];
                    if (file != null){
                        byte[] arr = _image.ConvertToBytes(file);
                        if (arr.Length <= 2000000){
                            model.File = arr;
                        }
                        else{
                            //display a warning and do not let the user register
                            ModelState.AddModelError("File", "File too large. Upload limit: 2MB");
                            return View(model);
                        }
                    }
                    else{
                        model.File = new byte[] { };
                    }
         
                    //model.Password = Encryption(model.Password);
                    //model.ConfirmPassword = Encryption(model.ConfirmPassword);
                    model.Password = _encrypt.Encryption(model.Password);
                    model.ConfirmPassword = _encrypt.Encryption(model.ConfirmPassword);

                    context.Customers.Add(model);
                    try{
                        context.SaveChanges();}
                    catch{
                        ModelState.AddModelError("File too large", "Please choose a different file");
                        return View(model);}
                    return Redirect("Login");
                }
            }
        }

        //[HttpPost]
        [Route("RetrieveImage/{id}", Name = "RetrieveImage")]
        public ActionResult RetrieveImage(int id){
            using (var context = new SiteContext()){
                byte[] cover = context.Customers.Select(p => p).Where(p => id == p.UserId).FirstOrDefault().File;
                if (cover != null){
                    return File(cover, "image/jpeg");
                }
                return null;
            }
        }

        [HttpGet]
        [Route("ForgotPassword", Name = "ForgotPassword")]
        public ActionResult ForgotPassword(){
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model){
            Customer match;
            using (var context = new SiteContext()){
                match = context.Customers.Select(cx=>cx).Where(cx => cx.Email==model.Email).FirstOrDefault(); //changed this to match based on Email rather than User Id- Dennis
            }

            if (match != null && match.SecurityQuestion == model.QuestionId && match.QuestionAnswer.ToLower() == model.Answer.ToLower()){
                Session["UserId"] = match.UserId;
                Session["UserName"] = match.UserName;
                return RedirectToAction("ChangePassword");
            }
            else{
                ModelState.AddModelError("QuestionAnswerUserMismatch", "User Id, Question, and answer did not all match");
                return View(model);
            }
        }

        [HttpGet]
        [Route("ChangePassword", Name = "ChangePassword")]
        public ActionResult ChangePassword(){
            return View();
        }

        [HttpPost]
        //[Route("ChangePassword/{model}")]
        public ActionResult ChangePassword(ChangePasswordViewModel model){
            if (model.NewPass == model.NewPassValidation && Session["UserId"] != null){
                using (var context = new SiteContext()){
                    Customer cxLoggedIn = context.Customers.Find(Session["UserId"]);
                    //context.Customers.Remove(cxLoggedIn);
                    //context.SaveChanges();
                    //cxLoggedIn.Password = model.NewPass = Encryption(model.NewPass);
                    cxLoggedIn.Password = model.NewPass = _encrypt.Encryption(model.NewPass);
                    cxLoggedIn.ConfirmPassword = model.NewPassValidation = _encrypt.Encryption(model.NewPassValidation);
                    //context.Customers.Add(cxLoggedIn);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else{
                ModelState.AddModelError("PasswordsDoNotMatch", "Passwords do not match");
                return View(model);
            }
        }

        [HttpGet]
        [Route("Profile", Name = "Profile")]
        public ActionResult UserProfile(){
            Customer match;
            //File file = null;
            using (var context = new SiteContext()){
                match = context.Customers.Find(Session["UserId"]);
                return View(match);
            }
        }

        [HttpGet]
        [Route("Edit", Name = "Edit")]
        public ActionResult Edit(){
            Customer cx = null;
            using (var context = new SiteContext()){
                cx = context.Customers.Find(Session["UserId"]);
            }
            return View(cx);
        }


        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(Customer model){
            using (var context = new SiteContext()){
                Customer current = context.Customers.Find(Session["UserId"]);

                //email
                if (model.Email != current.Email){
                    //check to see that the email is available
                    Customer temp = context.Customers.Select(p => p).Where(p => p.Email == model.Email).FirstOrDefault();
                    if (temp == null){
                        //the email is available
                        current.Email = model.Email;
                    }
                    else{
                        ModelState.AddModelError("Email", "That email is already in use");
                        return View(model);
                    }
                }

                //username
                if (model.UserName != current.UserName){
                    //check to see that the email is available
                    Customer temp = context.Customers.Select(p => p).Where(p => p.UserName == model.UserName).FirstOrDefault();
                    if (temp == null){
                        //the username is available
                        current.UserName = model.UserName;
                        Session[ "UserName" ] = current.UserName;
                    }
                    else{
                        ModelState.AddModelError("UserName", "That Username is already in use");
                        return View(model);
                    }
                }

                //profile photo
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0){ //if they have uploaded something,
                    byte[] arr = _image.ConvertToBytes(file);
                    if (arr.Length <= 2000000){
                        current.File = arr;
                    }
                    else{
                        ModelState.AddModelError("File", "File too large. Upload limit: 2MB");
                        return View(model);
                    }
                }
                try{ 
                    context.SaveChanges(); //in case the model is not valid. it will force the correct input
                }
                catch{
                    return View(model);
                }
                return RedirectToAction("UserProfile");
            }
        }

    }
}