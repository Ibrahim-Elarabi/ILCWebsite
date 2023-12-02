﻿using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            ParentCategory = new Category();
        }
        public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImagePath { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; } 
        public bool? IsDeleted { get; set; }
    }
}
