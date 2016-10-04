using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab
{
    public interface IBranchClient
    {
        Task<IEnumerable<Branch>> All();

        Branch this[string name] { get; }

        Task<Branch> ProtectAsync(string name);

        Task<Branch> UnprotectAsync(string name);

        Task<Branch> CreateAsync(BranchCreate branch);

        Task DeleteAsync(string name);
    }
}