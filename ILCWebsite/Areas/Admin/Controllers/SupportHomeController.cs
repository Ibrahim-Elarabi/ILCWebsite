using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.Support;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SupportHomeController : Controller 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public SupportHomeController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lst = _unitOfWork._supportHomeRepo.GetAll();
            var newList = _mapper.Map<List<SupportHomeVM>>(lst);
            return View(newList.ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var support = _unitOfWork._supportHomeRepo.FindOne(d=>d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<SupportHomeVM>(support);
            return View(result);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateSupportHomeVM());
        }



        [HttpPost]
        public async Task<JsonResult> Create(CreateSupportHomeVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            { 
                try
                {  
                    var result = await _unitOfWork._supportHomeRepo.InsertAsync(_mapper.Map<SupportHome>(model));
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
            var model = await _unitOfWork._supportHomeRepo.GetByIdAsync(id); 
            return View(_mapper.Map<EditSupportHomeVM>(model)); 
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditSupportHomeVM model)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                { 
                    _unitOfWork._supportHomeRepo.Update(_mapper.Map<SupportHome>(model));
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
                var model = _unitOfWork._supportHomeRepo.GetById(id);
                if (model != null) {
                    _unitOfWork._supportHomeRepo.Delete(model);
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
