using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Downloads;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DownloadController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public DownloadController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._DownloadRepo.GetAll();
            var newList = _mapper.Map<List<DownloadVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Details(int id)
        {
            var download = _unitOfWork._DownloadRepo.FindOne(d=>d.Id == id && d.IsDeleted != true);
            var result = _mapper.Map<DownloadVM>(download);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateDownloadVM());
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateDownloadVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            {
                if (model.Pdf != null)
                {
                    try
                    {
                        var pdfPath = _unitOfWork.UploadedFile(model.Pdf, "Admin/Files/Home");
                        if (pdfPath != null)
                        {
                            model.PdfPath = pdfPath; 
                            var result = await _unitOfWork._DownloadRepo.InsertAsync(_mapper.Map<Download>(model));
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
                                Message = "Invalid file path to save image in it",
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
            var model = await _unitOfWork._DownloadRepo.GetByIdAsync(id); 
            return View(_mapper.Map<EditDownloadVM>(model)); 
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditDownloadVM model)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                {
                    if (model.Pdf != null)
                    {
                        var pdfPath = _unitOfWork.UploadedFile(model.Pdf, "Admin/Files/Home");
                        model.PdfPath = pdfPath;
                    }
                    var download = _mapper.Map<Download>(model);
                    _unitOfWork._DownloadRepo.Update(download, e => e.CreationDate, e => e.CreatedById);
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
                var model = _unitOfWork._DownloadRepo.GetById(id);
                if (model != null) 
                {
                    _unitOfWork._DownloadRepo.Delete(model);
                    if (_unitOfWork.Complete() > 0)
                    {
                        //TODO: Remove file from folder
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


        public ActionResult ViewFile(int id)
        {
            var download = _unitOfWork._DownloadRepo.GetById(id);
            var downloadVM = _mapper.Map<DownloadVM>(download);
            return View(downloadVM);
        }

    }
}
