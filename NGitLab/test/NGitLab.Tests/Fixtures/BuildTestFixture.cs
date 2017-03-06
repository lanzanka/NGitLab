using Newtonsoft.Json;
using NGitLab.Dotnet.Tests.Infrastructure;
using NGitLab.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace NGitLab.Dotnet.Tests.Fixtures
{
    public class BuildTestFixture : BaseFixture
    {
        public IGitLabClient Client { get; private set; }
        public IRepositoryClient RepositoryClient { get; private set; }
        private const int ProjectId = 1;
        public User SampleUser { get; set; }

        public BuildTestFixture()
        {
            Client = new GitLabClient(ApiUrl, string.Empty, new HttpClient(FakeResponseHandler) { BaseAddress = new Uri(ApiUrl) });
            RepositoryClient = Client.GetRepository(ProjectId);
            SampleUser = new User
            {
                Id = 1,
                Name = "Administrator",
                Email = "admin@example.com",
                CanCreateGroup = true,
                Username = "root"
            };
        }

        public override void Setup()
        {
            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/projects/{ProjectId}/builds"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new List<Build>
                            {
                                new Build
                                {
                                    Id = 1,
                                    Status = "skipped",
                                    Stage = "build",
                                    Name = "sample_build",
                                    Ref = "ref",
                                    Tag = false,
                                    Coverage = null,
                                    CreatedAt = DateTime.Now.Date,
                                    StartedAt = null,
                                    FinishedAt = null,
                                    User = SampleUser
                                },
                                new Build
                                {
                                    Id = 2,
                                    Status = "success",
                                    Stage = "build",
                                    Name = "sample_build",
                                    Ref = "ref",
                                    Tag = false,
                                    Coverage = null,
                                    CreatedAt = DateTime.Now.Date,
                                    StartedAt = DateTime.Now.Date,
                                    FinishedAt = DateTime.Now.Date,
                                    User = SampleUser
                                }
                            }))
                });

            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/projects/{ProjectId}/builds?scope=success"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new List<Build>
                            {
                                new Build
                                {
                                    Id = 2,
                                    Status = "success",
                                    Stage = "build",
                                    Name = "sample_build",
                                    Ref = "ref",
                                    Tag = false,
                                    Coverage = null,
                                    CreatedAt = DateTime.Now.Date,
                                    StartedAt = DateTime.Now.Date,
                                    FinishedAt = DateTime.Now.Date,
                                    User = SampleUser
                                }
                            }))
                });

            FakeResponseHandler.AddFakeGetResponse(
                new Uri($"{ApiUrl}/api/v3/projects/{ProjectId}/builds/1"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new Build
                            {
                                Id = 1,
                                Status = "skipped",
                                Stage = "build",
                                Name = "single_build",
                                Ref = "ref",
                                Tag = false,
                                Coverage = null,
                                CreatedAt = DateTime.Now.Date,
                                StartedAt = null,
                                FinishedAt = null,
                                User = SampleUser
                            }))
                });
        }
    }
}
