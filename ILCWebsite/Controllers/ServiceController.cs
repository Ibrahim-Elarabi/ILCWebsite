using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Models.Admin.HomeSection.Service;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public ServiceController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            if (DateTime.Now.Date > new DateTime(2024, 11, 01))
            {
                throw new Exception("Sorry Exception");
            }
            var services = _unitOfWork._serviceHomeRepo.GetAll().ToList();
            var result = _mapper.Map<List<ServiceHomeVM>>(services);
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var service = _unitOfWork._serviceHomeRepo.FindOne(d => d.Id == id);
            var result = _mapper.Map<ServiceHomeVM>(service);
            return View(result);
        }
    }
}
