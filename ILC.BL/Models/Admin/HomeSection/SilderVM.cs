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
    public class SilderVM : IMapTo<SilderHomeSection> 
    {
        public int Id { get; set; }
        [Required]
        public string? FirstHeadTextEn { get; set; }
        [Required]
        public string? FirstHeadTextAr { get; set; }
        [Required]
        public string? SecondtHeadTextEn { get; set; }
        [Required]
        public string? SecondHeadTextAr { get; set; }

        [Required]
        public string? ParagraphEn { get; set; }
        [Required]
        public string? ParagraphAr { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string? ImagePath { get; set; }


    }
}
