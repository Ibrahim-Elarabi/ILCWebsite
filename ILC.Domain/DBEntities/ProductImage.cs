using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ProductImage : ISoftDeletable
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsDeleted { get; set; }
        public int ProductId { get; set; }
        public virtual ProductHome Product { get; set; }
    }
}
