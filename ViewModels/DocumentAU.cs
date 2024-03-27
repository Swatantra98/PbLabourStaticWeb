using System.ComponentModel.DataAnnotations;

namespace PbLabourStatic.ViewModels
{
    public class DocumentAU
    {
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Please enter Document Name")]
        [StringLength(60, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Please select Document Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Document Date")]
        public DateTime DocumentDateTime { get; set; }

        [Required(ErrorMessage = "Please select Document Type")]
        [Display(Name = "Document Type")]
        public int DocumentTypeId { get; set; }

        public string UploadedFilename { get; set; } = String.Empty;

        public IFormFile UploadedFile { get; set; }

        public bool Active { get; set; }
    }
}
