using ILC.BL.Models.Admin.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Product
{
    public class SubCategoryWithProducts
    { 
        public CategoryVM? SubCategory { get; set; }
        public List<ProductHomeVM>? ProductList { get; set; }
    }
}
