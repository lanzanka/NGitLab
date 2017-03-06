using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab
{
    public interface IBuildClient
    {
        Task<IEnumerable<Build>> All();

        Task<IEnumerable<Build>> AllInScope(PipelineStatus status);
       
        Task<IEnumerable<Build>> GetCommitBuilds(Sha1 sha);

        Task<Build> this[string name] { get; }
       
        Task<Build> PlayBuildAsync(int buildId);
       
        Task<Build> RetryBuildAsync(int buildId);
       
        Task<string> GetTraceFileAsync(int buildId);
    }
}