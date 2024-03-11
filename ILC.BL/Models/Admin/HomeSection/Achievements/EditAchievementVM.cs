using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Achievements
{
    public class EditAchievementVM : IMapTo<Achievement>, IMapFrom<Achievement>
    {
        public int Id { get; set; }

        [Required]
        public string? TitleEn { get; set; }

        [Required]
        public string? TitleAr { get; set; }

        [Required]
        public int? Value { get; set; }
    }
}
