using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Interfaces.Account
{
    public interface IAccountService
    {
        Task SignIn(HttpContext HttpContext, AppUser appUser);
    }
}
