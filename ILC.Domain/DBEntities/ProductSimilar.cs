using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ProductSimilar
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual ProductHome Product { get; set; }

        public int SimilarProductId { get; set; } 
    }
}
