using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.ViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage="Please enter Current Password !")]
        [DataType(DataType.Password)]
        [Display(Name="Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter New Password !")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password !")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
      //  [Compare("NewPassword", ErrorMessage = "New & Confirm Passwords must be same !")]
        public string ConfirmPassword { get; set; }
    }
}
