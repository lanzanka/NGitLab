using System.Collections.Generic;
using NGitLab.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class IssueClient : IIssueClient
    {
        private const string IssuesUrl = "/issues";
        private const string ProjectIssuesUrl = "/projects/{0}/issues";
        private const string SingleIssueUrl = "/projects/{0}/issues/{1}";
        
        private readonly HttpRequestor _httpRequestor;

        public IssueClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Issue>> Owned() => await _httpRequestor.GetAll<Issue>(IssuesUrl);

        public async Task<IEnumerable<Issue>> ForProject(int projectId) => await _httpRequestor.GetAll<Issue>(string.Format(ProjectIssuesUrl, projectId));

        public async Task<Issue> GetAsync(int projectId, int issueId) => await _httpRequestor.Get<Issue>(string.Format(SingleIssueUrl, projectId, issueId));

        public async Task<Issue> CreateAsync(IssueCreate issueCreate) => await _httpRequestor.With(issueCreate).Post<Issue>(string.Format(ProjectIssuesUrl, issueCreate.ProjectId));

        public async Task<Issue> EditAsync(IssueEdit issueEdit) => await _httpRequestor.With(issueEdit).Put<Issue>(string.Format(SingleIssueUrl, issueEdit.Id, issueEdit.IssueId));
    }
}
