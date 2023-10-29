using ILC.BL.IRepo;

namespace ILCWebsite.Midelwares
{
    public class SaveCurrentUserMiddleware
    {
        public RequestDelegate _next;

        public SaveCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if(context.User != null)
            {
                var currentUser = context.RequestServices.GetService(typeof(ICurrentUser)) as ICurrentUser;
                currentUser?.Authenticate(context.User);
            }
            return _next(context);
        }
    }
}
