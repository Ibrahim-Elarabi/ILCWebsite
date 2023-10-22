using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models
{
    public class CreateProductHomeSectionModel
    {
        [Display(Name = "Title english")]
        [Required(ErrorMessage = "Title in english is required")]
        public string? TitleEn { get; set; }


        [Display(Name = "Title arabic")]
        [Required(ErrorMessage = "Title in arabic is required")]
        public string? TitleAr { get; set; }


        [Display(Name = "Description english")]
        [Required(ErrorMessage = "Description in english is required")]
        public string? DescriptionEn { get; set; }


        [Display(Name = "Description arabic")]
        [Required(ErrorMessage = "Description in arabic is required")]
        public string? DescriptionAr { get; set; }


        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }
    }
}
