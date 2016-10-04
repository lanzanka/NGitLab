using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IGitLabClient
    {
        IRepositoryClient GetRepository(int projectId);

        IMergeRequestClient GetMergeRequest(int projectId);

        IUserClient Users { get; }

        IProjectClient Projects { get; }

        IIssueClient Issues { get; }

        INamespaceClient Groups { get; }

        ILabelClient Labels { get; }

        Task<Session> LoginAsync(string username, string password);
    }
}
