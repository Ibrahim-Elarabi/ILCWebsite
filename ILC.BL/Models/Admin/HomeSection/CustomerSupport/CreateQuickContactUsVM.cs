using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.CustomerSupport
{
    public class CreateQuickContactUsVM : IMapTo<ContactUs>, IMapFrom<ContactUs>
    {
        public int Id { get; set; } 

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}
