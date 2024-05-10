using Back.Quala.Middlewares;

namespace Back.Quala.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlresMiddleware>();
        }
    }
}
