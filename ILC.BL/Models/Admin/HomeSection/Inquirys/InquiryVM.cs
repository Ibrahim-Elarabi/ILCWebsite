using ILC.BL.Common.Mapping;
using ILC.BL.Models.Admin.Common;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Inquirys
{
    public class InquiryVM : IMapTo<Inquiry>, IMapFrom<Inquiry>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public CountryVM Country { get; set; }  
        public CityVM City { get; set; }
        public string? Email { get; set; }
        public string? CountryCode { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
    }
}
