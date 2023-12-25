using ILC.BL.Common.Mapping;
using ILC.BL.Models.Admin.Categories;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Product
{
    public class CreateProductHomeVM : IMapTo<ProductHome>, IMapFrom<ProductHome>
    {
        public int Id { get; set; }
        [Required]
        public string? TitleEn { get; set; }

        [Required]
        public string? TitleAr { get; set; }

        [Required]
        public string? DescriptionEn { get; set; }

        [Required]
        public string? DescriptionAr { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsAppearInHome { get; set; }
    }
}
