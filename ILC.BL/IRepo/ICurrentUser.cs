using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.IRepo
{
    public interface ICurrentUser
    {
        public bool IsAuthenticated { get; }
        public string UserId { get; }
        public string Email { get; }

        void Authenticate(ClaimsPrincipal user);
    }
}
