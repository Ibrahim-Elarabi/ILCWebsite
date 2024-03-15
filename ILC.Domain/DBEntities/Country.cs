using ILC.Domain.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class Country
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public virtual List<City> Cities { get; set; } = new List<City>();
    } 
}
