using AutoMapper;
using ILC.BL.Common.Mapping;
using ILC.Domain.DBCommon;
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
    public class CreateCategoryVM : IMapTo<Category>, IMapFrom<Category>
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

        [Required]
        public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Category, CreateCategoryVM>();
        }
        public void MapTo(Profile profile)
        { 
            profile.CreateMap<CreateCategoryVM, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath ?? "defaultImagePath"))
            .ForMember(dest => dest.ParentCategory, opt => opt.Ignore());
        } 
    }
}
