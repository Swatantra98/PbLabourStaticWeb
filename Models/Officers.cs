using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.Models
{
    public class Officers
    {
        [Key]
        public int OfficerId { get; set; }
        public string OfficerCircle { get; set; }
        public string OfficerName { get; set; }
        public string OfficerEmail { get; set; }
        public OfficerDesignation OfficerDesignation { get; set; }
        public string OfficerAddress { get; set; }
        public OfficerType OfficerRole { get; set; }
    }
}
