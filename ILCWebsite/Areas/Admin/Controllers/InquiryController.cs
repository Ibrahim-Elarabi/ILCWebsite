using AutoMapper;
using ILC.BL.Common;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.Inquirys;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var lst = _unitOfWork._inquiryRepo.GetAll().Include(d=>d.Country);
            var newList = _mapper.Map<List<InquiryVM>>(lst);
            return View(newList.ToList());
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var blog = _unitOfWork._inquiryRepo.FindOne(
                        predicate: d => d.Id == id && d.IsDeleted != true,
                        asNoTracking: false,
                        splitQuery: false,
                        joins: new Expression<Func<Inquiry, object>>[] { d => d.City, d => d.Country }
                    );
            var result = _mapper.Map<InquiryVM>(blog);
            return View(result);
        }

         
        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _unitOfWork._blogHomeRepo.GetById(id);
                if (model != null) {
                    _unitOfWork._blogHomeRepo.Delete(model);
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
