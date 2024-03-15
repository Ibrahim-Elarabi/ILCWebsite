using ILC.BL.IRepo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class InquiryRepo : GenericRepo<Inquiry>, IInquiryRepo
    { 
        public InquiryRepo(ILCContext context) : base(context)
        { 
        } 
    }
}
