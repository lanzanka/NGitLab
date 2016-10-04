using Newtonsoft.Json;
using NGitLab.Dotnet.Tests.Fixtures;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace NGitLab.Tests
{
    public class HttpClientTests : IClassFixture<FakeResponseHandlerFixture>
    {
        private Func<Uri, string, HttpClient> setupConnection;

        public HttpClientTests(FakeResponseHandlerFixture fakeResponseHandlerFixure)
        {
            setupConnection = (url, privateToken) =>
            {
                return new HttpClient(fakeResponseHandlerFixure.FakeResponseHandler) { BaseAddress = url };
            };
        }

        [Fact]
        public async void SimpleHttpTest()
        {
            var client = setupConnection(new Uri(BaseFixture.ApiUrl), null);
            var response = await client.GetAsync("/api/v3/simplehttptest/1");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(content);
            Assert.Equal(1, (int)content.Id);
            Assert.Equal("Printer", (string)content.Name);
        }

        [Fact]
        public async void FakeResponseNotSetupReturns404()
        {
            var client = setupConnection(new Uri(BaseFixture.ApiUrl), null);
            var response = await client.GetAsync("/api/v3/simpletest");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }
    }
}