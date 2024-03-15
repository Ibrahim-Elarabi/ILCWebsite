using ILC.BL.Common.Mapping;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.Common
{
    public class CityVM : IMapTo<City>, IMapFrom<City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CountryId { get; set; }
    }
}
