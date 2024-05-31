using ILC.BL.Common.Mapping;
using ILC.BL.CustomAttributes;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Inquirys
{
    public class CreateInquiryVM : IMapTo<Inquiry>, IMapFrom<Inquiry>
    {
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public string? LastName { get; set; } 
        public string? Country { get; set; } 
        public string? City { get; set; } 
        public string? Email { get; set; } 
        public string? CountryCode { get; set; } 
        public string? Phone { get; set; } 
        public string? Subject { get; set; } 
        public string? Message { get; set; }
        public bool? IsReadAndAccept { get; set; } = true;
        public int? productId { get; set; }
    }
}
