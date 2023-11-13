using ILC.BL.IRepo;
using ILC.BL.Models;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ILC.BL.Interfaces.Account;

namespace ILCWebsite.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        public AccountController(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
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
                    var appUser = _unitOfWork._appUserRepo.FindOne(d => d.Email == model.Email && d.Password == model.Password);
                    if (appUser != null)
                    {
                        if (appUser.IsActive != true)
                        {
                            ViewBag.Message = "Your account has beed deactivated , please contact to your admin";
                            return View(model);
                        }
                        else
                        {
                            await _accountService.SignIn(HttpContext, appUser);
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
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
         
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn", "Account");
        }

    }
}
