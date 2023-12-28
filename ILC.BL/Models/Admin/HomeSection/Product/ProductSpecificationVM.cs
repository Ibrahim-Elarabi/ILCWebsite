using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Product
{
    public class ProductSpecificationVM : IMapFrom<ProductSpecification> , IMapTo<ProductSpecification>
    {
        public int ID { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public int DisplayOrder { get; set; }
        public int ProductId { get; set; }
    }
}
