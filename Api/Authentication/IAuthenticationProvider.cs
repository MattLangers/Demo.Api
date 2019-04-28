namespace Api.Authentication
{
    using System.Net;

    public interface IAuthenticationProvider
    {
        HttpStatusCode AuthorisedRequest(string apiKey);
    }
}
