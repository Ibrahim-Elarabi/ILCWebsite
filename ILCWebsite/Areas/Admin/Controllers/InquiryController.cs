using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.Inquirys;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class InquiryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        private readonly IMapper _mapper;
        public InquiryController(IUnitOfWork unitOfWork,
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
            try
            {
                var lst = _unitOfWork._inquiryRepo.GetAll();
                var result = lst.Select(d => new InquiryVM(d)).ToList();
                return View(result);
            }
            catch (Exception ex)
            {
                return View(new List<InquiryVM>());
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            try
            {
                var inquiry = _unitOfWork._inquiryRepo
                                  .Find(d => d.Id == id && d.IsDeleted != true)
                                  .FirstOrDefault();
                if (inquiry != null && inquiry.IsSeen != true)
                {
                    inquiry.IsSeen = true;
                    _unitOfWork._inquiryRepo.Update(inquiry, e => e.CreationDate, e => e.CreatedById);
                    _unitOfWork.Complete();
                }

                var result = new InquiryVM(inquiry);
                return View(result);
            }
            catch (Exception ex)
            { 
                throw;
            }
        }

         
        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._inquiryRepo.GetById(id);
                if (model != null) {
                    _unitOfWork._inquiryRepo.Delete(model);
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
