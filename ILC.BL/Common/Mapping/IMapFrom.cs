using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Common.Mapping
{
    public interface IMapFrom<TEntity>
    {
        public void MapFrom(MappingProfileBase profile)
        {
            profile.CreateMap(typeof(TEntity), GetType());
        }
    }
}
