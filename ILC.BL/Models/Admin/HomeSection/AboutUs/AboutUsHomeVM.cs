using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.AboutUs
{
    public class AboutUsHomeVM : IMapTo<AboutUsHomeSection>, IMapFrom<AboutUsHomeSection>
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? TextEn { get; set; } 
        public string? TextAr { get; set; }
        public int Order { get; set; }
        public string? ImagePath { get; set; }
    }
}
