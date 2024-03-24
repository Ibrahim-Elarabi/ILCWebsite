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

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        public string? CountryCode { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "You must read and accept the terms.")]
        [MustBeTrue(ErrorMessage = "You must read and accept the terms.")]
        public bool IsReadAndAccept { get; set; }

        public int? productId { get; set; }
    }
}
