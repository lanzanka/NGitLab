using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class ProjectClient : IProjectClient
    {
        private readonly HttpRequestor _httpRequestor;

        public ProjectClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Project>> Accessible() => await _httpRequestor.GetAll<Project>(Project.Url);

        public async Task<IEnumerable<Project>> Owned() => await _httpRequestor.GetAll<Project>(Project.Url + "/owned");

        public async Task<IEnumerable<Project>> All() => await _httpRequestor.GetAll<Project>(Project.Url + "/all");

        public Project this[int id] => _httpRequestor.Get<Project>(Project.Url + "/" + id).Result;

        public async Task<Project> CreateAsync(ProjectCreate project) => await _httpRequestor.With(project).Post<Project>(Project.Url);

        public async Task DeleteAsync(int id) => await _httpRequestor.Delete(Project.Url + "/" + id);
    }
}