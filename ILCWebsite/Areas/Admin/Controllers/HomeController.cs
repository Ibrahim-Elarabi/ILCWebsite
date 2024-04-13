using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<HomeAdminVM> lst = new List<HomeAdminVM>()
            {
                new HomeAdminVM()
                {
                    Name = "CATEGORIES",
                    Icon = "fa-box",
                    Count = _unitOfWork._categoryRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                     Name = "SERVICES",
                    Icon = "fa-handshake",
                    Count = _unitOfWork._serviceHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "PRODUCTS",
                    Icon = "fa-box",
                    Count = _unitOfWork._productHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "AGENTS",
                    Icon = "fa-user",
                    Count = _unitOfWork._agentHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "BLOGS",
                    Icon = "fa-book",
                    Count = _unitOfWork._blogHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "STAFFS",
                    Icon = "fa-users",
                    Count = _unitOfWork._staffHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "ACHIEVEMENTS",
                    Icon = "fa-trophy",
                    Count = _unitOfWork._AchievementRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "DOCUMENTS",
                    Icon = "fa-file-alt",
                    Count = _unitOfWork._DownloadRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "INQUIRES",
                    Icon = "fa-envelope",
                    Count = _unitOfWork._inquiryRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "MAILS",
                    Icon = "fa-headset",
                    Count = _unitOfWork._ContactUsRepo.GetAll().Count()
                },
            };         
            return View(lst);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
