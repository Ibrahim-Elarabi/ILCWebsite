using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
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
            var lst = _unitOfWork._productHomeRepo.GetAll();
            var newList = _mapper.Map<List<ProductHomeVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Details(int id)
        {
            var productHome = _unitOfWork._productHomeRepo.FindOne(d=>d.Id == id);
            var result = _mapper.Map<ProductHomeVM>(productHome);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductHomeVM());
        }


        [HttpPost]
        public async Task<JsonResult> Create(ProductHomeVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            {
                if (model.Image != null)
                {
                    try
                    {
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Home");
                        if (imagePath != null)
                        {
                            model.ImagePath = imagePath;
                            var result = await _unitOfWork._productHomeRepo.InsertAsync(_mapper.Map<ProductHome>(model));
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
        }



        public async Task<IActionResult> Edit(int id)
        { 
            var model = await _unitOfWork._productHomeRepo.GetByIdAsync(id); 
            return View(_mapper.Map<ProductHomeVM>(model)); 
        }
        [HttpPost]
        public async Task<JsonResult> Edit(ProductHomeVM model)
        {
            try
            {
                ModelState.Remove("Image");
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                {
                    if (model.Image != null)
                    {
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Home");
                        model.ImagePath = imagePath;
                    }
                    _unitOfWork._productHomeRepo.Update(_mapper.Map<ProductHome>(model));
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
