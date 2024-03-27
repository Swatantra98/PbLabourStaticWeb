using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.ViewModels
{
    public class UserUpdate
    {
        [Required(ErrorMessage = "User Id not found !")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter Username")]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        [Remote(action: "IsUserNameInUse", controller: "Account")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter alphabets only !")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter alphabets only !")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter alphabets only !")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Mobile No.")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only !")]
       // [Remote(action: "IsMobileNoInUse", controller: "Account")]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [StringLength(60, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "Please enter valid Email !")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
