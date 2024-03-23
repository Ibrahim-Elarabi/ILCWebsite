using AutoMapper;
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
        public string? Code { get; set; }
        public int? CategoryId { get; set; }
        public CategoryVM Category { get; set; }
        public virtual List<ProductImageVM> Images { get; set; } = new List<ProductImageVM>();
        public virtual List<ProductSpecificationVM> Specifications { get; set; } = new List<ProductSpecificationVM>();
        public virtual List<ProductHomeVM> SimilarProducts { get; set; } = new List<ProductHomeVM>();
        public void MapTo(MappingProfileBase profile)
        {
            profile.CreateMap<ProductHome, ProductHomeVM>()
                .ForMember(dest => dest.SimilarProducts, opt => opt.Ignore());
        }

        public void MapFrom(MappingProfileBase profile)
        {
            profile.CreateMap<ProductHomeVM, ProductHome>()
                .ForMember(dest => dest.SimilarProducts, opt => opt.Ignore()); 
         }
    }
}
