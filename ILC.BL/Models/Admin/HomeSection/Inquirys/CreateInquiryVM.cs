using ILC.BL.Common.Mapping;
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

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public int? CountryId { get; set; }
         
        [Required]
        public int? CityId { get; set; }
         
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? CountryCode { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Message { get; set; }

        [Required]
        public bool IsReadAndAccept { get; set; }
    }
}
