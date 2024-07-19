using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class AboutUsHomeSection:AuditableEntity , ISoftDeletable
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string TextEn { get; set; }
        public string TextAr { get; set; } 
        public int Order { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
