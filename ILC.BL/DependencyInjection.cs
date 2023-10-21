using ILC.BL.IRepo;
using ILC.BL.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLApplication(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            return services;
        }
    }
}
