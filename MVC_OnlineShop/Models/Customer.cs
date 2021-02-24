using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_OnlineShop.Models {
    public class Customer: IValidatableObject
    {

        [Key]
        [DisplayName("User Id: ")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "required.")]
        public int UserId { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "required.")]
        [StringLength(50)]
        [Index("Ix_UserName", Order = 1, IsUnique = true)]
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
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(50)]
        [Index("Ix_Email", Order = 2, IsUnique = true)]
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

        [MaxLength(2000000000, ErrorMessage = "File is too large. (2MB limit)")]
        public virtual byte[] File { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            Customer current = (Customer)validationContext.ObjectInstance;
            SiteContext context = new SiteContext();
            List<ValidationResult> validationResult = new List<ValidationResult>();
            var validateName = context.Customers.FirstOrDefault(x => x.UserName == UserName);
            if (validateName != null && validateName.UserId != current.UserId){
                ValidationResult errorMessage = new ValidationResult
                ("UserName already exists.", new[] { "UserName" });
                yield return errorMessage;
            }
            var validateEmail = context.Customers.FirstOrDefault(x => x.Email == Email);
            if (validateEmail != null && validateEmail.UserId != current.UserId){
                ValidationResult errorMessage = new ValidationResult
                ("Email already in use.", new[] { "Email" });
                yield return errorMessage;
            }

            yield return ValidationResult.Success;
        }
    }
}