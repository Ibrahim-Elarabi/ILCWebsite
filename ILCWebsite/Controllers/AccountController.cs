using ILC.BL.IRepo;
using ILC.BL.Models;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ILCWebsite.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            try
            {
                try
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Something went wrong ,Please try again later , " + ex.Message;
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    var appUser = await unitOfWork._AppUserRepo.GetDetails(model);
                    if (appUser != null)
                    {
                        if (appUser.IsActive != true)
                        {
                            ViewBag.Message = "Your account has beed deactivated , please contact to your admin";
                            return View(model);
                        }
                        else
                        {
                            await SignIn(HttpContext, appUser);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect email or password";
                        return View(model);
                    }
                }
                ViewBag.Message = "Incorrect email or password";
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Something went wrong ,Please try again later ," + ex.Message;
                return View(model);
            }
        }

        public async Task SignIn(HttpContext HttpContext, AppUser appUser)
        {
            var claims = new List<Claim>()
            {
                    new Claim("LoggedUserId", Convert.ToString(appUser.Id)),
                    new Claim("Name", appUser.Name??""),
                    new Claim("Email", appUser.Email??""),
                    new Claim("IsAdmin", Convert.ToString(appUser.IsAdmin ?? false))
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
            });
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn", "Account");
        }

    }
}
