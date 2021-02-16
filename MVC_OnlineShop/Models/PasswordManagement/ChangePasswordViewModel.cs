using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_OnlineShop.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "New Password")]
        public string NewPass { get; set; }
        [Display(Name = "Re-enter New Password")]
        public string NewPassValidation { get; set; }
    }
}