using NGitLab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class LabelClient : ILabelClient
    {
        public const string ProjectLabelUrl = "/projects/{0}/labels";

        private readonly HttpRequestor _httpRequestor;

        public LabelClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Label>> ForProject(int projectId) => await _httpRequestor.GetAll<Label>(string.Format(ProjectLabelUrl, projectId));

        public async Task<Label> GetLabel(int projectId, string name) => (await ForProject(projectId)).FirstOrDefault<Label>((x) => x.Name.Equals(name));

        public async Task<Label> CreateAsync(LabelCreate label) => await _httpRequestor.With(label).Post<Label>(string.Format(ProjectLabelUrl, label.Id));

        public async Task<Label> EditAsync(LabelEdit label) => await _httpRequestor.With(label).Put<Label>(string.Format(ProjectLabelUrl, label.Id));

        public async Task DeleteAsync(LabelDelete label) => await _httpRequestor.Delete(string.Format(ProjectLabelUrl, label.Id));
    }
}
