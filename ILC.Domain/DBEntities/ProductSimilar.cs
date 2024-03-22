using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ProductSimilar
    {
        public int ProductId { get; set; }
        public ProductHome Product { get; set; }

        public int SimilarProductId { get; set; }
        public ProductHome SimilarProduct { get; set; }
    }
}
