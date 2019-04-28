namespace Api.Tests.Authentication.AuthenticationProvider
{
    using System.Collections.Generic;
    using System.Net;
    using Api.Authentication;
    using Api.Authentication.Configuration;
    using NUnit.Framework;

    public class AuthenticationProvider_InvalidKey_BadRequest_Tests
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
        public void BadRequestNull()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest(null), Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void BadRequestStringEmpty()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest(string.Empty), Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void BadRequestWhiteSpace()
        {
            Assert.That(new AuthenticationProvider(this.configuration).AuthorisedRequest(" "), Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
