using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ILCWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index(int? categoryId = null)
        {
            List<ProductHome>lst = new List<ProductHome>();   
            try
            {
                if (categoryId == null)
                {
                    lst = _unitOfWork._productHomeRepo.GetAll().ToList();
                }
                else
                {
                    var catIds = GetCategoryAndSubcategories(categoryId).Select(d => d.Id).ToList();
                    lst = _unitOfWork._productHomeRepo.Find(p => catIds.Contains(p.CategoryId.GetValueOrDefault())).ToList(); 
                } 
                var newList = _mapper.Map<List<ProductHomeVM>>(lst);
                return View(newList.ToList());
            }
            catch (Exception ex)
            {
                return View(new List<ProductHomeVM>());
            } 
        }
        public IActionResult Details(int id)
        {
            var product = _unitOfWork._productHomeRepo
                            .Find(d => d.Id == id)
                            .Include(p => p.Images)
                            .Include(p => p.Specifications)
                            .FirstOrDefault();
            var productVM = _mapper.Map<ProductHomeVM>(product);
            return View(productVM);
        }

        public IEnumerable<Category> GetCategoryAndSubcategories(int? categoryId)
        { 
            List<Category> allCategories = _unitOfWork._categoryRepo.GetAll().ToList();
              
            var rootCategory = allCategories.FirstOrDefault(c => c.Id == categoryId);

            if (rootCategory == null)
            { 
                return Enumerable.Empty<Category>();
            }

            var result = GetCategoryAndChildrenRecursive(allCategories, rootCategory);
            return result;
        }

        static IEnumerable<Category> GetCategoryAndChildrenRecursive(List<Category> allCategories, Category category)
        {
            yield return category;

            var childCategories = allCategories.Where(c => c.ParentCategoryId == category.Id);
            foreach (var childCategory in childCategories)
            {
                foreach (var subChild in GetCategoryAndChildrenRecursive(allCategories, childCategory))
                {
                    yield return subChild;
                }
            }
        }
         
    }
}
