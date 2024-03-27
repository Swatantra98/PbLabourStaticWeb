using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [StringLength(60)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
