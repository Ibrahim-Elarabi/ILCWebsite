using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.AboutUs;
using ILC.BL.Models.Admin.HomeSection.Achievements;
using ILC.BL.Models.Admin.HomeSection.Agent;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.Downloads;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Models.Admin.HomeSection.Service;
using ILC.BL.Models.Admin.HomeSection.Slider;
using ILC.BL.Models.Admin.HomeSection.Staff;
using ILC.BL.Models.WebSite.Home;
using ILC.Domain.DBEntities;
using ILCWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ILCWebsite.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var aboutUS = _unitOfWork._aboutUsHomeService.FindOne();
            var silders = _unitOfWork._sliderHomeService.GetAll();
            var service = _unitOfWork._serviceHomeRepo.GetAll();
            var products = _unitOfWork._productHomeRepo.FindAndJoin(prod => prod.IsAppearInHome == true && prod.IsDeleted != true).Take(3);
            var agents = _unitOfWork._agentHomeRepo.GetAll().Take(4);
            var blogs = _unitOfWork._blogHomeRepo.GetAll().Take(3);
            var staffs = _unitOfWork._staffHomeRepo.GetAll();
            var achievements = _unitOfWork._AchievementRepo.GetAll();
            var downloadsTemplates = _unitOfWork._DownloadRepo.GetAll().Where(d=>d.FileType == ILC.Domain.Enums.PdfTypesEnum.Template);
            var downloadsCategories = _unitOfWork._DownloadRepo.GetAll().Where(d=>d.FileType == ILC.Domain.Enums.PdfTypesEnum.Category);
            var model = new HomePageVM()
            {
                Silder = _mapper.Map<List<SliderHomeVM>>(silders).ToList(),
                AboutUS = _mapper.Map<AboutUsHomeVM>(aboutUS),
                Services = _mapper.Map<List<ServiceHomeVM>>(service).Take(6).ToList(),
                Products = _mapper.Map<List<ProductHomeVM>>(products),
                Agents = _mapper.Map<List<AgentHomeVM>>(agents).Take(4).ToList(),
                Blogs = _mapper.Map<List<BlogHomeVM>>(blogs).Take(3).ToList(),
                Staffs = _mapper.Map<List<StaffHomeVM>>(staffs).Take(4).ToList(),
                Achievements = _mapper.Map<List<AchievementVM>>(achievements).Take(4).ToList(),
                DownloadsTemplates = _mapper.Map<List<DownloadVM>>(downloadsTemplates).ToList(),
                DownloadsCategories = _mapper.Map<List<DownloadVM>>(downloadsCategories).ToList()
            };
            return View(model);
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
    }
}