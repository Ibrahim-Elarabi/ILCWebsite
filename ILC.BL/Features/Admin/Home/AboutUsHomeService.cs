using ILC.BL.Interfaces.Admin;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Features.Admin.Home
{
    public class AboutUsHomeService : GenericRepo<SilderHomeSection>, IAboutUsHomeService
    {
        public AboutUsHomeService(ILCContext context) : base(context)
        {
        }
    }
}
