using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class UserClient : IUserClient
    {
        private readonly HttpRequestor _httpRequestor;

        public UserClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<User>> All() => await _httpRequestor.GetAll<User>(User.Url);

        public User this[int id] => _httpRequestor.Get<User>(User.Url + "/" + id).Result;

        public async Task<User> CreateAsync(UserUpsert user) => await _httpRequestor.With(user).Post<User>(User.Url);

        public async Task<User> UpdateAsync(int id, UserUpsert user) => await _httpRequestor.With(user).Put<User>(User.Url + "/" + id);

        public Session Current => _httpRequestor.Get<Session>("/user").Result;

        public async Task DeleteAsync(int userId) => await _httpRequestor.Delete(User.Url + "/" + userId);
    }
}