using ILC.BL.IRepo;
using ILC.BL.Models;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class AppUserRepo : GenericRepo<AppUser>, IAppUserRepo
    {
        private readonly ILCContext _context;
        public AppUserRepo(ILCContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<AppUser?> GetDetails(LoginModel model)
        { 
            var appUser = _context.AppUsers.Where(d =>d.Email == model.Email && d.Password == model.Password).FirstOrDefault();
            return appUser;
        }
    }
}
