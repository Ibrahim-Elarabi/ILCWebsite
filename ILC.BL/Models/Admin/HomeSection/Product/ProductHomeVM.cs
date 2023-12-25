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
    public class ProductHomeVM : IMapTo<ProductHome>, IMapFrom<ProductHome>
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImagePath { get; set; }
        public bool? IsAppearInHome { get; set; }
        public int? CategoryId { get; set; }
        public CategoryVM category { get; set; }
    }
}
