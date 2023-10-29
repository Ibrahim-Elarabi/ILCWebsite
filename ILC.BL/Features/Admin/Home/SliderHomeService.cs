using AutoMapper;
using ILC.BL.Interfaces.Admin;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Features.Admin.Home
{
    public class SliderHomeService : GenericRepo<SilderHomeSection>, ISliderHomeService
    {
        public SliderHomeService(ILCContext context) : base(context)
        {
        }
    }
}
