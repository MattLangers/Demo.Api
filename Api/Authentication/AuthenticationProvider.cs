namespace Api.Authentication
{
    using System.Linq;
    using System.Net;
    using Configuration;

    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly AuthenticationConfiguration configuration;

        public AuthenticationProvider(AuthenticationConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public HttpStatusCode AuthorisedRequest(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return HttpStatusCode.BadRequest;
            }

            return this.RegisteredApiKey(apiKey) ? HttpStatusCode.Accepted : HttpStatusCode.Forbidden;
        }

        private bool RegisteredApiKey(string apiKey)
        {
            return this.configuration.AuthorisedKeys.All(a => a.ApiKey == apiKey);
        }
    }
}
