using Microsoft.AspNetCore.Mvc;
using PbLabourStatic.Models;
using PbLabourStatic.Services;
using System.Diagnostics;
using PbLabourStatic.ViewModels;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using PbLabourStatic.Helpers;
using Microsoft.Extensions.Configuration;

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
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                // Call the stored procedure to get the counts
                var countsData = await GetCounts();

                // Pass the counts to the view model
                var model = new Dashboard
                {
                    FactoryReceived = countsData.FactoryReceived,
                    FactoryApproved = countsData.FactoryApproved,
                    ShopReceived = countsData.ShopReceived,
                    ShopApproved = countsData.ShopApproved,
                    BOCWReceived = countsData.BOCWReceived,
                    BOCWApproved = countsData.BOCWApproved,
                    ContactLabourReceived = countsData.ContactLabourReceived,
                    ContactLabourApproved = countsData.ContactLabourApproved,
                    StateMigrantReceived = countsData.StateMigrantReceived,
                    StateMigrantApproved = countsData.StateMigrantApproved
                };

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<Dashboard> GetCounts()
        {
            try
            {
                // Load configuration
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Retrieve connection string
                string connectionString = configuration.GetConnectionString("DbConStr1");

                // Open connection and execute command
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("GetDashboardDataStaticWeb", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var dashboardApplicationCount = new Dashboard();

                            // Read data and populate dashboard object
                            while (await reader.ReadAsync())
                            {
                                dashboardApplicationCount.FactoryReceived = reader.GetInt32(0);
                                dashboardApplicationCount.FactoryApproved = reader.GetInt32(1);
                                dashboardApplicationCount.ShopReceived = reader.GetInt32(2);
                                dashboardApplicationCount.ShopApproved = reader.GetInt32(3);
                                dashboardApplicationCount.BOCWReceived = reader.GetInt32(4);
                                dashboardApplicationCount.BOCWApproved = reader.GetInt32(5);
                                dashboardApplicationCount.ContactLabourReceived = reader.GetInt32(6);
                                dashboardApplicationCount.ContactLabourApproved = reader.GetInt32(7);
                                dashboardApplicationCount.StateMigrantReceived = reader.GetInt32(8);
                                dashboardApplicationCount.StateMigrantApproved = reader.GetInt32(9);
                            }

                            return dashboardApplicationCount;
                        }
                        await connection.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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