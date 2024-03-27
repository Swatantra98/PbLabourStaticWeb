using Microsoft.AspNetCore.Mvc;
using PbLabourStatic.Models;
using PbLabourStatic.Services;
using System.Diagnostics;
using PbLabourStatic.ViewModels;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Xml.Linq;

namespace PbLabourStatic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IAccountService _accountService;
        private readonly IGenericService _genericService;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public HomeController(IDocumentService documentService, IAccountService accountService, IGenericService genericService, AppDbContext context, IConfiguration configuration)
        {
            _documentService = documentService;
            _accountService = accountService;
            _genericService = genericService;
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
                ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
                ViewBag.StaticSitePath = _configuration.GetSection("AppPath").GetSection("StaticSitePath").Value;
                // Retrieve DocumentTypes list
                var DocumentType = await _documentService.GetDocumentTypeList();

                // Retrieve top documents
                var topDocuments = await _documentService.GetTop();

                var model = new DocumentIndex
                {
                    Documents = topDocuments,
                    isBannerImageAllow = DocumentType.Any(dt => dt.DocumentTypeName == "Banner"),
                    isGailaryImageAllow = DocumentType.Any(dt => dt.DocumentTypeName == "GailaryImage"),
                    isContentAllow = DocumentType.Any(dt => dt.DocumentTypeName == "Content")
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            ViewBag.StaticSitePath = _configuration.GetSection("AppPath").GetSection("StaticSitePath").Value;
            return View();
        }

        [HttpPost]
        public JsonResult ContactUs(string Role)
        {
            try
            {
                if (Role == "DF")
                {
                    return Json(getOfficers(OfficerType.DF));
                }
                else if (Role == "LC")
                {
                    return Json(getOfficers(OfficerType.LC));
                }
                else
                {
                    return Json(getOfficers(OfficerType.LEO));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        private string getOfficers(OfficerType officerType)
        {
            try
            {
                var data = _context.Officers.Where(x => x.OfficerRole == officerType).OrderBy(x => x.OfficerName).ToList();
                List<Officers> officers = new List<Officers>();
                foreach (var item in data)
                {
                    Officers officer = new Officers();
                    officer.OfficerId = item.OfficerId;
                    officer.OfficerCircle = item.OfficerCircle;
                    officer.OfficerName = item.OfficerName;
                    officer.OfficerRole = item.OfficerRole;
                    officer.OfficerEmail = item.OfficerEmail;
                    officer.OfficerAddress = item.OfficerAddress;
                    officer.OfficerDesignation = item.OfficerDesignation;
                    officers.Add(officer);
                }
                var json = JsonConvert.SerializeObject(officers);
                return json;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            ViewBag.StaticSitePath = _configuration.GetSection("AppPath").GetSection("StaticSitePath").Value;
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult PrivatePolicy()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ScreenReader()
        {
            return View();
        }
        public IActionResult SampleAppFillProcess()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}