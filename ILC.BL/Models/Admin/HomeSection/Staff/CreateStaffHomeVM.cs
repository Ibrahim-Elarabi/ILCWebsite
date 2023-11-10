﻿using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Staff
{
    public class CreateStaffHomeVM : IMapTo<StaffHome>, IMapFrom<StaffHome>
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
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
