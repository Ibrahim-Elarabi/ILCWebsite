using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.Categories
{
    public class EditCategoryVM :  IMapTo<Category>, IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        public string? NameEn { get; set; }

        [Required]
        public string? NameAr { get; set; }

        [Required]
        public string? DescriptionEn { get; set; }

        [Required]
        public string? DescriptionAr { get; set; }

        public int? ParentCategoryId { get; set; }

        public IFormFile? Image { get; set; } 
        public string? ImagePath { get; set; }
    }
}
