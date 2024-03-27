using PbLabourStatic.Models;

namespace PbLabourStatic.ViewModels
{
    public class DocumentIndex
    {
        public List<Document> Documents { get; set; }
        public string DocumentTypeId { get; set; }
        public string SearchString { get; set; }
    }
}
