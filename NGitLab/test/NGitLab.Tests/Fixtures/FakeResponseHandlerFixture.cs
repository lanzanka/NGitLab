using Newtonsoft.Json;
using NGitLab.Dotnet.Tests.Infrastructure;
using System;
using System.Net;
using System.Net.Http;

namespace NGitLab.Dotnet.Tests.Fixtures
{
    public class FakeResponseHandlerFixture : BaseFixture
    {
        public override void Setup()
        {
            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/simplehttptest/1"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                        new
                        {
                            Id = 1,
                            Name = "Printer"
                        }))
                });
        }
    }
}
