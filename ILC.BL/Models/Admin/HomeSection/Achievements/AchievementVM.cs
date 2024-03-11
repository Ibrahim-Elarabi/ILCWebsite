using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Achievements
{
    public class AchievementVM : IMapTo<Achievement>, IMapFrom<Achievement>
    {
        public int Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public int? Value { get; set; }
    }
}
