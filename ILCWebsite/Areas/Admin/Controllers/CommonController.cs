using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.Services;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Drawing2D;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public CommonController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        } 
        public JsonResult GetAllCategories()
        {
            List<Category> lst = _unitOfWork._categoryRepo.GetAll().ToList();
            var result = _mapper.Map<List<CategoryVM>>(lst); 
            return Json(result); 
        }
        public JsonResult GetAllServices()
        {
            List<Service> lst = _unitOfWork._serviceRepo.GetAll().ToList();
            var result = _mapper.Map<List<ServiceVM>>(lst); 
            return Json(result); 
        }
    }
}
