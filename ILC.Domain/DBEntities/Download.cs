using ILC.Domain.DBCommon;
using ILC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class Download : AuditableEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? PdfPath { get; set; }
        public PdfTypesEnum? FileType { get; set; }
        public bool? IsDeleted { get; set; }
    } 
}
