using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.Common;
using ILC.BL.Models.Admin.HomeSection.Blog; 
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using static System.Collections.Specialized.BitVector32;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")] 
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
            List<Category> lst = _unitOfWork._categoryRepo.GetAll().Where(d=>d.ParentCategoryId == null).ToList();
            var result = _mapper.Map<List<CategoryVM>>(lst); 
            return Json(result); 
        }

        public JsonResult GetCountries()
        {
            List<Country> lst = _unitOfWork._countryRepo.GetAll().ToList();
            var result = _mapper.Map<List<CountryVM>>(lst);
            return Json(result);
        }
        public JsonResult GetCities(int CountryId)
        {
            List<City> lst = _unitOfWork._cityRepo.Find(d=>d.CountryId == CountryId).ToList();
            var result = _mapper.Map<List<CityVM>>(lst);
            return Json(result);
        }
    }
}


