using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab
{
    public interface IProjectClient
    {
        /// <summary>
        /// Get a list of projects accessible by the authenticated user.
        /// </summary>
        Task<IEnumerable<Project>> Accessible();

        /// <summary>
        /// Get a list of projects owned by the authenticated user.
        /// </summary>
        Task<IEnumerable<Project>> Owned();

        /// <summary>
        /// Get a list of all GitLab projects (admin only).
        /// </summary>
        Task<IEnumerable<Project>> All();

        Project this[int id] { get; }

        Task<Project> CreateAsync(ProjectCreate project);
        
        Task DeleteAsync(int id);
    }
}