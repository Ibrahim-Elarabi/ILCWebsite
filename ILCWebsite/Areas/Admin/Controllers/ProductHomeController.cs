using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models;
using ILC.BL.Models.Admin.HomeSection;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductHomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductHomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductHomeSectionModel());
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateProductHomeSectionModel model)
        { 
            if (!ModelState.IsValid)
            {
                return Json(model);
            }else{ 
                try
                {
                    var uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "ProductHomeSection_Images");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.Image?.FileName;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model?.Image?.CopyTo(fileStream);
                    }

                    ProductHomeSection newObj = new ProductHomeSection()
                    {
                        TitleEn = model?.TitleEn,
                        TitleAr = model?.TitleAr,
                        DescriptionEn = model?.DescriptionEn,
                        DescriptionAr = model?.DescriptionAr,
                        Image = filePath.Substring(filePath.IndexOf("wwwroot"))
                    };
                    await _unitOfWork._productHomeSectionRepo.InsertAsync(newObj);
                    if (_unitOfWork.Complete() > 0)
                    {

                        return Json(new
                        {
                            Success = true,
                            Message = "Product added successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to add product",
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
