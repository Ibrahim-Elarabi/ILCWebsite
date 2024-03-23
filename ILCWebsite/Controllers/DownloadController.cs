using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Downloads;
using ILC.BL.Models.Admin.HomeSection.Service;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public DownloadController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var documents = _unitOfWork._DownloadRepo.GetAll().ToList();
            var result = _mapper.Map<List<DownloadVM>>(documents);
            return View(result);
        }
        public ActionResult ViewFile(int id)
        {
            var download = _unitOfWork._DownloadRepo.GetById(id);
            var downloadVM = _mapper.Map<DownloadVM>(download);
            return View(downloadVM);
        }
    }
}
