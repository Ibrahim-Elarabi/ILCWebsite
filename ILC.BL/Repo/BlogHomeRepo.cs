using ILC.BL.IRepo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class BlogHomeRepo : GenericRepo<BlogHome>, IBlogHomeRepo
    { 
        public BlogHomeRepo(ILCContext context) : base(context)
        { 
        }

    }
}
