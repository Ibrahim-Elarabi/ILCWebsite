using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class SupportHome : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? LocationEn { get; set; }
        public string? LocationAr { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsDeleted { get; set; } 
    }
}
