using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Common
{
    public class ILCResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<object> Errors { get; set; }
    }
}
