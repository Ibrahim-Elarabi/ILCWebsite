using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detials()
        {
            return View();
        }
    }
}
