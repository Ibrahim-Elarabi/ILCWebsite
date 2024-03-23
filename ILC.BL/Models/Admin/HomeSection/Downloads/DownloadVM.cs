using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using ILC.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Downloads
{
    public class DownloadVM : IMapTo<Download>, IMapFrom<Download>
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; } 
        public string? PdfPath { get; set; }
        public PdfTypesEnum? FileType { get; set; }
        public bool AppearInHome { get; set; }
    }
}
