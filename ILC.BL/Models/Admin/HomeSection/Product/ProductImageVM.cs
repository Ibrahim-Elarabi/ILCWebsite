using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Product
{
    public class ProductImageVM : IMapTo<ProductImage>, IMapFrom<ProductImage>
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int DisplayOrder { get; set; }
        public int ProductId { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
    }
}
