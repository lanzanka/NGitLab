using System;

namespace NGitLab.Dotnet.Tests.Fixtures
{
    public class IntegrationTestFixture
    {
        public string Host { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string PrivateToken { get; private set; }

        public IntegrationTestFixture()
        {
            Host = Environment.GetEnvironmentVariable("GITLAB_HOST");
            PrivateToken = Environment.GetEnvironmentVariable("GITLAB_PRIVATETOKEN");
            Username = Environment.GetEnvironmentVariable("GITLAB_USERNAME");
            Password = Environment.GetEnvironmentVariable("GITLAB_PASSWORD");
        }
    }
}
