using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities; 

namespace ILC.BL.Models.Admin.HomeSection.Support
{
    public class SupportHomeVM : IMapTo<SupportHome>, IMapFrom<SupportHome>
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? LocationEn { get; set; }
        public string? LocationAr { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }  
    }
}
