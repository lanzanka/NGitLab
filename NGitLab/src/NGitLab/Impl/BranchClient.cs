using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class BranchClient : IBranchClient
    {
        private readonly string _repoPath;
        private readonly HttpRequestor _httpRequestor;

        public BranchClient(HttpRequestor httpRequestor, string repoPath)
        {
            _repoPath = repoPath;
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Branch>> All() => await _httpRequestor.GetAll<Branch>(_repoPath + "/branches");

        public Task<Branch> this[string name] => _httpRequestor.Get<Branch>(_repoPath + "/branches/" + name);

        public async Task<Branch> ProtectAsync(string name) => await _httpRequestor.Put<Branch>(_repoPath + "/branches/" + name + "/protect");

        public async Task<Branch> UnprotectAsync(string name) => await _httpRequestor.Put<Branch>(_repoPath + "/branches/" + name + "/unprotect");

        public async Task<Branch> CreateAsync(BranchCreate branch) => await _httpRequestor.With(branch).Post<Branch>(_repoPath + "/branches");

        public async Task DeleteAsync(string name) => await _httpRequestor.Delete(_repoPath + "/branches/" + name);
    }
}