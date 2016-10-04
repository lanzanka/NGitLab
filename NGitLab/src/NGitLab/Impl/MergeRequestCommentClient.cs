using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class MergeRequestCommentClient : IMergeRequestCommentClient
    {
        private readonly HttpRequestor _httpRequestor;
        private readonly string _commentsPath;

        public MergeRequestCommentClient(HttpRequestor httpRequestor, string projectPath, int mergeRequestId)
        {
            _httpRequestor = httpRequestor;
            _commentsPath = projectPath + "/merge_request/" + mergeRequestId + "/comments";
        }

        public async Task<IEnumerable<MergeRequestComment>> All() => await _httpRequestor.GetAll<MergeRequestComment>(_commentsPath);

        public async Task<MergeRequestComment> AddAsync(MergeRequestComment comment) => await _httpRequestor.With(comment).Post<MergeRequestComment>(_commentsPath);
    }
}