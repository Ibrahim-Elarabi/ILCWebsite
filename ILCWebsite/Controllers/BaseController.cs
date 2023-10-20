using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ILCWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected int LoggedUserId
        {
            get
            {
                try
                {
                    var identity = (ClaimsIdentity)User.Identity;
                    return Convert.ToInt32(identity.FindFirst("LoggedUserId")?.Value ?? "1");
                }
                catch
                {
                    return 1;
                }
            }
        }
        protected string LoggedUserEmail
        {
            get
            {
                try
                {
                    return ((ClaimsIdentity)User.Identity)?.FindFirst("Email")?.Value;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
