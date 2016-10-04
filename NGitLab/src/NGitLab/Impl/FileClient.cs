using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class FileClient : IFilesClient
    {
        private readonly HttpRequestor _httpRequestor;
        private readonly string _repoPath;

        public FileClient(HttpRequestor httpRequestor, string repoPath)
        {
            _httpRequestor = httpRequestor;
            _repoPath = repoPath;
        }

        public async Task<FileResponse> CreateAsync(FileUpsert file) => await _httpRequestor.With(file).Post<FileResponse>(_repoPath + "/files");

        public async Task<FileResponse> UpdateAsync(FileUpsert file) => await _httpRequestor.With(file).Put<FileResponse>(_repoPath + "/files");

        public async Task DeleteAsync(FileDelete file) => await _httpRequestor.With(file).Delete(_repoPath + "/files");
    }
}