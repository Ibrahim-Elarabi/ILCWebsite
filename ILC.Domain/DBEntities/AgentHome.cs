using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class AgentHome : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; } 
        public string? SubTitleEn { get; set; }
        public string? SubTitleAr { get; set; } 
        public string? ImagePath { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
