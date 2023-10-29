using ILC.BL;
using ILC.BL.IRepo; 
using ILC.BL.Repo; 
using ILC.Domain.DBEntities;
using ILCWebsite.Midelwares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ILCWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ILCContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            }); 
            builder.Services.AddMvcCore().AddRazorViewEngine(); 
            builder.Services.AddControllersWithViews()
                            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                            .AddDataAnnotationsLocalization();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();  
            builder.Services.AddBLApplication(); 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/account/login/";
                });
            var app = builder.Build();

            var supportedCultures = new[] {
                  new CultureInfo("ar-EG"),
                  new CultureInfo("en-US"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });


            // Configure the HTTP request pipeline. 
            if (app.Environment.IsDevelopment())//TODO change condition
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                context.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-GB"))
            );
                await next();

            });
            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseCurrentUser(); // To Save Current User
            app.UseAuthorization();
            if (app.Environment.IsProduction())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dataContext = scope.ServiceProvider.GetRequiredService<ILCContext>();
                    dataContext.Database.Migrate();
                }
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}