using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class Customer {
        [DisplayName("Id: ")]
        [Required(ErrorMessage = "required.")] // Maybe make tihs auto-increment?
        public int Id { get; set; }

        [DisplayName("User Id: ")]
        [Required(ErrorMessage = "required.")]
        public string UserId { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "required.")]
        public string UserName { get; set; }

        [DisplayName("Password: ")]
        /*[DataType(DataType.Password, ErrorMessage = "Password is not valid")]*/
        /*[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#&()–[{}]:;',?/*~$^+=<>]).{8,20}$", ErrorMessage = "Password is not valid. Regular Expression")]*/
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password: ")]
        [Required(ErrorMessage = "Required.")]
        [Compare("Password", ErrorMessage = "Passwords do nbot match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }

        [DisplayName("RoleId: ")]
        [Required(ErrorMessage = "required.")]
        public int RoleId { get; set; }
    }
}