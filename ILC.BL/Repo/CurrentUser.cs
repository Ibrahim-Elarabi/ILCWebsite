using ILC.BL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class CurrentUser : ICurrentUser
    {

        public bool IsAuthenticated { get; private set; }

        public string UserId { get; private set; }

        public string Email { get; private set; }

        public void Authenticate(ClaimsPrincipal user)
        {
            IsAuthenticated = user?.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticated)
            {
                UserId =user?.Claims?.FirstOrDefault(x => x.Type == "LoggedUserId")?.Value;
                Email = user?.Claims?.FirstOrDefault(x => x.Type == "Email").Value;
            }
        }
    }
}
