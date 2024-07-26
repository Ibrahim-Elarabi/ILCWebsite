using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Inquirys;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        public IActionResult Index(int? categoryId, int page = 1)
        {
            int pageSize = 8; 
            try
            {
                var subCategoriesList = _unitOfWork._categoryRepo.Find(d => d.ParentCategoryId == categoryId).ToList();

                if (subCategoriesList?.Count() > 0)
                {
                    var mainCategory = _unitOfWork._categoryRepo.FindOne(d => d.Id == categoryId);
                    List<SubCategoryWithProducts> result = new List<SubCategoryWithProducts>();
                    List<CategoryVM> subCategoriesListVM = _mapper.Map<List<CategoryVM>>(subCategoriesList);
                    foreach (var item in subCategoriesListVM)
                    {
                        var products = _unitOfWork._productHomeRepo.Find(d => d.CategoryId == item.Id)
                                                                    .Include(d=>d.Category)
                                                                    .ThenInclude(d=>d.ParentCategory)
                                                                    .Where(d=>d.IsAppearInHome == true);
                        List<ProductHomeVM> productsVM = _mapper.Map<List<ProductHomeVM>>(products);

                        SubCategoryWithProducts subCategoryWithProducts = new SubCategoryWithProducts()
                        {
                            SubCategory = item,
                            ProductList = productsVM
                        };
                        result.Add(subCategoryWithProducts);
                          
                        ViewBag.MainCategoryNameEn = mainCategory?.NameEn;
                        ViewBag.MainCategoryNameAr = mainCategory?.NameAr;
                    }
                    return View("SubCategoryWithProducts", result);
                }
                else
                {
                    var subCategory = _unitOfWork._categoryRepo.Find(d => d.Id == categoryId).FirstOrDefault(); ;
                    var mainCategory = _unitOfWork._categoryRepo.FindOne(d => d.Id == subCategory.ParentCategoryId);
                    var query = _unitOfWork._productHomeRepo.Find(p => p.CategoryId == categoryId)
                                                        .Include(d => d.Category)
                                                        .ThenInclude(d => d.ParentCategory)
                                                        .ToList();   
                    var totalProducts = query.Count();
                    var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
                    var lst = query.Skip(((page - 1) * pageSize))
                                    .Take(pageSize);
                    var result = new ProductListViewModel
                    {
                        Products = _mapper.Map<List<ProductHomeVM>>(lst),
                        CurrentPage = page,
                        TotalPages = totalPages
                    };  
                    ViewBag.SubCategoryNameEn = subCategory?.NameEn;
                    ViewBag.SubCategoryNameAr = subCategory?.NameAr;
                    ViewBag.MainCategoryNameEn = mainCategory?.NameEn;
                    ViewBag.MainCategoryNameAr = mainCategory?.NameAr; 
                    ViewBag.MainCategoryId = mainCategory?.Id;  
                    return View(result);
                }
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

             product?.Images.Insert(0, new ProductImage() { DisplayOrder = 0, ProductId = product.Id, ImagePath = product?.ImagePath }); 
            var similarProductsIds = _unitOfWork._similarProductRepo
                                    .Find(d => d.ProductId == id)
                                    .Select(d => d.SimilarProductId)
                                    .ToList();

            var similarProducts = _unitOfWork._productHomeRepo
                   .Find(d => similarProductsIds.Contains(d.Id))
                   .Include(p => p.Images)
                   .ToList(); 
            var similarProductsVM = _mapper.Map<List<ProductHomeVM>>(similarProducts);
            if (product?.Category?.ParentCategory == null)
            {
                ViewBag.ProductMainCategoryEn = product?.Category?.NameEn;
                ViewBag.ProductMainCategoryAr = product?.Category?.NameAr;
                ViewBag.MainCategoryId = product?.Category?.Id;
            }
            else
            { 
                ViewBag.ProductSubCategoryEn = product?.Category.NameEn;
                ViewBag.ProductSubCategoryAr = product?.Category.NameAr;
                ViewBag.SubCategoryId = product?.Category?.Id;

                ViewBag.ProductMainCategoryEn = product?.Category?.ParentCategory?.NameEn;
                ViewBag.ProductMainCategoryAr = product?.Category?.ParentCategory?.NameAr;
                ViewBag.MainCategoryId = product?.Category?.ParentCategory?.Id;
            }

            var result = _mapper.Map<ProductHomeVM>(product);
            if (result != null)
            {
                result.SimilarProducts = similarProductsVM; 
            }

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
