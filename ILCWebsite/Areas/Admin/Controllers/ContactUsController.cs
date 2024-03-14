using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.CustomerSupport;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        public ContactUsController(IUnitOfWork unitOfWork, 
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._ContactUsRepo.GetAll().OrderByDescending(d=>d.CreationDate);
            var newList = _mapper.Map<List<ContactUsVM>>(lst);
            return View(newList.ToList());
        }

        public IActionResult Details(int id)
        { 
            var model = _unitOfWork._ContactUsRepo.FindOne(d=>d.Id == id && d.IsDeleted != true);
            if (model != null && model?.IsSeen != true)
            {
                model.IsSeen = true;
                _unitOfWork._ContactUsRepo.Update(_mapper.Map<ContactUs>(model), e => e.CreationDate, e => e.CreatedById);
                _unitOfWork.CompleteAync();
            }
            var result = _mapper.Map<ContactUsVM>(model);
            return View(result);
        }
         
        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._ContactUsRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._ContactUsRepo.Delete(model);
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
