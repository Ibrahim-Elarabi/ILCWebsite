using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using ILC.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Titles
{
    public class EditTitleVM :  IMapTo<Title>, IMapFrom<Title>
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

        public string? SectionName { get; set; } 

    }
}
