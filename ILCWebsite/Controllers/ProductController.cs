using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Inquirys;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Repo;
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
        public IActionResult Index(int? categoryId)
        { 
            List<ProductHome>lst = new List<ProductHome>();   
            try
            {
                var subCategoriesList = _unitOfWork._categoryRepo.Find(d => d.ParentCategoryId == categoryId).ToList();

                var MainCategory = _unitOfWork._categoryRepo.FindOne(d => d.Id == categoryId);
                ViewBag.MainCategoryNameEn = MainCategory?.NameEn;
                ViewBag.MainCategoryNameAr = MainCategory?.NameAr;
                if (subCategoriesList?.Count() > 0)
                { 
                    List<SubCategoryWithProducts> result = new List<SubCategoryWithProducts>();
                    List<CategoryVM> subCategoriesListVM = _mapper.Map<List<CategoryVM>>(subCategoriesList);
                    foreach (var item in subCategoriesListVM)
                    {
                        var products = _unitOfWork._productHomeRepo.Find(d => d.CategoryId == item.Id);
                        List<ProductHomeVM> productsVM = _mapper.Map<List<ProductHomeVM>>(products);

                        SubCategoryWithProducts subCategoryWithProducts = new SubCategoryWithProducts()
                        {
                            SubCategory = item,
                            ProductList = productsVM
                        };
                        result.Add(subCategoryWithProducts);
                    }
                    return View("SubCategoryWithProducts", result);
                }
                else
                {
                    lst = _unitOfWork._productHomeRepo.Find(p => p.CategoryId == categoryId)
                                                        .Include(d=>d.Category) 
                                                        .ToList(); 
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
                   .Include(p => p.Category)
                   .ThenInclude(p => p.ParentCategory)
                   .FirstOrDefault(); 

            var similarProductsIds = _unitOfWork._similarProductRepo
                                    .Find(d => d.ProductId == id)
                                    .Select(d => d.SimilarProductId)
                                    .ToList();

            var similarProducts = _unitOfWork._productHomeRepo
                   .Find(d => similarProductsIds.Contains(d.Id))
                   .Include(p => p.Images)
                   .ToList(); 
            var similarProductsVM = _mapper.Map<List<ProductHomeVM>>(similarProducts);

            ViewBag.ProductSubCategoryEn = product?.Category.NameEn;
            ViewBag.ProductSubCategoryAr = product?.Category.NameAr;
            ViewBag.ProductCategoryEn = product?.Category?.ParentCategory?.NameEn;
            ViewBag.ProductCategoryAr = product?.Category?.ParentCategory?.NameAr;

            var result = _mapper.Map<ProductHomeVM>(product);
            result.SimilarProducts = similarProductsVM;
             
            return View(result);
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateInquiryVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            {
                try
                {
                    var result = await _unitOfWork._inquiryRepo.InsertAsync(_mapper.Map<Inquiry>(model));
                    var checkSave = await _unitOfWork.CompleteAync();
                    if (checkSave > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Inquiry created successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to create Inquiry",
                        });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = ex.Message,
                    });
                }
            }
        }
    }
}
