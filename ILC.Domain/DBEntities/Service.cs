using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{ 
    public class Service : AuditableEntity, ISoftDeletable
    {
        public Service()
        {
            SubServices = new List<Service>();
        }
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? SubTitleEn { get; set; }
        public string? SubTitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImagePath { get; set; }
        public bool? IsDeleted { get; set; }
        public bool AppearInHomePage { get; set; }
        public int? ParentServiceId { get; set; }
        public virtual Service? ParentService { get; set; }
        public virtual List<Service>? SubServices { get; set; }
    }
}
