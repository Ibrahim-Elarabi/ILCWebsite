using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Common.Mapping
{
    public interface IMapTo<TEntity>
    {
        public void MapTo(MappingProfileBase profile)
        {
            profile.CreateMap(GetType(), typeof(TEntity));
        }
    }
}
