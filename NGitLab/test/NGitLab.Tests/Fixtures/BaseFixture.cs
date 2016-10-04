using NGitLab.Dotnet.Tests.Infrastructure;
using System;
using System.Net.Http;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1652:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace NGitLab.Dotnet.Tests.Fixtures
{
    public abstract class BaseFixture
    {
        public const string ApiUrl = "http://gitlab.com";

        public FakeResponseHandler FakeResponseHandler { get; protected set; }

        private Func<Uri, string, HttpClient> setupConnection;

        public BaseFixture()
        {
            FakeResponseHandler = new FakeResponseHandler();

            setupConnection = (url, privateToken) =>
            {
                return new HttpClient(FakeResponseHandler) { BaseAddress = url };
            };

            Setup();
        }

        public abstract void Setup();
    }
}
