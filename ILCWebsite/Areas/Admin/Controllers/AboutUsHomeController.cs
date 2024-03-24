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
            var aboutUs = _unitOfWork._aboutUsHomeService.GetAll().FirstOrDefault();
            var result = _mapper.Map<AboutUsHomeVM>(aboutUs);
            return View(result);
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
                        var imagePath = _unitOfWork.UploadedFile(model.Image, "Images/Admin");
                        model.ImagePath = imagePath;
                    }
                    _unitOfWork._aboutUsHomeService.Update(_mapper.Map<AboutUsHomeSection>(model), e => e.CreationDate, e => e.CreatedById);
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
