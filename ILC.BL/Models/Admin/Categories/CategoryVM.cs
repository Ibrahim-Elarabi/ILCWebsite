using AutoMapper;
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
    public class CategoryVM : IMapTo<Category>, IMapFrom<Category>
    {   
        public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ImagePath { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<CategoryVM, Category>()
              .ForMember(m => m.ParentCategory, null);
        }
        public void MapTo(Profile profile)
        {
            profile.CreateMap<Category, CategoryVM>()
              .ForMember(m => m.ParentCategoryId, opt => opt.MapFrom(scr => scr.ParentCategory.Id));
        }
    }
}
