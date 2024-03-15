using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Inquirys;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc; 

namespace ILCWebsite.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InquiryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView(new CreateInquiryVM()); 
        }


        [HttpPost]
        public async Task<JsonResult> Create(CreateInquiryVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            {
                try
                {
                    var result = await _unitOfWork._inquiryRepo.InsertAsync(_mapper.Map<Inquiry>(model));
                    var checkSave = await _unitOfWork.CompleteAync();
                    if (checkSave > 0)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Inquiry created successfully"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Failed to create Inquiry",
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
    }
}
