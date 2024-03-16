using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ContactUs : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; }  
        public string? Message { get; set; } 
        public bool? IsSeen { get; set; } 
        public bool? IsDeleted { get; set; }
    } 
}
