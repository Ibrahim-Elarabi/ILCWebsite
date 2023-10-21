using ILC.BL.IRepo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class ProductHomeSectionRepo : GenericRepo<ProductHomeSection>, IProductHomeSectionRepo
    {
        private readonly ILCContext _context;
        public ProductHomeSectionRepo(ILCContext context) : base(context)
        {
            this._context = context;
        }

    }
}
