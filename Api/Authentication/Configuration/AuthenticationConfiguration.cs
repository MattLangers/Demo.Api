namespace Api.Authentication.Configuration
{
    using System.Collections.Generic;

    public class AuthenticationConfiguration
    {
        public IList<AuthorisedKeys> AuthorisedKeys { get; set; }
    }
}
