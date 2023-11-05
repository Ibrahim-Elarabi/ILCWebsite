using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities; 
using System.ComponentModel.DataAnnotations; 

namespace ILC.BL.Models.Admin.HomeSection.Support
{
    public class EditSupportHomeVM :  IMapTo<SupportHome>, IMapFrom<SupportHome>
    {
        public int Id { get; set; }
        [Required]
        public string? TitleEn { get; set; }

        [Required]
        public string? TitleAr { get; set; }

        [Required]
        public string? DescriptionEn { get; set; }

        [Required]
        public string? DescriptionAr { get; set; }
        [Required]
        public string? LocationEn { get; set; }
        [Required]
        public string? LocationAr { get; set; }
        [Required] 
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}
