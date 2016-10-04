using NGitLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface INamespaceClient
    {
        /// <summary>
        /// Get a list of projects accessible by the authenticated user.
        /// </summary>
        Task<IEnumerable<Namespace>> Accessible();

        Namespace this[int id] { get; }

        Task<Namespace> CreateAsync(NamespaceCreate group);
        
        Task DeleteAsync(int id);
    }
}