using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class ProjectHooksClient : IProjectHooksClient
    {
        private readonly HttpRequestor _httpRequestor;
        private readonly string _path;

        public ProjectHooksClient(HttpRequestor httpRequestor, string projectPath)
        {
            _httpRequestor = httpRequestor;
            _path = projectPath + "/hooks";
        }

        public async Task<IEnumerable<ProjectHook>> All() => await _httpRequestor.GetAll<ProjectHook>(_path);

        public ProjectHook this[int hookId] => _httpRequestor.Get<ProjectHook>(_path + "/" + hookId).Result;

        public async Task<ProjectHook> CreateAsync(ProjectHookUpsert hook) => await _httpRequestor.With(hook).Post<ProjectHook>(_path);

        public async Task<ProjectHook> UpdateAsync(int hookId, ProjectHookUpsert hook) => await _httpRequestor.With(hook).Put<ProjectHook>(_path + "/" + hookId);

        public async Task DeleteAsync(int hookId) => await _httpRequestor.Delete(_path + "/" + hookId);
    }
}