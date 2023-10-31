using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.AboutUs;
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
            var newList = _mapper.Map<List<AboutUsHomeVM>>(lst);
            return View(newList.ToList());
        }


        public IActionResult Details(int id)
        {
            var aboutUsHome = _unitOfWork._aboutUsHomeService.FindOne(d => d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<AboutUsHomeVM>(aboutUsHome);
            return View(result);
        }

        public IActionResult Create()
        {
            return View(new CreateAboutUsHomeVM());
        }
        [HttpPost]
        public async Task<JsonResult> Create(CreateAboutUsHomeVM model)
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
            var model = await _unitOfWork._aboutUsHomeService.GetByIdAsync(id);
            return View(_mapper.Map<EditAboutUsHomeVM>(model));
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditAboutUsHomeVM model)
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

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._aboutUsHomeService.GetById(id);
                if (model != null)
                {
                    _unitOfWork._aboutUsHomeService.Delete(model);
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
