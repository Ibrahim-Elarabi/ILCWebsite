//using AutoMapper;
//using ILC.BL.IRepo; 
//using ILC.BL.Models.Admin.HomeSection.Achievements;
//using ILC.Domain.DBEntities;
//using Microsoft.AspNetCore.Mvc;

//namespace ILCWebsite.Areas.Admin
//{
//    public class AchievementController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork; 
//        private readonly IMapper _mapper;
//        public AchievementController(IUnitOfWork unitOfWork, 
//                                    IMapper mapper)
//        {
//            _unitOfWork = unitOfWork; 
//            _mapper = mapper;
//        }
//        public IActionResult Index()
//        {
//            var lst = _unitOfWork._AchievementRepo.GetAll();
//            var newList = _mapper.Map<List<AchievementVM>>(lst);
//            return View(newList.ToList());
//        }
//        public async Task<IActionResult> Edit(int id)
//        {
//            var model = await _unitOfWork._AchievementRepo.GetByIdAsync(id);
//            return View(_mapper.Map<EditAchievementVM>(model));
//        }
//        [HttpPost]
//        public async Task<JsonResult> Edit(EditAchievementVM model)
//        {
//            try
//            { 
//                if (!ModelState.IsValid)
//                {
//                    return Json(model);
//                }
//                else
//                { 
//                    var achievement = _mapper.Map<Achievement>(model);
//                    _unitOfWork._AchievementRepo.Update(achievement, e => e.CreationDate, e => e.CreatedById);
//                    var result = await _unitOfWork.CompleteAync();
//                    if (result > 0)
//                    {
//                        return Json(new
//                        {
//                            Success = true,
//                            Message = "Item edited successfully"
//                        });
//                    }
//                    else
//                    {
//                        return Json(new
//                        {
//                            Success = false,
//                            Message = "Failed to edit item",
//                        });
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return Json(new
//                {
//                    Success = false,
//                    Message = ex.Message,
//                });
//            }
//        }

//    }
//}
