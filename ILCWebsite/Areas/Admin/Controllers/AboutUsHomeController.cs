using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutUsHomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AboutUsHomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._aboutUsHomeService.GetAll();
            var newList = _mapper.Map<List<AboutUsVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Create(AboutUsVM model)
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
                            var result = await _unitOfWork._aboutUsHomeService.InsertAsync(_mapper.Map<AboutUsHomeSection>(model));
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
                                Message = "Invalid Image path to save image in it",
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
            var model = await _unitOfWork._aboutUsHomeService.GetByIdAsync(id);
            return View(_mapper.Map<AboutUsVM>(model));
        }
        [HttpPost]
        public async Task<JsonResult> Edit(AboutUsVM model)
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
                    _unitOfWork._aboutUsHomeService.Update(_mapper.Map<AboutUsHomeSection>(model));
                    var result = await _unitOfWork.CompleteAync();
                    if (result > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Item edit successfully"
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
