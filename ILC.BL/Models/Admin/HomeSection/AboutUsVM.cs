using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection
{
    public class AboutUsVM :IMapTo<AboutUsHomeSection>  , IMapFrom<AboutUsHomeSection> 
    {
        public string? ImagePath { get; set; }

        public int Id { get; set; }
        [Required]
        public string? TextEn { get; set; }
        [Required]
        public string? TextAr { get; set; }
        [Required]
        public IFormFile Image { get; set; }

    }
}
