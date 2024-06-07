using AutoMapper; 
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Titles; 
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TitleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public TitleController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._titleRepo.GetAll();
            var newList = _mapper.Map<List<TitleVM>>(lst);
            return View(newList.ToList());
        }
          

        public async Task<IActionResult> Edit(int id)
        { 
            var model = await _unitOfWork._titleRepo.GetByIdAsync(id); 
            return View(_mapper.Map<EditTitleVM>(model)); 
        }
        [HttpPost]
        public async Task<JsonResult> Edit(EditTitleVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                { 
                    _unitOfWork._titleRepo.Update(_mapper.Map<Title>(model), e => e.SectionName, e => e.CreationDate, e => e.CreatedById);
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
         
    }
}
