using NGitLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class MergeRequestCommitClient : IMergeRequestCommitClient
    {
        private readonly HttpRequestor _httpRequestor;
        private readonly string _commitsPath;

        public MergeRequestCommitClient(HttpRequestor httpRequestor, string projectPath, int mergeRequestId)
        {
            _httpRequestor = httpRequestor;
            _commitsPath = projectPath + "/merge_request/" + mergeRequestId + "/commits";
        }

        public async Task<IEnumerable<Commit>> All() => await _httpRequestor.GetAll<Commit>(_commitsPath);
    }
}