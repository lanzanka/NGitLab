using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab
{
    public interface IIssueClient
    {
        /// <summary>
        /// Get a list of all project issues
        /// </summary>
        Task<IEnumerable<Issue>> Owned();

        /// <summary>
        /// Get a list of issues for the specified project.
        /// </summary>
        Task<IEnumerable<Issue>> ForProject(int projectId);

        /// <summary>
        /// Return a single issue for a project given project.
        /// </summary>
        Task<Issue> GetAsync(int projectId, int issueId);

        /// <summary>
        /// Add an issue witht he proposed title to the GitLab list for the selected proejct id.
        /// </summary>
        Task<Issue> CreateAsync(IssueCreate issueCreate);

        /// <summary>
        /// Edit and save an issue.
        /// </summary>
        Task<Issue> EditAsync(IssueEdit issueEdit);
    }
}