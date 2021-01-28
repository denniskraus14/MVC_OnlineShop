using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_OnlineShop.Models
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Display(Name = "Security Question")]
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}