using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Please enter Document Type")]
        public string DocumentTypeName { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
