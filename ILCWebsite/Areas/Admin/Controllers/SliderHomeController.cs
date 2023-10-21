using AutoMapper;
using ILC.BL.Models.Admin.HomeSection;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderHomeController : Controller
    {
        private readonly IMapper _mapper;

        public SliderHomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SilderVM model)
        {
            if(! ModelState.IsValid)
            {
                var newmodel = _mapper.Map<SilderHomeSection>(model);
                return View(model);
            }
            return RedirectToAction("Create");
        }
    }
}
