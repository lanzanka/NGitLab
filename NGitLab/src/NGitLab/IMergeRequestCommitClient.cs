using NGitLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IMergeRequestCommitClient
    {
        Task<IEnumerable<Commit>> All();
    }
}