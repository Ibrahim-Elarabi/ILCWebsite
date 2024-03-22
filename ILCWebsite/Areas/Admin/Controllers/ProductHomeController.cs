using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductHomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public ProductHomeController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var lst = _unitOfWork._productHomeRepo.GetAll();
                var newList = _mapper.Map<List<ProductHomeVM>>(lst);
                return View(newList.ToList());
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var productHome = _unitOfWork._productHomeRepo.FindOne(d => d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<ProductHomeVM>(productHome);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategory();
            return View(new CreateProductHomeVM());
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateProductHomeVM model, List<IFormFile> OtherImages)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                { 
                    ProductHome product = _mapper.Map<ProductHome>(model);
                    ////adding main image
                    if (model.Image != null)
                    {
                        product.ImagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Home");
                    }
                    ////adding list of images
                    for (int i = 0; i < OtherImages?.Count; i++)
                    {
                        var otherImagePath = _unitOfWork.UploadedFile(OtherImages[i], "Images/Admin/Home");
                        product.Images.Add(new ProductImage() { ImagePath = otherImagePath, DisplayOrder = i + 1 });
                    }
                    ////adding similar product list  
                    List<ProductSimilar> similarProducts = new List<ProductSimilar>();
                    foreach (var item in model.SimilarProductsId)
                    {
                        var similarSelectedProduct = _unitOfWork._productHomeRepo.FindOne(d => d.Id == item);
                        ProductSimilar newSimilarProduct = new ProductSimilar()
                        {
                            Product = product,
                            SimilarProductId = similarSelectedProduct.Id
                        };
                        similarProducts.Add(newSimilarProduct);
                    };
                    product.SimilarProducts = similarProducts;

                    //saving in DB
                    var result = await _unitOfWork._productHomeRepo.InsertAsync(_mapper.Map<ProductHome>(product));
                    var checkSave = await _unitOfWork.CompleteAync();
                    if (checkSave > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Item added successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to add item",
                        });
                    }
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

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategory();

            List<ProductHome> lst = _unitOfWork._productHomeRepo.GetAll().ToList();
            var allProducts = _mapper.Map<List<ProductHomeVM>>(lst);
            ViewBag.AllProducts = allProducts;


           var model = _unitOfWork._productHomeRepo.FindOne(e => e.Id == id && e.IsDeleted != true, false, true, e => e.Images, r => r.Specifications); //GetByIdAsync(id); 
            var similarProducrtsIds = _unitOfWork._similarProductRepo.Find(d => d.ProductId == id).Select(d => d.SimilarProductId).ToList();
            var result = _mapper.Map<EditProductHomeVM>(model);
            result.SimilarProductsId = similarProducrtsIds;
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditProductHomeVM model, List<IFormFile> OtherImages)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                { 
                    var product = await _unitOfWork._productHomeRepo.FindAndJoin(prod => prod.Id == model.Id, true, e => e.Images, p => p.Specifications)?.FirstOrDefaultAsync();
                    if (product != null)
                    {
                        #region Manual product mapping
                        product.TitleAr = model.TitleAr;
                        product.TitleEn = model.TitleEn;
                        product.DescriptionAr = model.DescriptionAr;
                        product.DescriptionEn = model.DescriptionEn;
                        product.CategoryId = model.CategoryId;
                        product.IsAppearInHome = model.IsAppearInHome; 
                        if (model.Image != null)
                        {
                            product.ImagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Home"); 
                        }
                        #endregion

                        if (model.Specifications != null && model.Specifications.Any())
                        {
                            product?.Specifications.AddRange(_mapper.Map<List<ProductSpecification>>(model.Specifications));
                        }
                        for (int i = 0; i < OtherImages.Count; i++)
                        {
                            var otherImagePath = _unitOfWork.UploadedFile(OtherImages[i], "Images/Admin/Home");
                            product?.Images.Add(new ProductImage() { ImagePath = otherImagePath, DisplayOrder = i + 1 });
                        }
                        _unitOfWork._productHomeRepo.Update(product, e => e.CreationDate, e => e.CreatedById);
                        var result = await _unitOfWork.CompleteAync();
                        if (result > 0)
                        {
                            return Json(new
                            {
                                Success = true,
                                Message = "Item edited successfully"
                            });
                        }
                        else
                        {
                            return Json(new
                            {
                                Success = false,
                                Message = "Failed to edit item",
                            });
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "No product found to edit",
                        });
                    } 
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


        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._productHomeRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._productHomeRepo.Delete(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Product deleted successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to delete product"
                        });

                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No product found to remove"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Message = "An error occured , Please try again later," + ex.Message
                });
            }
        }

        #region Images
        public IActionResult ListImage(int id)
        {
            return View(new ProductImageVM() { ProductId = id });
        }
        public IActionResult _ImageList(int id)
        {
            var lst = _unitOfWork._ProductImageRepo.FindAndJoin(prodImg => prodImg.ProductId == id && prodImg.IsDeleted != true);
            var newList = _mapper.Map<List<ProductImageVM>>(lst);
            return PartialView(newList);
        }
        [HttpPost]
        public async Task<JsonResult> AddProductImage(ProductImageVM model)
        {
            if (model.Image != null)
            {
                try
                {
                    var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Product");
                    if (imagePath != null)
                    {
                        model.ImagePath = imagePath;
                        var result = await _unitOfWork._ProductImageRepo.InsertAsync(_mapper.Map<ProductImage>(model));
                        var checkSave = await _unitOfWork.CompleteAync();
                        if (checkSave > 0)
                        {
                            return Json(new
                            {
                                Success = true,
                                Message = "Item added successfully"
                            });
                        }
                        else
                        {
                            return Json(new
                            {
                                Success = false,
                                Message = "Failed to add item",
                            });
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Invalid ImagePath path to save image in it",
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
            else
            {
                return Json(new
                {
                    Success = false,
                    Message = "Empty image"
                });
            }
        }

        [HttpGet]
        public JsonResult DeleteImage(int id)
        {
            try
            {
                var model = _unitOfWork._ProductImageRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._ProductImageRepo.removeFromDatabase(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Product Image deleted successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to delete product Image"
                        });

                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No product Image found to remove"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Message = "An error occured , Please try again later," + ex.Message
                });
            }
        }
        [HttpGet]
        public JsonResult DeleteProp(int id)
        {
            try
            {
                var model = _unitOfWork._ProductSpecificationRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._ProductSpecificationRepo.removeFromDatabase(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Product Specification deleted successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to delete product Specification"
                        });

                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No product Specification found to remove"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Message = "An error occured , Please try again later," + ex.Message
                });
            }
        }
        #endregion

        #region Private Function 
        private List<CategoryVM> GetCategory()
        {
            var lst = _unitOfWork._categoryRepo.FindAndJoin(c => c.ParentCategoryId != null);
            var newList = _mapper.Map<List<CategoryVM>>(lst);
            return newList;
        }
        #endregion
    }
}
