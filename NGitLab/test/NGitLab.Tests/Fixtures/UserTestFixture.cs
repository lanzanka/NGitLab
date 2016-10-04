using Newtonsoft.Json;
using NGitLab.Dotnet.Tests.Infrastructure;
using NGitLab.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace NGitLab.Dotnet.Tests.Fixtures
{
    public class UserTestFixture : BaseFixture
    {
        public IGitLabClient Client { get; private set; }

        public UserTestFixture()
        {
            Client = new GitLabClient(ApiUrl, string.Empty, new HttpClient(FakeResponseHandler) { BaseAddress = new Uri(ApiUrl) });
        }

        public override void Setup()
        {
            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/users"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new List<User>
                            {
                                new User
                                {
                                    Id = 1,
                                    Name = "Administrator",
                                    Email = "admin@example.com",
                                    CanCreateGroup = true,
                                    Username = "root"
                                },
                                new User
                                {
                                    Id = 2,
                                    Name = "User",
                                    Email = "user@example.com",
                                    Username = "user"
                                }
                            }))
                });

            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/users/1"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                        new Session
                        {
                            Id = 1,
                            Name = "Administrator",
                            Email = "admin@example.com",
                            Username = "root",
                            CanCreateGroup = true,
                            CreatedAt = DateTime.Now.Date,
                            PrivateToken = "1234"
                        }))
                });

            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/user"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                        new Session
                        {
                            Id = 1,
                            Name = "Administrator",
                            Email = "admin@example.com",
                            CreatedAt = DateTime.Now.Date,
                            PrivateToken = "1234"
                        }))
                });

            FakeResponseHandler.AddFakePostResponse(
                new Uri($"{ApiUrl}/api/v3/users"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new User
                            {
                                Id = 1,
                                Name = "Administrator",
                                Email = "admin@example.com",
                                CanCreateGroup = true,
                                Username = "root",
                                Bio = "bio"
                            }))
                });

            FakeResponseHandler.AddFakePutResponse(
                new Uri($"{ApiUrl}/api/v3/users/1"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new User
                            {
                                Id = 1,
                                Name = "Administrator",
                                Email = "test@test.pl",
                                CanCreateGroup = true,
                                Username = "root",
                                Bio = "Bio2"
                            }))
                });

            FakeResponseHandler.AddFakeDeleteResponse(
                new Uri($"{ApiUrl}/api/v3/users/1"),
                new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
