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
        public ProductHomeSectionRepo(ILCContext context) : base(context)
        { 
        }

    }
}
