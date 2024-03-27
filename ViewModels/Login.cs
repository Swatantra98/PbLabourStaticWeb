using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter Username !")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
