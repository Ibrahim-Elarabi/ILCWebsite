using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection;
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
            var newList = _mapper.Map<List<SilderVM>>(lst);
            return View(newList.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ILCResponse<SilderVM>> Create(SilderVM model)
        {
            ILCResponse<SilderVM> response = null;
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
                            var result = await _unitOfWork._sliderHomeService.InsertAsync(_mapper.Map<SilderHomeSection>(model));
                            var checkSave = await _unitOfWork.CompleteAync();
                            if (checkSave == -1)
                            {
                                response = new ILCResponse<SilderVM>()
                                {
                                    Status = 400,
                                    Errors = new List<object>() { "Save Faild" }
                                };

                            }
                            else
                            {
                                response = new ILCResponse<SilderVM>()
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
                        response = new ILCResponse<SilderVM>()
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
            var model = await _unitOfWork._sliderHomeService.GetByIdAsync(id);
            return View(_mapper.Map<SilderVM>(model));
        }
        [HttpPost]
        public async Task<ILCResponse<SilderVM>> Edit(SilderVM model)
        {
            ILCResponse<SilderVM> response = null;
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
                    _unitOfWork._sliderHomeService.Update(_mapper.Map<SilderHomeSection>(model));
                    var result = await _unitOfWork.CompleteAync();
                    if (result == -1)
                    {
                        response = new ILCResponse<SilderVM> { Status = 500, Errors = new List<object>() { "Faild To Save" } };
                    }
                    else
                    {
                        response = new ILCResponse<SilderVM>() { Status = 200, Errors = null };
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
