using PbLabourStatic.Models;

namespace PbLabourStatic.ViewModels
{
    public class DocumentIndex
    {
        public List<Document> Documents { get; set; }
        public string DocumentTypeId { get; set; }
        public string SearchString { get; set; }
        public bool isGailaryImageAllow { get; set; }
        public bool isBannerImageAllow { get; set; }
        public bool isPdfAllow { get; set; }
        public bool isContentAllow { get; set; }
    }
}
