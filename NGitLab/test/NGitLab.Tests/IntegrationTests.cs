using NGitLab.Dotnet.Tests.Fixtures;
using NGitLab.Models;
using System;
using System.Linq;
using Xunit;

namespace NGitLab.Dotnet.Tests
{
    public class IntegrationTests : IClassFixture<IntegrationTestFixture>, IDisposable
    {
        private const string ProjectName = "Unit_Test_Project";

        private IntegrationTestFixture _testFixture;

        public IntegrationTests(IntegrationTestFixture testFixture)
        {
            _testFixture = testFixture;
        }

        public void Dispose()
        {
            var client = new GitLabClient(_testFixture.Host, _testFixture.PrivateToken);

            // Make sure users have been deleted except for the adminitrator
            var users = client.Users.All().Result.Where(x => x.Name != "Administrator").ToList();
            if (users.Count() > 0)
            {
                foreach (var user in users)
                {
                    client.Users.DeleteAsync(user.Id).Wait();
                }
            }

            // Make sure all projects are deleted
            var projects = client.Projects.All().Result;

            foreach (var project in projects)
            {
                client.Projects.DeleteAsync(project.Id).Wait();
            }

            // Make sure all groups are deleted
            var groups = client.Groups.Accessible().Result;

            foreach (var group in groups)
            {
                client.Groups.DeleteAsync(group.Id).Wait();
            }
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async void LoginTest()
        {
            var client = new GitLabClient(_testFixture.Host);
            var session = await client.LoginAsync(_testFixture.Username, _testFixture.Password);

            Assert.NotNull(session);
            Assert.Equal("Administrator", session.Name);
            Assert.Equal("admin@example.com", session.Email);
            Assert.Equal("root", session.Username);
            Assert.True(session.CanCreateGroup);
            Assert.True(session.CanCreateProject);
            Assert.True(session.IsAdmin);
            Assert.NotNull(session.PrivateToken);

            var users = await client.Users.All();
            Assert.NotEmpty(users);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async void PrivateTokenTest()
        {
            var client = new GitLabClient(_testFixture.Host, _testFixture.PrivateToken);
            var session = client.Users.Current;

            Assert.NotNull(session);
            Assert.Equal("Administrator", session.Name);
            Assert.Equal("admin@example.com", session.Email);
            Assert.Equal("root", session.Username);
            Assert.True(session.CanCreateGroup);
            Assert.True(session.CanCreateProject);
            Assert.True(session.IsAdmin);
            Assert.NotNull(session.PrivateToken);

            var users = await client.Users.All();
            Assert.NotEmpty(users);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async void CreateUpdateDeleteUserTest()
        {
            ///
            /// Create
            ///
            var client = new GitLabClient(_testFixture.Host, _testFixture.PrivateToken);
            var user = await client.Users.CreateAsync(new UserUpsert
            {
                Name = "Unit_Test",
                Username = "unittest",
                Password = "Test.1234",
                Email = "unit.test@example.com"
            });

            Assert.Equal("Unit_Test", user.Name);
            Assert.Equal("unittest", user.Username);
            Assert.Equal("unit.test@example.com", user.Email);
            Assert.False(user.CanCreateGroup);
            Assert.False(user.CanCreateProject);

            ///
            /// Update
            ///
            var updatedUser = await client.Users.UpdateAsync(user.Id, new UserUpsert
            {
                Name = "Test_Unit",
                Username = "testunit"
            });

            Assert.Equal("Test_Unit", updatedUser.Name);
            Assert.Equal("testunit", updatedUser.Username);
            Assert.Equal("unit.test@example.com", updatedUser.Email);
            Assert.False(updatedUser.CanCreateGroup);
            Assert.False(updatedUser.CanCreateProject);

            ///
            /// Delete
            ///
            await client.Users.DeleteAsync(user.Id);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async void CreateDeleteGroupsTest()
        {
            ///
            /// Create
            ///
            var client = new GitLabClient(_testFixture.Host, _testFixture.PrivateToken);
            var group = await client.Groups.CreateAsync(new NamespaceCreate
            {
                Name = "Test_Group",
                Path = "Test-Path"
            });

            Assert.Equal("Test_Group", group.Name);
            Assert.Equal("Test-Path", group.Path);

            ///
            /// Delete
            ///
            await client.Groups.DeleteAsync(group.Id);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async void CreateDeleteProjectTest()
        {
            ///
            /// Create
            ///
            var client = new GitLabClient(_testFixture.Host, _testFixture.PrivateToken);
            var project = await client.Projects.CreateAsync(new ProjectCreate { Name = ProjectName });

            Assert.Equal(ProjectName, project.Name);

            ///
            /// Delete
            ///
            await client.Projects.DeleteAsync(project.Id);
        }
    }
}
