namespace Api.Tests.Authentication.AuthenticationProvider
{
    using System.Collections.Generic;
    using System.Net;
    using Api.Authentication;
    using Api.Authentication.Configuration;
    using NUnit.Framework;

    public class AuthenticationProvider_Ok_Tests
    {
        public const string validApiKey = "validApiKey";

        public readonly AuthenticationConfiguration configuration = new AuthenticationConfiguration();

        public HttpStatusCode result;

        [OneTimeSetUp]
        public void Setup()
        {
            this.configuration.AuthorisedKeys = new List<AuthorisedKeys>()
            {
                new AuthorisedKeys() { ApiKey = validApiKey }
            };

            this.result = new AuthenticationProvider(this.configuration).AuthorisedRequest(validApiKey);
        }

        [Test]
        public void Ok()
        {
            Assert.That(this.result, Is.EqualTo(HttpStatusCode.Accepted));
        }
    }
}
