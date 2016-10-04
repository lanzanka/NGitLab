using NGitLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IMergeRequestCommentClient
    {
        Task<IEnumerable<MergeRequestComment>> All();

        Task<MergeRequestComment> AddAsync(MergeRequestComment comment);
    }
}