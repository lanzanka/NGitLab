using NGitLab.Dotnet.Tests.Fixtures;
using NGitLab.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NGitLab.Tests
{
    public class UsersTests : IClassFixture<UserTestFixture>
    {
        private readonly IUserClient _users;

        public UsersTests(UserTestFixture userTestFixture)
        {
            _users = userTestFixture.Client.Users;
        }

        [Fact]
        public void Current()
        {
            var session = _users.Current;
            Assert.NotNull(session);
            Assert.Equal(DateTime.Now.Date, session.CreatedAt.Date);
            Assert.Equal("admin@example.com", session.Email);
            Assert.Equal("Administrator", session.Name);
            Assert.Equal("1234", session.PrivateToken);
        }

        [Fact]
        public async void GetUsers()
        {
            var users = await _users.All();
            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public void GetUser()
        {
            var user = _users[1];
            Assert.NotNull(user);
            Assert.Equal(user.Username, "root");
            Assert.True(user.CanCreateGroup);
        }

        [Fact]
        public async Task CreateUpdateDelete()
        {
            var userUpsert = new UserUpsert
            {
                Email = "test@test.pl",
                Bio = "bio",
                CanCreateGroup = true,
                IsAdmin = true,
                Linkedin = null,
                Name = "sadfasdf",
                Password = "!@#$QWDRQW@",
                ProjectsLimit = 1000,
                Provider = "provider",
                Skype = "skype",
                Twitter = "twitter",
                Username = "username",
                WebsiteURL = "wp.pl"
            };

            var addedUser = await _users.CreateAsync(userUpsert);
            Assert.Equal(addedUser.Bio, userUpsert.Bio);

            userUpsert.Bio = "Bio2";
            userUpsert.Email = "test@test.pl";

            var updatedUser = await _users.UpdateAsync(addedUser.Id, userUpsert);
            Assert.Equal(updatedUser.Bio, userUpsert.Bio);

            await _users.DeleteAsync(addedUser.Id);
        }
    }
}