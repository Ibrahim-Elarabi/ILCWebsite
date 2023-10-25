using ILC.BL.Interfaces.Account;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Features.Account
{
    public class AccountService : IAccountService
    {
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
    }
}
