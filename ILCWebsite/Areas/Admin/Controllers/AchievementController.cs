using AutoMapper;
using ILC.BL.IRepo; 
using ILC.BL.Models.Admin.HomeSection.Achievements;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Areas.Admin
{
    [Area("Admin")]
    [Authorize]
    public class AchievementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        public AchievementController(IUnitOfWork unitOfWork, 
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lst = _unitOfWork._AchievementRepo.GetAll();
            var newList = _mapper.Map<List<AchievementVM>>(lst);
            return View(newList.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateAchievementVM());
        }
         
        [HttpPost]
        public async Task<JsonResult> Create(CreateAchievementVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }
            else
            { 
                try
                {
                    var OldElementsCount = _unitOfWork._AchievementRepo.GetAll().Count();
                    if (OldElementsCount < 3)
                    {
                        var result = await _unitOfWork._AchievementRepo.InsertAsync(_mapper.Map<Achievement>(model));
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
                            Message = "Max number of Achivements is (3) elements",
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
            var model = await _unitOfWork._AchievementRepo.GetByIdAsync(id);
            return View(_mapper.Map<EditAchievementVM>(model));
        }
         
        [HttpPost]
        public async Task<JsonResult> Edit(EditAchievementVM model)
        { 
            try
            { 
                if (!ModelState.IsValid)
                {
                    return Json(model);
                }
                else
                { 
                    var achievement = _mapper.Map<Achievement>(model);
                    _unitOfWork._AchievementRepo.Update(achievement, e => e.CreationDate, e => e.CreatedById);
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
                var model = _unitOfWork._AchievementRepo.GetById(id);
                if (model != null)
                {
                    _unitOfWork._AchievementRepo.Delete(model);
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
