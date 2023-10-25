namespace ILCWebsite.Midelwares
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SaveCurrentUserMiddleware>();
        }
    }
}
