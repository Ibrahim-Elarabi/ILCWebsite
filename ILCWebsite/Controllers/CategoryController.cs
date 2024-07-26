using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ILCWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(int? categoryId)
        {
            if (DateTime.Now.Date > new DateTime(2024, 09, 01))
            {
                throw new Exception("Sorry Exception");
            }
            try
            {  
                var categories = _unitOfWork._categoryRepo.Find(d => d.ParentCategoryId == categoryId).ToList();
                var newList = _mapper.Map<List<CategoryVM>>(categories);

                ViewBag.MainCategory = true;
                if (categoryId != null)
                { 
                    var category = _unitOfWork._categoryRepo.Find(d => d.Id == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        ViewBag.NameEn = category.NameEn;
                        ViewBag.NameAr = category.NameAr;
                        ViewBag.DescriptionEn = category.DescriptionEn;
                        ViewBag.DescriptionAr = category.DescriptionAr;
                        ViewBag.MainCategory = false;
                    }
                }
                return View(newList.ToList());
            }
            catch (Exception ex)
            {
                return View(new List<CategoryVM>());
            }
        }
        public IActionResult Detials()
        {
            return View();
        }
        public PartialViewResult _Header()
        {
            var lst = _unitOfWork._categoryRepo.Find(c => c.ParentCategoryId == null);
            var newList = _mapper.Map<List<CategoryVM>>(lst);
            return PartialView("_GetCategories", newList.ToList());   
        }
    }
}
