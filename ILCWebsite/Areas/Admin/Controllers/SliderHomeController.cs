using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Slider;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderHomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        private readonly IUnitOfWork _unitOfWork;

        public SliderHomeController(IMapper mapper, IWebHostEnvironment host, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _host = host;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._sliderHomeService.GetAll();
            var newList = _mapper.Map<List<SliderHomeVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Details(int id)
        {
            var silder = _unitOfWork._sliderHomeService.FindOne(d => d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<SliderHomeVM>(silder);
            return View(result);
        }

        public IActionResult Create()
        {
            return View(new CreateSliderHomeVM());
        }
        [HttpPost]
        public async Task<JsonResult> Create(CreateSliderHomeVM model)
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
                            var result = await _unitOfWork._sliderHomeService.InsertAsync(_mapper.Map<SilderHomeSection>(model));
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
            var model = await _unitOfWork._sliderHomeService.GetByIdAsync(id);
            return View(_mapper.Map<EditSliderHomeVM>(model));
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditSliderHomeVM model)
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
                    _unitOfWork._sliderHomeService.Update(_mapper.Map<SilderHomeSection>(model));
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

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._sliderHomeService.GetById(id);
                if (model != null)
                {
                    _unitOfWork._sliderHomeService.Delete(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "item deleted successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to delete item"
                        });

                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No item found to remove"
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
    }
}
