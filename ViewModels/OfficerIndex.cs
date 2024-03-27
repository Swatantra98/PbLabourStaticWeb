using PbLabourStatic.Models;

namespace PbLabourStatic.ViewModels
{
    public class OfficerIndex
    {
        public List<Officers> Officers { get; set; }
        public string OfficerTypeId { get; set; }
        public string SearchString { get; set; }
    }
}
