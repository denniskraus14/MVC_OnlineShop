using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class Customer {
        [DisplayName("Id: ")]
        [Required(ErrorMessage = "Id is required.")] // Maybe make tihs auto-increment?
        public int Id { get; set; }

        [DisplayName("User Id: ")]
        [Required(ErrorMessage = "User Id is required.")]
        public string UserId { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [DisplayName("Password: ")]
        /*[DataType(DataType.Password, ErrorMessage = "Password is not valid")]*/
        /*[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#&()–[{}]:;',?/*~$^+=<>]).{8,20}$", ErrorMessage = "Password is not valid. Regular Expression")]*/
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DisplayName("RoleId: ")]
        [Required(ErrorMessage = "Role Id is required.")]
        public int RoleId { get; set; }
    }
}