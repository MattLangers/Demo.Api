namespace Api.Authentication
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class Authentication
    {
        private readonly RequestDelegate _next;

        public Authentication(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext, IAuthenticationProvider authenticationProvider)
        {
            if (!httpContext.Request.IsHttps)
            {
                httpContext.Response.StatusCode = (int)403.4;
                return;
            }

            var authorised = authenticationProvider.AuthorisedRequest(httpContext.Request.Headers["api-key"]);
            if (authorised != HttpStatusCode.Accepted)
            {
                httpContext.Response.StatusCode = (int)authorised;
                return;
            }

            await _next(httpContext);
        }
    }
}
