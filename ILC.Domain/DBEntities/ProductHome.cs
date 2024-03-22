using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ProductHome : AuditableEntity,ISoftDeletable
    {
        public int Id { get; set; }
        public string? TitleEn{ get; set; }
        public string? TitleAr{ get; set; }
        public string? DescriptionEn{ get; set; }
        public string? DescriptionAr { get; set; } 
        public string? ImagePath { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAppearInHome { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; } 
        public virtual List<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual List<ProductSpecification> Specifications { get; set; } = new List<ProductSpecification>();
        public virtual List<ProductSimilar> SimilarProducts { get; set; } = new List<ProductSimilar>();
 
    }
}
