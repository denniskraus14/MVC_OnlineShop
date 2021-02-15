using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class CustomerWithFile
    {
        public Customer Customer { get; set; }
        public File File { get; set; }
    }
}