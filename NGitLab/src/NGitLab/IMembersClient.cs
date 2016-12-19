using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface IMembersClient
    {
        /// <summary>Get a list of users for the specified project.</summary>
        Task<IEnumerable<Member>> ForProject(int projectId);

        /// <summary>Add User to project</summary>
        Task AddToProject(int projectId, int userId, MemberAccessLevel accessLevel);

        /// <summary>Remove User from project</summary>
        Task RemoveFromProject(int projectId, int userId);

        /// <summary>Get a list of users for the specified group.</summary>
        Task<IEnumerable<Member>> ForGroup(int namespaceId);

        /// <summary>Add User to group</summary>
        Task AddToGroup(int projectId, int userId, MemberAccessLevel accessLevel);

        /// <summary>Remove User from group</summary>
        Task RemoveFromGroup(int projectId, int userId);
    }
}