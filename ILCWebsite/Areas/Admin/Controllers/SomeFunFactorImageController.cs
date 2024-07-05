using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Achievements;
using ILC.BL.Models.Admin.HomeSection.SomeFunFactorImages;
using ILC.BL.Models.Admin.HomeSection.Staff;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SomeFunFactorImageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SomeFunFactorImageController(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._someFunFactoImageRepo.GetAll().OrderByDescending(d => d.CreationDate);
            var newList = _mapper.Map<List<SomeFunFactorImageVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Details(int id)
        {
            var model = _unitOfWork._someFunFactoImageRepo.FindOne(d => d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<SomeFunFactorImageVM>(model);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateSomeFunFactorImageVM());
        }

         

        [HttpPost]
        public async Task<JsonResult> Create(CreateSomeFunFactorImageVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            {
                try
                {
                    var OldElementsCount = _unitOfWork._someFunFactoImageRepo.GetAll().Count();
                    if (OldElementsCount < 9)
                    {
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/SomeFunFactoImages");
                        if (imagePath != null)
                        {
                            model.ImagePath = imagePath;
                            var result = await _unitOfWork._someFunFactoImageRepo.InsertAsync(_mapper.Map<SomeFunFactorImage>(model));
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
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Max number of Images is (9) elements",
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




        public async Task<IActionResult> Edit(int id)
        {
            var model = await _unitOfWork._someFunFactoImageRepo.GetByIdAsync(id);
            return View(_mapper.Map<EditSomeFunFactorImageVM>(model));
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditSomeFunFactorImageVM model)
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
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/SomeFunFactorImages");
                        model.ImagePath = imagePath;
                    }
                    _unitOfWork._someFunFactoImageRepo.Update(_mapper.Map<SomeFunFactorImage>(model), e => e.CreationDate, e => e.CreatedById);
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
                var model = _unitOfWork._someFunFactoImageRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._someFunFactoImageRepo.Delete(model);
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
