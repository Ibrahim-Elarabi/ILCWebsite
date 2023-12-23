using ILC.BL.Common.Mapping;
using ILC.BL.Features.Account;
using ILC.BL.Features.Admin.Home;
using ILC.BL.Interfaces.Account;
using ILC.BL.Interfaces.Admin;
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
            services.AddAutoMapper(typeof(MappingProfileBase));
            services.AddScoped<IUnitOfWork, UnitOfWork>(); 
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ISliderHomeService, SliderHomeService>();
            services.AddScoped<IAboutUsHomeService, AboutUsHomeService>();
            services.AddScoped<IAppUserRepo, AppUserRepo>();
            services.AddScoped<IProductHomeRepo, ProductHomeRepo>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IAgentHomeRepo, AgentHomeRepo>();
            services.AddScoped<IBlogHomeRepo, BlogHomeRepo>();
            services.AddScoped<IStaffHomeRepo, StaffHomeRepo>();
            services.AddScoped<ISupportHomeRepo, SupportHomeRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductImageRepo, ProductImageRepo>();
            return services;
        }
    }
}
