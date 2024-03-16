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
    public class ContactUsVM : IMapTo<ContactUs>, IMapFrom<ContactUs>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; } 
        public bool? IsSeen { get; set; } 
        public DateTimeOffset? CreationDate { get; set; }
    }
}
