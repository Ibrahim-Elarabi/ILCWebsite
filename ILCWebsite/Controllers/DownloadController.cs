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
            var downloadsTemplates = _unitOfWork._DownloadRepo
                                   .GetAll()
                                   .Where(d => d.AppearInHome == true && d.FileType == ILC.Domain.Enums.PdfTypesEnum.Template)
                                   .ToList();

            var downloadsCategories = _unitOfWork._DownloadRepo
                                    .GetAll()
                                    .Where(d => d.AppearInHome == true && d.FileType == ILC.Domain.Enums.PdfTypesEnum.Category)
                                    .ToList();

            var DownloadsTemplates = _mapper.Map<List<DownloadVM>>(downloadsTemplates).ToList();
            ViewBag.DownloadsTemplates = DownloadsTemplates;

            var DownloadsCategories = _mapper.Map<List<DownloadVM>>(downloadsCategories).ToList();
            return View(DownloadsCategories);

        }
        public ActionResult ViewFile(int id)
        {
            var download = _unitOfWork._DownloadRepo.GetById(id);
            var downloadVM = _mapper.Map<DownloadVM>(download);
            return View(downloadVM);
        }
    }
}
