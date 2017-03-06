using NGitLab.Dotnet.Tests.Fixtures;
using System;
using System.Linq;
using NGitLab.Models;
using Xunit;

namespace NGitLab.Tests
{
    public class BuildTests : IClassFixture<BuildTestFixture>
    {
        private readonly IBuildClient _builds;

        public BuildTests(BuildTestFixture buildTestFixture)
        {
            _builds = buildTestFixture.RepositoryClient.Builds;
        }

        [Fact]
        public async void GetBuilds()
        {
            var builds = await _builds.All();
            Assert.NotNull(builds);
            Assert.NotEmpty(builds);
            Assert.Equal(2, builds.Count());
        }

        [Fact]
        public async void GetBuildsInScope()
        {
            var builds = await _builds.AllInScope(PipelineStatus.success);
            Assert.NotNull(builds);
            Assert.NotEmpty(builds);
            Assert.Equal(1, builds.Count());
        }

        [Fact]
        public async void GetBuild()
        {
            var build = await _builds["1"];
            Assert.NotNull(build);
            Assert.Equal(1, build.Id);
            Assert.Equal("single_build", build.Name);
            Assert.Equal("skipped", build.Status);
            Assert.Equal("build", build.Stage);
            Assert.Equal("single_build", build.Name);
            Assert.Equal("ref", build.Ref);
            Assert.Equal(false, build.Tag);
            Assert.Equal(null, build.Coverage);
            Assert.Equal(DateTime.Now.Date, build.CreatedAt);
            Assert.Equal(null, build.StartedAt);
            Assert.Equal(null, build.FinishedAt);
        }
    }
}