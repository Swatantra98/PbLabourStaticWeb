using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PbLabourStatic.Models;
using System.Diagnostics;

namespace PbLabourStatic.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ILogger<BranchesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public BranchesController(ILogger<BranchesController> logger, IConfiguration configuration, AppDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }
        public IActionResult AccountsAndFinance()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult FactoryWing()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public JsonResult GetNotificationById(string id)
        {
            try
            {
                var data = _context.Documents.Where(x => x.DocumentTypeId == Convert.ToInt32(id)).OrderBy(x => x.DocumentId).ToList();
                List<Document> documents = new List<Document>();
                foreach (var item in data)
                {
                    Document document = new Document();
                    document.DocumentId = Convert.ToInt32(item.DocumentId);
                    document.DocumentName = item.DocumentName;
                    document.UploadedFileName = item.UploadedFileName;
                    documents.Add(document);
                }
                var json = JsonConvert.SerializeObject(documents);
                return Json(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
