using NGitLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IUserClient
    {
        Task<IEnumerable<User>> All();

        User this[int id] { get; }

        Task<User> CreateAsync(UserUpsert user);

        Task<User> UpdateAsync(int id, UserUpsert user);

        Task DeleteAsync(int id);

        Session Current { get; }
    }
}