namespace Api.Tests.Authentication.AuthenticationProvider
{
    using System.Collections.Generic;
    using System.Net;
    using Api.Authentication;
    using Api.Authentication.Configuration;
    using NUnit.Framework;

    public class AuthenticationProvider_InvalidKey_Forbidden_Tests
    {
        public const string validApiKey = "validApiKey";

        public readonly AuthenticationConfiguration configuration = new AuthenticationConfiguration();

        [OneTimeSetUp]
        public void Setup()
        {
            this.configuration.AuthorisedKeys = new List<AuthorisedKeys>()
            {
                new AuthorisedKeys() { ApiKey = validApiKey }
            };
        }

        [Test]
        public void InvalidKey()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest("aninvalidapikey"), Is.EqualTo(HttpStatusCode.Forbidden));
        }

        [Test]
        public void IncorrectCaseLower()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest(validApiKey.ToLower()), Is.EqualTo(HttpStatusCode.Forbidden));
        }

        [Test]
        public void IncorrectCaseUpper()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest(validApiKey.ToUpper()), Is.EqualTo(HttpStatusCode.Forbidden));
        }
    }
}
