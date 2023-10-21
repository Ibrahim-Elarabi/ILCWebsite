using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class SilderHomeSection : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? FirstHeadTextEn { get; set; }
        public string? FirstHeadTextAr { get; set; }
        public string? SecondtHeadTextEn { get; set; }
        public string? SecondHeadTextAr { get; set; }
        public string? ParagraphEn { get; set; }
        public string? ParagraphAr { get; set; }
        public string ImagePath { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
