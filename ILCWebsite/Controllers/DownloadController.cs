using AutoMapper;
using ILC.BL.IRepo;
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

    }
}
