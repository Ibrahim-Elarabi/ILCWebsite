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
    public class SomeFunFactorImageVM : IMapTo<SomeFunFactorImage>, IMapFrom<SomeFunFactorImage>
    {
        public int Id { get; set; } 
        public int Order { get; set; }
        public string? ImagePath { get; set; }
    }
}
