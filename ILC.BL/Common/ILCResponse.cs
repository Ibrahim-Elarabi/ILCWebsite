using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Common
{
    public class ILCResponse<T> where T : class
    {
        public T Data { get; set; }
        public int Status { get; set; }
        public List<object> Errors { get; set; }
    }
}
