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
                    Name = "Categories",
                    Count = _unitOfWork._categoryRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                     Name = "Services",
                    Count = _unitOfWork._serviceHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Products",
                    Count = _unitOfWork._productHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Agents",
                    Count = _unitOfWork._agentHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Blogs",
                    Count = _unitOfWork._blogHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Staffs",
                    Count = _unitOfWork._staffHomeRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Achievements",
                    Count = _unitOfWork._AchievementRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Documents",
                    Count = _unitOfWork._DownloadRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Inquires",
                    Count = _unitOfWork._inquiryRepo.GetAll().Count()
                },
                new HomeAdminVM()
                {
                    Name = "Mails",
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
