using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_OnlineShop.Models {
    public class Customer {

        [Key]
        [DisplayName("User Id: ")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "required.")]
        public int UserId { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "required.")]
        public string UserName { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = "required.")]
        public string LastName { get; set; }


        [DisplayName("Password: ")]
        [DataType(DataType.Password)]
        /*[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#&()–[{}]:;',?/*~$^+=<>]).{8,20}$", ErrorMessage = "Password is not valid. Regular Expression")]*/
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password: ")]
        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Display(Name = "Security Question")]
        [Required(ErrorMessage = "Required.")]
        public int SecurityQuestion { get; set; }

        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Required.")]
        public string QuestionAnswer { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }

        public int RoleId { get; set; }

        public virtual byte[] File { get; set; }
    }
}