using AutoMapper;
using ILC.BL.IRepo;  
using ILC.BL.Models.Admin.HomeSection.Staff;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class StaffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public StaffController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var staffs = _unitOfWork._staffHomeRepo.GetAll().OrderBy(d => d.Order).ToList();
            var result = _mapper.Map<List<StaffHomeVM>>(staffs);
            return View(result);
        } 
    }
}
