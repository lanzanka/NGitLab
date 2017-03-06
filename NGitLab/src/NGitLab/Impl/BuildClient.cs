using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class BuildClient : IBuildClient
    {
        private readonly string _repoPath;
        private readonly string _projectPath;
        private readonly HttpRequestor _httpRequestor;

        public BuildClient(HttpRequestor httpRequestor, string repoPath, string projectPath)
        {
            _repoPath = repoPath;
            _projectPath = projectPath;
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Build>> All() => await _httpRequestor.GetAll<Build>(_projectPath + "/builds");

        public async Task<IEnumerable<Build>> AllInScope(PipelineStatus status) => await _httpRequestor.GetAll<Build>(_projectPath + "/builds?scope=" + status);

        public async Task<IEnumerable<Build>> GetCommitBuilds(Sha1 sha) => await _httpRequestor.GetAll<Build>(_repoPath + "/commits/" + sha + "/builds");

        public Task<Build> this[string id] => _httpRequestor.Get<Build>(_projectPath + "/builds/" + id);

        public async Task<Build> PlayBuildAsync(int buildId) => await _httpRequestor.Post<Build>(_projectPath + "/builds/" + buildId + "/play");

        public async Task<Build> RetryBuildAsync(int buildId) => await _httpRequestor.Post<Build>(_projectPath + "/builds/" + buildId + "/retry");

        public async Task<string> GetTraceFileAsync(int buildId) => await _httpRequestor.Get<string>(_projectPath + "/builds/" + buildId + "/trace");
    }
}