using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ProductSpecification : ISoftDeletable
    {
        public int ID { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsDeleted { get; set; }
        public int ProductId { get; set; }
        public virtual ProductHome Product { get; set; }
    }
}
