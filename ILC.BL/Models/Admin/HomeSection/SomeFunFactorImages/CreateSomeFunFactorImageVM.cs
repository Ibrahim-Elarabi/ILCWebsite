using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.SomeFunFactorImages
{
    public class CreateSomeFunFactorImageVM : IMapTo<SomeFunFactorImage>, IMapFrom<SomeFunFactorImage>
    { 
        public int Id { get; set; }

        [Required]
        public int Order { get; set; }
        [Required]
        public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
    }
}
