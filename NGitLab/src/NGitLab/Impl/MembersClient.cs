using System.Collections.Generic;
using NGitLab.Models;
using System.Threading.Tasks;

namespace NGitLab.Impl
{
    public class MembersClient : IMembersClient
    {
        private const string ProjectMembersUrl = "/projects/{0}/members";
        private const string GroupsMembersUrl = "/groups/{0}/members";
        private const string ProjectMembersDelUrl = "/projects/{0}/members/{1}";
        private const string GroupsMembersDelUrl = "/groups/{0}/members/{1}";

        private readonly HttpRequestor _httpRequestor;

        public MembersClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Member>> ForProject(int projectId) => await _httpRequestor.GetAll<Member>(string.Format(ProjectMembersUrl, projectId));

        public async Task AddToProject(int projectId, int userId, MemberAccessLevel accessLevel) =>
            await _httpRequestor
                .With(new { id = projectId, user_id = userId, access_level = accessLevel })
                .Post<Member>(string.Format(ProjectMembersUrl, projectId));

        public async Task RemoveFromProject(int projectId, int userId) =>
            await _httpRequestor
                .Delete(string.Format(ProjectMembersDelUrl, projectId, userId));

        public async Task<IEnumerable<Member>> ForGroup(int groupId) => await _httpRequestor.GetAll<Member>(string.Format(GroupsMembersUrl, groupId));

        public async Task AddToGroup(int projectId, int userId, MemberAccessLevel accessLevel) =>
            await _httpRequestor
                .With(new { id = projectId, user_id = userId, access_level = accessLevel })
                .Post<Member>(string.Format(GroupsMembersUrl, projectId));

        public async Task RemoveFromGroup(int projectId, int userId) =>
            await _httpRequestor
                .Delete(string.Format(GroupsMembersDelUrl, projectId, userId));
    }
}
