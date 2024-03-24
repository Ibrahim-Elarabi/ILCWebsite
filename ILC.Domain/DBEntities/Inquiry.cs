using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class Inquiry : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; } 
        public string? Email { get; set; }
        public string? CountryCode { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public bool? IsReadAndAccept { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ProductId { get; set; }
        public bool IsSeen { get; set; }
    } 
}
