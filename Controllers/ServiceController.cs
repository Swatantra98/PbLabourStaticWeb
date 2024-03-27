using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PbLabourStatic.Models;
using System.Diagnostics;

namespace PbLabourStatic.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public ServiceController(ILogger<ServiceController> logger, IConfiguration configuration, AppDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }
        public IActionResult BOCW()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult BuildingPlanApproval()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult ContractLabour()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult FactoryLicence()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult FormsAndProcedures()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult InterStateMigrantWorkmen()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult MotorTransport()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult ShopsCommercial()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }
        public IActionResult TradeUnion()
        {
            ViewBag.pbLabourAdminStaticBaseUrl = _configuration.GetSection("AppPath").GetSection("pbLabourAdminStaticBaseUrl").Value;
            ViewBag.rootPath = _configuration.GetSection("AppPath").GetSection("rootPath").Value;
            return View();
        }

        public IActionResult NightShift()
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
