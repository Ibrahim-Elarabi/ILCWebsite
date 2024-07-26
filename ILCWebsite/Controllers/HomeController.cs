using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.AboutUs;
using ILC.BL.Models.Admin.HomeSection.Achievements;
using ILC.BL.Models.Admin.HomeSection.Agent;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.CustomerSupport;
using ILC.BL.Models.Admin.HomeSection.Downloads;
using ILC.BL.Models.Admin.HomeSection.EventGalaries;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Models.Admin.HomeSection.Service;
using ILC.BL.Models.Admin.HomeSection.Slider;
using ILC.BL.Models.Admin.HomeSection.SomeFunFactorImages;
using ILC.BL.Models.Admin.HomeSection.Staff;
using ILC.BL.Models.Admin.HomeSection.Titles;
using ILC.BL.Models.Admin.HomeSection.ValuesHome;
using ILC.BL.Models.WebSite.Home;
using ILC.Domain.DBEntities;
using ILCWebsite.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ILCWebsite.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment hostingEnvironment,
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            if(DateTime.Now.Date > new DateTime(2024, 09, 01))
            {
                throw new Exception("Sorry Exception");
            }
            var aboutUS = _unitOfWork._aboutUsHomeService.FindOne();
            var silders = _unitOfWork._sliderHomeService.GetAll();
            var services = _unitOfWork._serviceHomeRepo.GetAll().Where(prod => prod.AppearInHome == true && prod.IsDeleted != true);
            var categorys = _unitOfWork._categoryRepo.GetAll().Where(prod => prod.AppearInHome == true && prod.IsDeleted != true);
            var products = _unitOfWork._productHomeRepo.GetAll().Where(prod => prod.IsAppearInHome == true && prod.IsDeleted != true);
            //var agents = _unitOfWork._agentHomeRepo.GetAll();
            var blogs = _unitOfWork._blogHomeRepo.GetAll().Where(prod => prod.AppearInHome == true && prod.IsDeleted != true);
            //var staffs = _unitOfWork._staffHomeRepo.GetAll().Where(prod => prod.AppearInHome == true && prod.IsDeleted != true).OrderBy(d=>d.Order);
            var achievements = _unitOfWork._AchievementRepo.GetAll();
            //var eventsGalaries = _unitOfWork._eventGalaryRepo.GetAll();
            var ourValues = _unitOfWork._valueHomeRepo.GetAll().Where(d => d.AppearInHome == true && d.IsDeleted != true);
            //var downloadsTemplates = _unitOfWork._DownloadRepo.GetAll().Where(d=>d.AppearInHome == true && d.FileType == ILC.Domain.Enums.PdfTypesEnum.Template).ToList();
            var downloadsCategories = _unitOfWork._DownloadRepo.GetAll().Where(d=>d.AppearInHome == true && d.FileType == ILC.Domain.Enums.PdfTypesEnum.Cataloge).ToList();
            var someFunFactorImages = _unitOfWork._someFunFactoImageRepo.GetAll();
            var model = new HomePageVM()
            {
                Silder = _mapper.Map<List<SliderHomeVM>>(silders).ToList(),
                AboutUS = _mapper.Map<AboutUsHomeVM>(aboutUS),
                Services = _mapper.Map<List<ServiceHomeVM>>(services).ToList(),
                Categorys = _mapper.Map<List<CategoryVM>>(categorys).ToList(),
                Products = _mapper.Map<List<ProductHomeVM>>(products),
                //Agents = _mapper.Map<List<AgentHomeVM>>(agents).ToList(),
                Blogs = _mapper.Map<List<BlogHomeVM>>(blogs).ToList(),
                //Staffs = _mapper.Map<List<StaffHomeVM>>(staffs).Take(4).ToList(),
                Achievements = _mapper.Map<List<AchievementVM>>(achievements).ToList(),
                //EventsGalaries = _mapper.Map<List<EventGalaryVM>>(eventsGalaries).ToList(),
                OurValues = _mapper.Map<List<ValueHomeVM>>(ourValues).ToList(),
                //DownloadsTemplates = _mapper.Map<List<DownloadVM>>(downloadsTemplates).ToList(),
                DownloadsCategories = _mapper.Map<List<DownloadVM>>(downloadsCategories).ToList(),
                SomeFunFactorImages = _mapper.Map<List<SomeFunFactorImageVM>>(someFunFactorImages).OrderBy(d=>d.Order).ToList(),
            };

            var sectionTitles = _unitOfWork._titleRepo.GetAll().ToList(); 
            ViewBag.service = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("service")).FirstOrDefault());
            ViewBag.gallary = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("gallary")).FirstOrDefault());
            ViewBag.agent = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("agent")).FirstOrDefault());
            ViewBag.resources = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("resources")).FirstOrDefault());
            ViewBag.staff = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("staff")).FirstOrDefault());
            ViewBag.product = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("product")).FirstOrDefault()); 
            ViewBag.values = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("values")).FirstOrDefault()); 
            return View(model);
        }

        public IActionResult AboutUs()
        {
            var sectionTitles = _unitOfWork._titleRepo.GetAll().ToList(); 
            ViewBag.values = _mapper.Map<TitleVM>(sectionTitles.Where(d => d.SectionName.ToLower().Contains("values")).FirstOrDefault());
            var ourValues = _unitOfWork._valueHomeRepo.GetAll();
            ViewBag.OurValuesListVM = _mapper.Map<List<ValueHomeVM>>(ourValues).ToList();



            var aboutUS = _unitOfWork._aboutUsHomeService.GetAll().OrderBy(d => d.Order);
            var AboutUsLstVM = _mapper.Map<List<AboutUsHomeVM>>(aboutUS).ToList();
            return View(AboutUsLstVM);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CultureMangment(string culture , string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, 
                                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
            return LocalRedirect(returnUrl);
        }


        public IActionResult DownloadFile(int id)
        {
            var file = _unitOfWork._DownloadRepo.GetById(id);
            string filePath = _hostingEnvironment.WebRootPath + file.PdfPath;
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Return 404 Not Found if the file does not exist
            }
            var fileContent = System.IO.File.ReadAllBytes(filePath);
            string mimeType = "application/octet-stream";
            return File(fileContent, mimeType, Path.GetFileName(filePath));
        }




        [HttpPost]
        public async Task<IActionResult> LeaveMessage(CreateContactUsVM model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500, "Oops! An error occurred and your message could not be sent , Please fill all empty fields");
            }
            else
            {
                try
                {
                    var contactUs = _mapper.Map<ContactUs>(model); 
                    contactUs.IsSeen = false;
                    var result = await _unitOfWork._ContactUsRepo.InsertAsync(contactUs);
                    var checkSave = await _unitOfWork.CompleteAync();
                    if (checkSave > 0)
                    {
                        return Ok("Thank you for your message. We will get back to you soon!");
                    }
                    else
                    {
                        return StatusCode(500, "Oops! An error occurred and your message could not be sent.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Oops! An error occurred and your message could not be sent. as " + ex.Message);
                }
            }
        }
          
    }
}