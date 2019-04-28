namespace Api.Extensions
{
    using Authentication;
    using Microsoft.AspNetCore.Builder;

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSimpleAuthentication(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Authentication>();
        }
    }
}
