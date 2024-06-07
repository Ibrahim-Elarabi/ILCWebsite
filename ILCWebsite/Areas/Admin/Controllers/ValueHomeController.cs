using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.ValuesHome;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ValueHomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public ValueHomeController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._valueHomeRepo.GetAll();
            var newList = _mapper.Map<List<ValueHomeVM>>(lst);
            return View(newList.ToList());
        } 

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateValueHomeVM());
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateValueHomeVM model)
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
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin");
                        if (imagePath != null)
                        {
                            model.ImagePath = imagePath; 
                            var result = await _unitOfWork._valueHomeRepo.InsertAsync(_mapper.Map<ValueHome>(model));
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
            var model = await _unitOfWork._valueHomeRepo.GetByIdAsync(id); 
            return View(_mapper.Map<EditValueHomeVM>(model)); 
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditValueHomeVM model)
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
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/ValuesHome");
                        model.ImagePath = imagePath;
                    }
                    _unitOfWork._valueHomeRepo.Update(_mapper.Map<ValueHome>(model), e => e.CreationDate, e => e.CreatedById);
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


        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._valueHomeRepo.GetById(id);
                if (model != null) {
                    _unitOfWork._valueHomeRepo.Delete(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Item deleted successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to delete item , Please try again later"
                        });

                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "No values found to remove"
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
