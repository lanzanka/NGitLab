using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IMergeRequestClient
    {
        Task<IEnumerable<MergeRequest>> All();

        Task<IEnumerable<MergeRequest>> AllInState(MergeRequestState state);

        MergeRequest this[int id] { get; }

        Task<MergeRequest> CreateAsync(MergeRequestCreate mergeRequest);

        Task<MergeRequest> UpdateAsync(int mergeRequestId, MergeRequestUpdate mergeRequest);

        Task<MergeRequest> AcceptAsync(int mergeRequestId, MergeCommitMessage message);

        IMergeRequestCommentClient Comments(int mergeRequestId);

        IMergeRequestCommitClient Commits(int mergeRequestId);
    }
}