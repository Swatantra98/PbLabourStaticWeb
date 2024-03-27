using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.ViewModels
{
    public class RoleAU
    {
        public string RoleId { get; set; }

        [Required(ErrorMessage = "Please enter Role Name")]
        [StringLength(6, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
