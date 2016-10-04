using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IProjectHooksClient
    {
        Task<IEnumerable<ProjectHook>> All();

        ProjectHook this[int hookId] { get; }

        Task<ProjectHook> CreateAsync(ProjectHookUpsert hook);

        Task<ProjectHook> UpdateAsync(int hookId, ProjectHookUpsert hook);

        Task DeleteAsync(int hookId);
    }
}