using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PbLabourStatic.Helpers;
using PbLabourStatic.Models;

namespace PbLabourStatic.Services
{
    public interface IDocumentService
    {
        Task<List<DocumentType>> GetDocumentTypeList();

        Task<List<Document>> GetMany();
        Task<List<Document>> GetTop();
        Task<List<Document>> GetStatisticalInfo();
        Task<List<Document>> GetNotification();
        Task<List<Document>> GetNotificationById(int? id);

        Task<PaginatedList<Document>> GetMany(string documentTypeId, string searchString, int pageNumber);

        Task<Document> GetById(int? id);

        Task<int> Add(Document model);

        Task<int> Update(Document model);

        Task<int> Delete(Document model);
    }

    public class DocumentService : IDocumentService
    {
        private readonly AppDbContext _context;
        private readonly AppSettings _appSettings;

        public DocumentService(AppDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<List<DocumentType>> GetDocumentTypeList()
        {
            return await _context.DocumentTypes.Where(dt => dt.Active == true).ToListAsync();
        }

        public async Task<List<Document>> GetMany()
        {
            return await _context.Documents.Include(ar => ar.DocumentTypes).ToListAsync();
        }
        public async Task<PaginatedList<Document>> GetMany(string documentTypeId, string searchString = null, int pageNumber = 1)
        {
            var documents = from d in _context.Documents
                            select d;

            if (!string.IsNullOrEmpty(documentTypeId))
            {
                int numericDocumentTypeId;
                bool isParsable = Int32.TryParse(documentTypeId, out numericDocumentTypeId);
                if ((isParsable) && numericDocumentTypeId != 0)
                    documents = documents.Where(d => d.DocumentTypeId == numericDocumentTypeId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                pageNumber = 1;
                documents = documents.Where(d => d.DocumentName!.Contains(searchString));
            }

            int pageSize = Int16.Parse(_appSettings.PageSize);

            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            //   return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));

            return await PaginatedList<Document>.CreateAsync(documents.Include(ar => ar.DocumentTypes), pageNumber, pageSize);
        }
        public async Task<List<Document>> GetTop()
        {
            return await _context.Documents.OrderByDescending(ar => ar.DocumentId).Take(9).ToListAsync();
        }
        public async Task<List<Document>> GetStatisticalInfo()
        {
            return await _context.Documents.Where(x => x.DocumentTypeId == 4).OrderBy(x => x.DocumentId).ToListAsync();
        }
        public async Task<List<Document>> GetNotification()
        {
            return await _context.Documents.Where(x => x.DocumentTypeId == 17).OrderBy(x => x.DocumentId).ToListAsync();
        }
        public async Task<List<Document>> GetNotificationById(int? id)
        {
            return await _context.Documents.Where(x => x.DocumentTypeId == id).OrderBy(x => x.DocumentId).ToListAsync();
        }
        public async Task<Document> GetById(int? id)
        {
            return await _context.Documents.FindAsync(id);
        }
        public async Task<int> Add(Document model)
        {
            _context.Documents.Add(model);
            var res = await _context.SaveChangesAsync();
            return res;
        }

        public async Task<int> Update(Document model)
        {
            var document = _context.Documents.Attach(model);
            document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var res = await _context.SaveChangesAsync();
            return res;
        }


        public async Task<int> Delete(Document document)
        {
            _context.Documents.Remove(document);
            var res = await _context.SaveChangesAsync();
            return res;
        }
    }
}
