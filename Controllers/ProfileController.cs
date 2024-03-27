using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PbLabourStatic.Models;
using PbLabourStatic.Services;
using PbLabourStatic.ViewModels;
using System.Diagnostics;

namespace PbLabourStatic.Controllers
{
    public class ProfileController : Controller
    {
       private readonly IDocumentService _documentService;
        private readonly IGenericService _genericService;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; 
        public ProfileController(IDocumentService documentService, IGenericService genericService, AppDbContext context, IConfiguration configuration)
        {
            _documentService = documentService;
            _genericService = genericService;
            _context = context;
            _configuration = configuration;
        }
        public IActionResult ActAndRules()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult ChildLabour()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult CWP()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult FactoryWingReportsandNotifications()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult Notification()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public JsonResult GetNotificationById(string id)
        {
            try
            {
                var data = _context.Documents.Where(x => x.DocumentTypeId ==Convert.ToInt32(id)).OrderByDescending(x => x.DocumentId).ToList();
                List<Document> documents = new List<Document>();
                foreach (var item in data)
                {
                    Document document= new Document();
                    document.DocumentId = Convert.ToInt32(item.DocumentId);
                    document.DocumentName = item.DocumentName;
                    document.UploadedFileName = item.UploadedFileName;
                    document.UpdatedOn = item.UpdatedOn;
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
        public IActionResult OrgStructure()
        {
            return View();
        }
        public IActionResult RightToInformation()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult RightToInformationService()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult RFD()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult LabourWing()
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
        public IActionResult PunjabWelfareBoard()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public async Task<IActionResult> StatisticalInfo()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            try
            {
                var model = new DocumentIndex
                {
                    Documents = await _documentService.GetStatisticalInfo()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult TendersAndPublicNotices()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
