using Microsoft.AspNetCore.Mvc;

namespace ILCWebsite.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}
