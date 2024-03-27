using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PbLabourStatic.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Please enter Document Name")]
        [StringLength(60)]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Please select Document Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Document Date")]
        public DateTime DocumentDateTime { get; set; }

        [Required(ErrorMessage = "Please select Document Type")]
        [Display(Name = "Document Type")]
        public virtual int DocumentTypeId { get; set; }

        [Required]
        [StringLength(120)]
        public string UploadedFileName { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentTypes { get; set; }
    }
}
