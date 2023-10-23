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
        public async Task<ILCResponse<AboutUsVM>> Create(AboutUsVM model)
        {
            ILCResponse<AboutUsVM> response = null;
            if (ModelState.IsValid)
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
                            if (checkSave == -1)
                            {
                                response = new ILCResponse<AboutUsVM>()
                                {
                                    Status = 400,
                                    Errors = new List<object>() { "Save Faild" }
                                };

                            }
                            else
                            {
                                response = new ILCResponse<AboutUsVM>()
                                {
                                    Status = 200,
                                    Errors = null
                                };
                            }
                        }
                        return response;
                    }
                    catch (Exception ex)
                    {
                        response = new ILCResponse<AboutUsVM>()
                        {
                            Status = 500,
                            Errors = new List<object>() { ex.Message }
                        };
                        return response;
                    }

                }

            }
            return response;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _unitOfWork._aboutUsHomeService.GetByIdAsync(id);
            return View(_mapper.Map<AboutUsVM>(model));
        }
        [HttpPost]
        public async Task<ILCResponse<AboutUsVM>> Edit(AboutUsVM model)
        {
            ILCResponse<AboutUsVM> response = null;
            try
            {
                ModelState.Remove("Image");
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin/Home");
                        model.ImagePath = imagePath;
                    }
                    _unitOfWork._aboutUsHomeService.Update(_mapper.Map<AboutUsHomeSection>(model));
                    var result = await _unitOfWork.CompleteAync();
                    if (result == -1)
                    {
                        response = new ILCResponse<AboutUsVM> { Status = 500, Errors = new List<object>() { "Faild To Save" } };
                    }
                    else
                    {
                        response = new ILCResponse<AboutUsVM>() { Status = 200, Errors = null };
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }
    }
}
