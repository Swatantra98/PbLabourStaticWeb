using PbLabourStatic.Models;

namespace PbLabourStatic.ViewModels
{
    public class UserIndex
    {
        public PaginatedList<ApplicationUserWithRoles> Users { get; set; }
        public string SearchString { get; set; }
    }
}
