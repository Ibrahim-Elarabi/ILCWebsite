using ILC.BL.Models.Admin.HomeSection;
using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderHomeController : Controller
    {
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
                return View(model);
            }
            return RedirectToAction("Create");
        }
    }
}
