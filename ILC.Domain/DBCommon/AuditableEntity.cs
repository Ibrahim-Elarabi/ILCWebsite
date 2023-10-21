using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBCommon
{
    public abstract class AuditableEntity
    {
        public int? CreatedById { get; set; }

        public DateTimeOffset? CreationDate { get; set; }

        public int? LastModifiedById { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }

        public virtual AppUser? CreatedBy { get; set; }

        public virtual AppUser? LastModifiedBy { get; set; }
    }
}
