/*using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Controllers
{
    public class FileController : Controller
    {
        private CustomerContext context = new CustomerContext();
        //
        // GET: /File/
        //[Route("")]
        public ActionResult File(string id)
        {
            using (var context = new CustomerContext())
            {
                var fileToRetrieve = context.Files.Select(p => p).Where(i => i.PersonId==id).FirstOrDefault();
                return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
            }
        }
    }
}*/