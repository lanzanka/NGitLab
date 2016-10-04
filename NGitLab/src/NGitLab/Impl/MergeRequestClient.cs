using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class MergeRequestClient : IMergeRequestClient
    {
        private readonly HttpRequestor _httpRequestor;
        private readonly string _projectPath;

        public MergeRequestClient(HttpRequestor httpRequestor, int projectId)
        {
            _httpRequestor = httpRequestor;
            _projectPath = Project.Url + "/" + projectId;
        }

        public async Task<IEnumerable<MergeRequest>> All() => await _httpRequestor.GetAll<MergeRequest>(_projectPath + "/merge_requests");

        public async Task<IEnumerable<MergeRequest>> AllInState(MergeRequestState state) => await _httpRequestor.GetAll<MergeRequest>(_projectPath + "/merge_requests?state=" + state);

        public MergeRequest this[int id] => _httpRequestor.Get<MergeRequest>(_projectPath + "/merge_request/" + id).Result;

        public async Task<MergeRequest> CreateAsync(MergeRequestCreate mergeRequest) => await _httpRequestor
            .With(mergeRequest)
            .Post<MergeRequest>(_projectPath + "/merge_requests");

        public async Task<MergeRequest> UpdateAsync(int mergeRequestId, MergeRequestUpdate mergeRequest) => await _httpRequestor
            .With(mergeRequest)
            .Put<MergeRequest>(_projectPath + "/merge_request/" + mergeRequestId);

        public async Task<MergeRequest> AcceptAsync(int mergeRequestId, MergeCommitMessage message) => await _httpRequestor
            .With(message)
            .Put<MergeRequest>(_projectPath + "/merge_request/" + mergeRequestId + "/merge");

        public IMergeRequestCommentClient Comments(int mergeRequestId) => new MergeRequestCommentClient(_httpRequestor, _projectPath, mergeRequestId);

        public IMergeRequestCommitClient Commits(int mergeRequestId) => new MergeRequestCommitClient(_httpRequestor, _projectPath, mergeRequestId);
    }
}