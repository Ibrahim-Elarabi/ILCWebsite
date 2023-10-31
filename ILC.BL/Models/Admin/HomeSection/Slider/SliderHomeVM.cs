using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Slider
{
    public class SliderHomeVM : IMapTo<SilderHomeSection>, IMapFrom<SilderHomeSection>
    {
        public int Id { get; set; } 
        public string? FirstHeadTextEn { get; set; } 
        public string? FirstHeadTextAr { get; set; } 
        public string? SecondtHeadTextEn { get; set; } 
        public string? SecondHeadTextAr { get; set; } 
        public string? ParagraphEn { get; set; } 
        public string? ParagraphAr { get; set; } 
        public string? ImagePath { get; set; }


    }
}
