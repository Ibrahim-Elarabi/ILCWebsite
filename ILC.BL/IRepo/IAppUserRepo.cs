using ILC.BL.Models;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.IRepo
{
    public interface IAppUserRepo : IGenericRepo<AppUser>
    {
        Task<AppUser?> GetDetails(LoginModel model);
    }
}
