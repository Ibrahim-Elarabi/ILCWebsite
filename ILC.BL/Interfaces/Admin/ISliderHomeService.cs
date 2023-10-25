using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection;
using ILC.Domain.DBCommon;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Interfaces.Admin
{
    public interface ISliderHomeService : IGenericRepo<SilderHomeSection> 
    {
    }
}
