using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.Service;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public BlogController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var blogs = _unitOfWork._blogHomeRepo.GetAll().ToList();
            var result = _mapper.Map<List<BlogHomeVM>>(blogs);
            return View(result);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
